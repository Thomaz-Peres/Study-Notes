The method async is allowed to invoke the callback synchronously if the operation completes syhnchronously.

they're not "asynchronous" because they're guaranteed to complete asynchronously but rather are just permitted to.

Such a buffer might exist behind whatever asynchronous abstraction you're using, such that the first uch that the first “asynchronous” operation you perform (filling the buffer) completes "asynchronous" operation you perform (filling the buffer) completes asynchronously.
