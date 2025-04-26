// To Work should put this into program

using System.Runtime.CompilerServices;


// Simulating await
MyTask.Iterate(PrintAsync()).Wait();

static IEnumerable<MyTask> PrintAsync()
{
    for (int i = 0; ; i++)
    {
        yield return MyTask.Delay(1000);
        Console.WriteLine(i);
    }
}


// Using await 
PrintAsync2().Wait();

static async Task PrintAsync2()
{
    for (int i = 0; ; i++)
    {
        await MyTask.Delay(1000);
        Console.WriteLine(i);
    }
}


// Console.WriteLine("Hello, ");
// MyTask.Delay(2000).ContinueWith(() =>
// {
//     Console.WriteLine("World");
//     return MyTask.Delay(2000).ContinueWith(() =>
//     {
//         Console.WriteLine(" And Thomaz");
//         return MyTask.Delay(2000).ContinueWith(() =>
//         {
//             Console.WriteLine(" How Are you ?");
//         });
//     });

// }).Wait();

// AsyncLocal<int> myValue = new();
// List<MyTask> tasks = new();
// for (int i = 0; i < 100; i++)
// {
//     myValue.Value = i;
//     tasks.Add(MyTask.Run(() =>
//     {
//         Console.WriteLine(myValue.Value);
//         Thread.Sleep(1000);
//     }));
// }
// MyTask.WhenAll(tasks).Wait();


class MyTask
{
    private bool _completed;
    private Exception? _exception;
    private Action? _continuation;
    private ExecutionContext? _context;

    public struct Awaiter(MyTask t) : INotifyCompletion
    {
        public Awaiter GetAwaiter() => this;

        public bool IsCompleted => t.IsCompleted;

        public void OnCompleted(Action continuation) => t.ContinueWith(continuation);

        public void GetResult() => t.Wait();
    }

    public Awaiter GetAwaiter() => new(this);

    public bool IsCompleted
    {
        get
        {
            // Don't do this in general case
            lock (this)
            {
                return _completed;
            }
        }
    }
    public void SetResult() => Complete(null);
    public void SetException(Exception exception) => Complete(exception);
    private void Complete(Exception? exception)
    {
        if (_completed) throw new InvalidOperationException("Stop messing up the code");

        _completed = true;
        _exception = exception;

        if (_continuation is not null)
        {
            MyThreadPool.QueueUserWorkItem(() =>
            {
                if (_context is null)
                {
                    _continuation();
                }
                else
                {
                    ExecutionContext.Run(_context, (object? state) => ((Action)state!).Invoke(), _continuation);
                }
            });
        }
    }

    public void Wait()
    {
        ManualResetEventSlim? mres = null;

        lock (this)
        {
            if (!_completed)
            {
                mres = new ManualResetEventSlim();
                ContinueWith(mres.Set);
            }
        }

        mres?.Wait();

        if (_exception is not null)
            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(_exception);
    }

    public MyTask ContinueWith(Action action)
    {
        MyTask t = new();

        Action callback = () =>
        {
            try
            {
                action();
            }
            catch (System.Exception e)
            {
                t.SetException(e);
                return;
            }

            t.SetResult();
        };

        lock (this)
        {
            if (_completed)
            {
                MyThreadPool.QueueUserWorkItem(callback);
            }
            else
            {
                _continuation = callback;
                _context = ExecutionContext.Capture();
            }
        }

        return t;
    }

    public MyTask ContinueWith(Func<MyTask> action)
    {
        MyTask t = new();

        Action callback = () =>
        {
            try
            {
                MyTask next = action();
                next.ContinueWith(() =>
                {
                    if (next._exception is not null)
                    {
                        t.SetException(next._exception);
                    }
                    else
                    {
                        t.SetResult();
                    }
                });
            }
            catch (System.Exception e)
            {
                t.SetException(e);
                return;
            }
        };

        lock (this)
        {
            if (_completed)
            {
                MyThreadPool.QueueUserWorkItem(callback);
            }
            else
            {
                _continuation = callback;
                _context = ExecutionContext.Capture();
            }
        }

        return t;
    }

    public static MyTask Run(Action action)
    {
        MyTask t = new();

        MyThreadPool.QueueUserWorkItem(() =>
        {
            try
            {
                action();
            }
            catch (System.Exception e)
            {
                t.SetException(e);
                return;
            }

            t.SetResult();
        });

        return t;
    }

    public static MyTask WhenAll(List<MyTask> tasks)
    {
        MyTask t = new();

        if (tasks.Count == 0)
            t.SetResult();
        else
        {
            int remaining = tasks.Count;
            Action continuation = () =>
            {
                if (Interlocked.Decrement(ref remaining) == 0)
                {
                    t.SetResult();
                }
            };

            foreach (var task in tasks)
            {
                task.ContinueWith(continuation);
            }
        }

        return t;
    }

    public static MyTask Delay(int timeout)
    {
        MyTask t = new();

        // Why not just use a thread.Sleep() ?

        // Thread.Sleep() takes the thread and puts it to sleep for the specified amout of time.
        // You block all threads in thread pool unable to do anything else

        // And this, allow that thread to do something else while that's happening
        new Timer(_ => t.SetResult()).Change(timeout, -1);
        return t;
    }

    // This little helper is basically what the compiler generates for async await
    // In the C# compiler, the logic to support implementing Iterators and the logic to support implementing async methods it's like 90% the same
    public static MyTask Iterate(IEnumerable<MyTask> tasks)
    {
        MyTask t = new();

        IEnumerator<MyTask> e = tasks.GetEnumerator();

        void MoveNext()
        {
            try
            {
                if (e.MoveNext())
                {
                    MyTask next = e.Current;
                    next.ContinueWith(MoveNext);
                    return;
                }
            }
            catch (System.Exception ex)
            {
                t.SetException(ex);
                return;
            }

            t.SetResult();
        }

        MoveNext();

        return t;
    }
}

static class MyThreadPool
{
    // The 'BlockingCollection' you can store basically concurrent queue.
    // But when I want to take something out I will block waiting to take out/

    // That's what I want myh threads to be doing all of my threads and my thread pool are going to be trying to take things from this queue to process it and if there's nothing. I want them to just wait for something to do.
    private static readonly System.Collections.Concurrent.BlockingCollection<(Action, ExecutionContext?)> s_workItems = new();

    // ExecutionContext is basically a dictionary of key value pairs that stored thread local storage (it's fancy that's is)
    public static void QueueUserWorkItem(Action action) => s_workItems.Add((action, ExecutionContext.Capture()));

    static MyThreadPool()
    {
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            new Thread(() =>
            {
                while (true)
                {
                    (Action workItem, ExecutionContext? context) = s_workItems.Take();
                    if (context is null)
                    {
                        workItem();
                    }
                    else
                    {
                        ExecutionContext.Run(context, (object? state) => ((Action)state!).Invoke(), workItem);
                    }
                }
            })
            {
                IsBackground = true
            }.Start();
        }
    }
}
