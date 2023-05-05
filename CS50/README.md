# This is a course of Harvard for free "CS50 Introdution to Computer Sciece"

NUL = '\0'
NULL = is technically a pointer

## Bit and bytes 

bit = 0 or 1 (binary digits)

8 bits = 1 byte

## Types in bytes

bool = 1 byte

int = 4 bytes

long = 8 bytes

float = 4 bytes

double = 8 bytes

char = 1 byte

string = ? bytes

## Bitmap

Bitmap is a type of a image

`Why do image files need metadata?`

![image](https://user-images.githubusercontent.com/58439854/233751887-77bcabf6-7fa3-4616-b515-3a0911620fa0.png)

0000FF ij Photoshop means, 00 no red, 00 no green, and FF full(255) blue

# hexadecimal or base-16

in base-2 for binary = 0 and 1

In base-10 for decimal = we only use numbers `(0,1,2,3,4,5,6,7,8,9)`

Ib base-16 for hexadecimal = If we want to use more than 10 numbers, we use some letters `(0,1,2,3,4,5,6,7,8,9,A,B,C,D,E and F)`, this letters is case sensitive, so we can use in `UPPERCASE ` or `lowercase`

Why hexadecimal is useful ? Resume, is more succinct representation

        It is good to expressing binary numbers more succinctly with a fixed number of digits.
        For example, to we take 15 in binary in (1111), and to take 15 in hexadecimal (0F)

So for instance, any time we see 11111111 (8 bits of 1) in the world as binary.

We can represent more succinctly any group of four 1 bits more succinctly in hexadecimal as just F, and this is a 2 bits (FF).

`OBS= it is good to know, it is easier to read, but the computer understood we use 4 bits yet, so, with you use 0F to represent 15, the computer will read as 1111`

## Addresses

A image that represents a computer's memory. Each of these squares in this grid represents a bit and the computer read that top left to bottom right
![image](https://user-images.githubusercontent.com/58439854/233753956-db3331d1-60f8-4b4d-aa43-f43bfe0f634b.png)


We can just number them like this
![image](https://user-images.githubusercontent.com/58439854/233754138-9b22e73b-53f4-4716-85e8-abcbbedf52f2.png)

It is just more common in computer systems and in software to actually use hexadecimal just to describe the locations of, the addresses, of things in memory.

So instead a typical programmer or a computer scientist would call these first 16 bytes zero through F just because (remember the image above 15 is four bits -> 1111, and F it is to four bits F -> 1111).
![image](https://user-images.githubusercontent.com/58439854/233754296-f003c931-5d77-417c-9869-fd21814f21ce.png)
![image](https://user-images.githubusercontent.com/58439854/233754353-779fac03-2ffd-4ebb-b684-7e0cad46e077.png)

This can create potential confusion, especially if when we collaborating with another people (we want avoid that ambiguity).

And so the convetion humans decided on years ago  is that if you want to make clear that a number is in hexadecimal just by convention, you prefix all of the digits with '0x' like the image below.

OBS: It's just a human convention of putting `0x` to imply, here comes hexadecimal.
![image](https://user-images.githubusercontent.com/58439854/233754629-84314d0c-3e2c-44d1-9b56-284ed49533f2.png)

### Pointers

A pointer is an address of something in the computer's memory.

Ampersand = &

& = He is going to allow us to get the address of a piece of data in memory, example:
```c
int main (void)
{
        int x = 50;
        printf("%p\n", &x);
}
```
OBS: this is a ***example*** `Result is x01A`

and the `*` do the opposite, like "go there"

## Strings

How string works, with aátring is array os chars ?

Only take the first address of the first letter, and when the `NUL (\0)` comming, you know that all of those characters are apparently part of the same string.

Like an example, when we do that `string s = "hi!";`

![image](https://user-images.githubusercontent.com/58439854/233808409-98573d09-1af0-4166-b420-43df24711fe9.png)
![image](https://user-images.githubusercontent.com/58439854/233808420-2493f0bb-6944-4146-a038-704b5dfe2646.png)

So, string is a pointer to a char, like `char * s = "HI!"`;

## Copying

1. malloc = malloc is for memory allocation.

It is a function that you can use to ask operation system for some number of bytes, 1 byte, 100 bytes, a gigabyte of memory.

You can ask malloc for however much memory you want in advance. It will return to you the address of the first byte of memory, that it found free for you `unlike a string, it is not NUL termianted`

##### OBS: Malloc is just going to give you some memory and it's up to you to manage it.

2. Free does the opposite.

When you're done with some chunk of memory, you can free it by passing in that same address and just hand it back. You can let me use this for something else later.

____________________________________________________________________________

In this case it is a manual way of asking for enough memory for an array:

```c
#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int *x = malloc(3 * sizeof(int));

    int[0] = 72;
    int[1] = 73;
    int[2] = 33;
}
```

Why this happend ? Remember an int use 4 bytes ? So that is, this code `int *x = malloc(3 * sizeof(int));` is `give me an array 3 * however big an int is`

And the malloc whill return the address of the first byte you get back.

### Valgrind

It is a program to taka problem with memory, for example the last code above you can compile and run it, but he does not use **free** or **return** to free memory.

### Swap in C

If we try something like that (only function)

```c
void swap(int a, int b)
{
    int tmp = a;
    a = b;
    b = tmp;
}
```

This not will changed the value, because swap only changed this local variable not swapt the variable in memory.

The correst form in C is:

***OBS: to call this function you need to call this with ampersand (&) example `swap(&x, &y);`***

```c
void swap(int *a, int *b) // here in parameters means we want to receive a address of variables
{
    int tmp = *a;
    *a = *b;
    *b = tmp;
}
```


### ScanF

 We uso a ampersand in a float, a double, a long, a bool, a char.

 Why we not need to use in string case ? 

        Because the strings is already an address. String is always a address


In the string case, ir harder because we need understand and use malloc for each letter the user used

`REMBER FOR ME, TO REMEMBER TO LEARNING ABOUT THAT IN SOME TIME`


### Stacks and Queues (abstract data types)

Push = adding things to a stack

Pop = removing something also from the top of the stack.

Implementing the data structure itself.

- Struct means here comes a structure, A.K.A a data structure of one or more vaiables within
```c
typedef struct
{
    // Just estipulate the struct person already exists, is only example
    // And capacity means a const variable
    person people[CAPACITY]
    int size;
}
stack;
```