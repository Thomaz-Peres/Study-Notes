# How does a CPU Work ?


A CPU reads instructions from somewhere in memory that tell it what to do. A CPU may be really fast but it's stupid.

Usually, it's encodes an operation and relevant data into a number that a machine can read. For example, consider this instruction for the [CPU inside of the original Game Boy:](https://gbdev.io/gb-opcodes/optables/) `C622`.

In this case, the first byte (C6) says `ADD to Register A`, and the second byte (22) is the value that will be added to Register A. So this instruction says `Add 22 to Register A.`

The assembly program would have `ADD VA, 22`, and the assembler would translate that to `C622`. Which the Game Boy can read.

> The assembly would translate their human-readable assembly into the 1s and 0s that the computer could understand.


## Emulator

An emulator reads the original machine code instructions that were assembled for the target machine, interprets them, and then replicates the functionality of the target machine on the host machine. The ROM files contain the instructions, the emulator reads those instructions, and then does work to mimic the original machine.


When an emulator reads the instruction `C622`, it would emulate the behavior of the Game Boy by doing something like this:

``` registers[0xA] += 0x22```
