using Async;

public class CopyStream
{
    public IAsyncResult BeginCopyStreamToStream(
        Stream source, Stream destination,
        System.AsyncCallback callback, object state)
    {
        var ar = new MyAsyncResult(state);
        var buffer = new byte[0x1000];

        Action<IAsyncResult?> readWriteLoop = null!;
        readWriteLoop = iar =>
        {
            try
            {
                for (bool isRead = iar == null; ; isRead = !isRead)
                {
                    if (isRead)
                    {
                        iar = source.BeginRead(buffer, 0, buffer.Length, static readResult =>
                        {
                            if (!readResult.CompletedSynchronously)
                            {
                                ((Action<IAsyncResult?>)readResult.AsyncState!)(readResult);
                            }
                        }, readWriteLoop);

                        if (!iar.CompletedSynchronously)
                        {
                            return;
                        }
                    }
                    else
                    {
                        int numRead = source.EndRead(iar!);
                        if (numRead == 0)
                        {
                            ar.Complete(null);
                            callback?.Invoke(ar);
                            return;
                        }

                        iar = destination.BeginWrite(buffer, 0, numRead, writeResult =>
                        {
                            if (!writeResult.CompletedSynchronously)
                            {
                                try
                                {
                                    destination.EndWrite(writeResult);
                                    readWriteLoop(null);
                                }
                                catch (Exception e2)
                                {
                                    ar.Complete(e2);
                                    callback?.Invoke(ar);
                                }
                            }
                        }, null);

                        if (!iar.CompletedSynchronously)
                        {
                            return;
                        }

                        destination.EndWrite(iar);
                    }
                }
            }
            catch (Exception e)
            {
                ar.Complete(e);
                callback?.Invoke(ar);
            }
        };

        readWriteLoop(null);

        return ar;
    }

    public void EndCopyStreamToStream(IAsyncResult asyncResult)
    {
        if (asyncResult is not MyAsyncResult ar)
        {
            throw new ArgumentException(null, nameof(asyncResult));
        }

        ar.Wait();
    }

    private sealed class MyAsyncResult : IAsyncResult
    {
        private bool _completed;
        private int _completedSynchronously;
        private ManualResetEvent? _event;
        private Exception? _error;

        public MyAsyncResult(object? state) => AsyncState = state;

        public object? AsyncState { get; }

        public void Complete(Exception? error)
        {
            lock (this)
            {
                _completed = true;
                _error = error;
                _event?.Set();
            }
        }

        public void Wait()
        {
            WaitHandle? h = null;
            lock (this)
            {
                if (_completed)
                {
                    if (_error is not null)
                    {
                        throw _error;
                    }
                    return;
                }

                h = _event ??= new ManualResetEvent(false);
            }

            h.WaitOne();
            if (_error is not null)
            {
                throw _error;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                lock (this)
                {
                    return _event ??= new ManualResetEvent(_completed);
                }
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                lock (this)
                {
                    if (_completedSynchronously == 0)
                    {
                        _completedSynchronously = _completed ? 1 : -1;
                    }

                    return _completedSynchronously == 1;
                }
            }
        }

        public bool IsCompleted
        {
            get
            {
                lock (this)
                {
                    return _completed;
                }
            }
        }
    }
}
