# Protocols, HTTP and TCP

The two main protocols involved in web servers are *Hypertext Transfer Protocol (HTTP)* and *Transmission Control Protocol (TCP)*.

Both protocols are `request-response` protocols, meaning a `client` initiates requests and a `server` listens to the requests and provides a response to the client. The contents are defined by the protocols.

**TCP:** Is the lower-level protocol that describes the details of how information gets from one server to another but doesn't specify what that information is.
Is just a different set of convetions, that computers adhere to in order to solve a couple of different problems.

**HTTP:** Build on top of TCP by defining the contents of the request and responses.
It's technically possible to use HTTP with other protocols, but in the vast majority of cases, HTTP sends its data over TCP. 

We'll work with the raw bytes of TCP and HTTP request and responses.


Connecting to a port 80 requires administrator privileges (non admin can listen only on ports higher than 1023).

So, if we tried to connect to port 80 without being an administrator, binding wouldn't work.









_____________________________ I NEED TO READ THAT BELOW AGAIN, NOT IS A COMPLETE AND GOOD EXPLANATION_________________________
## TCP

One is this problem of distinguishing one type of service from another.
The humans decided to assign different services that can be used on the internet. Unique numbers.
And so two of the most common are these (is numbers that a bunch of humans decided years ago will represent what you and I know as):

- 80: HTTP
- 443: HTTPS

#### How TCP knows the another user got the message

That another computer by design of this protocol will also acknowledge the packets that he's received. And it will do it efficiently.

This another computer will send to your's computer a quick message saying "received all"