The method async is allowed to invoke the callback synchronously if the operation completes syhnchronously.

they're not "asynchronous" because they're guaranteed to complete asynchronously but rather are just permitted to.

When this happen, you have one stack frame that called the Begin method, another stack frame for the Begin method itself, and now another stack for the callback. If an operation completes synchronously and its callback is invoked synchronously, you're now again several more deep on the stack. This is a out of stack.


Such a buffer might exist behind whatever asynchronous abstraction you're using, such that the first uch that the first “asynchronous” operation you perform (filling the buffer) completes "asynchronous" operation you perform (filling the buffer) completes asynchronously.
