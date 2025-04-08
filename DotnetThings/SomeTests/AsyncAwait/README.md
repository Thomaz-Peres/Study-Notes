The method async is allowed to invoke the callback synchronously if the operation completes syhnchronously.

they're not "asynchronous" because they're guaranteed to complete asynchronously but rather are just permitted to.

When this happen, you have one stack frame that called the Begin method, another stack frame for the Begin method itself, and now another stack for the callback. If an operation completes synchronously and its callback is invoked synchronously, you're now again several more deep on the stack. This is a out of stack.

Such a buffer might exist behind whatever asynchronous abstraction you're using, such that the first uch that the first “asynchronous” operation you perform (filling the buffer) completes "asynchronous" operation you perform (filling the buffer) completes asynchronously.


# How to compesate the stack overflow


1. Don't allow the `AsyncCallback` to be invoked synchronously. If it’s always invoked asynchronously, even if the operation completes synchronously, then the risk of stack dives goes away.

2. Employ a mechanism that allow the caller rather than the callback to do the continuation work if the operation completes synchronously. That way, you escape the extra method frame and continue doing the follow-on work no deeper on the stack.


# Inside IAsyncResult.

- `IsCompleted` tells you wheter the operation has completed.

- `CompletedSynchronously` never changes (or if it does, it's a nasty bug waiting to happen).
    - it's  used to communicate between the caller of the Begin method and the `AsyncCallback` which of tem is resposible for performing any continuation work.


_________________________________________________________________________________


# Event-Based Asynchronous Pattern (EAP)

A different pattern for handling asynchronous operation one primarily intended for doing so in the context of client application.

The EAP, also came as a pair of member (at least, possibly more), this time a method to initiate the asynchronous operation and an event ot listem for its completion.
