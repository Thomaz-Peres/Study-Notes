using System.ComponentModel;

namespace AsyncAwaitEvents;

// Our earlier DoStuff example might have been exposed as a set of members like this:

public class EventsHandler
{
    public int DoStuff(string arg);

    public void DoStuffAsync(string arg, object? userToken);
    public event DoStuffEventHandler? DoStuffCompleted;
}

public delegate void DoStuffEventHandler(object sender, DoStuffEventArgs e);

public class DoStuffEventArgs : AsyncCompletedEventArgs
{
    public DoStuffEventArgs(int result, Exception? error, bool canceled, object? userToken) :
        base(error, canceled, userToken) => Result = result;

    public int Result { get; }
}
