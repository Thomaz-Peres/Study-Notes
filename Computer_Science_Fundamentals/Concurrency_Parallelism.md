## Concurrency

#### CPU
The CPU runs one apps/program per time in 1 core, (if you have 18 core, you can run 18 apps/program).

**How a CPU with one core run a game, with audio, controllers, video, etc.**
    The tips is, the CPU separates the time, for example with 1 second, the CPU separe in 1000 windows of 1 millisecond and
    each task (audio, controller, etc) receive this 1 millisecond, and the buffer for video for example do this to generate the video

__________________________________________________________________________________________________________________________________________________________

TODO: read more about.
TODO: read about time slice
TODO: Read about callbacks -> promisses -> monads -> algebraic effects

In a system with a single processor, it is not possible to have
processes or threads truly executing at the same time. In this case,
the CPU is shared among running processes or threads using a process
scheduling algorithm that divides the CPU's time and yields the illusion
of parallel execution.

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/2c7e6d10-d8fc-4a2e-8584-3cb32fb889f3)


## Parallelism