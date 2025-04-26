namespace AsyncAwait;

public class Handlerr
{
   public int DoStuff(string arg);

   public IAsyncResultt BeginDoStuff(string arg, AsyncCallbackk callback, object? state);
   public int EndDoStuff(IAsyncResultt asyncResult);
}

public interface IAsyncResultt
{
   object? AsyncState { get; }
   WaitHandle AsyncWaitHandle { get; }
   bool IsCompleted { get; }
   bool CompletedSynchronously { get; }
}

delegate void AsyncCallbackk(IAsyncResultt ar);
