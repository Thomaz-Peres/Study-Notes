## Threads vs. Processes

The links i read for this notes:
- https://medium.com/@rodbauer/understanding-programs-processes-and-threads-fd9fdede4d88
- https://en.wikipedia.org/wiki/Thread_(computing) (in this wikipedia link I only read like a plus for the last link)

Some review what I read.

1. The program starts out as a text file of programming code;
2. The program is compiled or interpreted into binary form;
3. The program is loaded into memory;
4. The program becomes one or more running processes
5. Processes are typically independent of each other;
6. While threads exist as the subset of a process;
7. Threads can communicate with each other more easily than processes can;
8. But threads are more vulnerable to problems caused by other threads in the same process.

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/592b599e-2e97-4d2d-af37-755aab0e9a01)


## How Processes Work

The essential resources every process needs are registers, a program counter, and a Stack.

- Registers: Are data holding places that are part of the computer processor (CPU). A register may hold an instruction, a storage address, or other kind of data needed by the process.

- Program counter: Also called the "instruction pointer", keeps track of where a computer is in its program sequence. 

- Stack: Is a data structure that stores information about the active subroutines of a computer program and is used as scratch space for the process. It is distinguished from dynamically allocated memory for the process that is know as the "heap".

The process can be multiple instances of a single program,and each instance of
that running program is a process. Each process has a separate memory address space.

It cannot directly access shared data in other processes.
Switching from one process to another requires some time (relatively) for saving and loading registers, memory maps, and other resources.

This independence of processes is valuable because the operating system tries its best to isolate processes so that a problem with one process doesn't corrupt or cause havoc with another process.


## How Threads Work

Thread is simple a SO event loop.

He use the scheduler of the SO to create the separation, and when finish the timer, he stop de computation and starting another.

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/4828789e-fe11-4d92-b5b0-9f85849c75ef)

When a process starts, it is assigned memory and resources.
Each thread in the process shares that memory and resources.

In single-threaded processes, the process and the thread are one and the same, and there is only one thing happening.

In multithreaded processes, the process contains more than one thread,
and the process is is accomplishing a number of things at the same time

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/8dd70218-d40c-408c-840c-5e399b738d83)

Each thread will have its own stack, but all threads in a process will share the heap.

Threads are sometimes called lightweight processes because they have
their own stack but can access shared data. Because threads share the same
address space as the process and other threads within the process,
the operational cost of communication between the threads is low, which is an advantage.
The disadvantage is that a problem with one thread in a process will certainly
affect other threads and the viability of the process itself.

A thread of execution is the smallest sequence of programmed instructions that can be managed
independently by a scheduler, which is typically a part ot he operating system


## Why choose Process over Thread, or Thread over Process ?

The google for example, for google chrome, made a calculated trade-off
with the multi-processing design. Starting a new process for each
browser window has a higer fixed cost in memory and resources than using threads.
They were betting that their approach would end up with less memory bloat overall.

Using processes instead of threads also provides better memory usage when memory get low.
An inactive window is treated as a lower priority by the operating system and becomes
eligible to be swapped to disk when memory is needed for other processes. That helps
keep the user-visible windows more responsive. If the windows were threaded, it would
be more difficult to separate the used and unused memory as celanly, wasting both memory and performance.

```You can read more about Google’s design decisions for Chrome on Google’s Chromium Blog(https://blog.chromium.org/2008/09/multi-process-architecture.html) or on the Chrome Introduction Comic.(https://www.google.com/googlebooks/chrome/med_00.html)```

