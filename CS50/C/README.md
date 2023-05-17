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

## Pointers

***IMPORTANT OBSERVATION: A POINTER USE 8 BYTES OF MEMORY ***

A pointer is an address of something in the computer's memory.

Ampersand = `&`

& = He is going to allow us to get the address of a piece of data in memory, example:
```c
int main (void)
{
        int x = 50;
        printf("%p\n", &x);
}
```
OBS: this is a ***example*** `Result is x01A`

and the `*` do the opposite, like "go there" , declare pointers and for dereference pointer.

OBS: If you prematurely change a variable to point not at the old chunk but the new chunk at that point no one's pointing at the old chunk, you lost that part of memory

## Strings

How string works, with aátring is array os chars ?

Only take the first address of the first letter, and when the `NUL (\0)` comming, you know that all of those characters are apparently part of the same string.

Like an example, when we do that `string s = "hi!";`

![image](https://user-images.githubusercontent.com/58439854/233808409-98573d09-1af0-4166-b420-43df24711fe9.png)
![image](https://user-images.githubusercontent.com/58439854/233808420-2493f0bb-6944-4146-a038-704b5dfe2646.png)

So, string is a pointer to a char, like `char * s = "HI!"`;

## Copying strings

1. malloc = malloc is for memory allocation.

It is a function that you can use to ask operation system for some number of bytes, 1 byte, 100 bytes, a gigabyte of memory.

You can ask malloc for however much memory you want in advance. It will return to you the address of the first byte of memory, that it found free for you `unlike a string, it is not NUL termianted`

        OBS1: Malloc is just going to give you some memory and it's up to you to manage it.

        OBS2: Malloc can return null if the computer is out of memory.


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

## Valgrind

It is a program to taka problem with memory, for example the last code above you can compile and run it, but he does not use **free** or **return** to free memory.

## Swap in C

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


## ScanF

 We uso a ampersand in a float, a double, a long, a bool, a char.

 Why we not need to use in string case ? 

        Because the strings is already an address. String is always a address


In the string case, ir harder because we need understand and use malloc for each letter the user used

`REMBER FOR ME, TO REMEMBER TO LEARNING ABOUT THAT IN SOME TIME`


## Stacks and Queues (abstract data types)

Push = adding things to a stack

Pop = removing something also from the top of the stack.

Implementing the data structure itself.

- Struct means here comes a structure, A.K.A a data structure of one or more vaiables within.
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


## Resizing arrays

In the file [list](./list.c), instead of using malloc for the second time on line 18, we can use **realloc**

**Realloc** works different of malloc, we need two arguments.
        
        The first one is what is the chunk of memory that we want to try to grow or shrink, that is, reallocate to be a different size.

        The second we specify what size you would want.

**Realloc** will copy everything.

**Realloc** automatically frees the previous memory for you.

So, the new code on [list](./list.c) will gonna be like this:

```c
int main(void)
{
    int *list = malloc(3 * sizeof(int));
    if (list == NULL)
    {
        return 1;
    }

    list[0] = 1;
    list[1] = 2;
    list[2] = 3;

    // Creating and improve the range of list

    int *tmp = realloc(list, 4 * sizeof(int));
    if(tmp == NULL)
    {
        free(list);
        return 1;
    }

    list = tmp;

    list[3] = 4;


    for(int i = 0; i < 3; i++)
    {
        printf("%i\n", list[i]);
    }

    free(list);
    return 0;
}
```

## Linked lists

The arrow `->` go to the struct and take the address of these value on the struct

Linked lists is create a struct for have a number and a place to show the address of memory the next number

![image](https://user-images.githubusercontent.com/58439854/236974609-0a41867f-8f4c-4a6a-aaf3-ebc0ab29402c.png)

creating a struct in `C` for this list

```c
typedef struct
{
    int number;
    node *next;
}
node;
```

This code below, give error, we need create a self-reference like this in `C`

```c
typedef struct node
{
    int number;
    struct node *next;
}
node;
```
After we create that we need use them

1. Create a list

        node *list = NULL;

2. Allocate the first number

        node *n = malloc(sizeof(node));

3. Adding a number in `N`

    OBS: We have used (*n) to preserved the operation 

        (*n).number = 1;

4. A better syntax to not use `(*n).number` is:

        n->number = 1;

5. Adding next like `NULL` because at this point, doesn't have next number

        n->next = NULL;

6. For the first number, i can do that:

        list = n;

7. For adding the number 2 now, we do the same steps below, BUT we need to link the variable `NEXT` in number `1` with the address of number `2`.
    So here, I do that:

        n->next = list;

something like this: ![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/ac4c5e20-3e0a-40f2-b0de-54fd3d34d469)

8. And after that, I can do `list = n`

    Like this: ![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/a3322490-2334-4efd-9909-e30e32386cf1)


With linked list we have this dynamism now where we can grow and shrink our chunks of memory without over-allocating or accidentally under-allocating as in the world of an array.

## Trees

the downside of a tree is use lot of memory

`Tree` take the best of both words the dynamism of a linked list with speed of binary search, somenthing logarithmic.

The code for a `tree` is not very different for the code of a linked list.

How looks like a node in a image:
![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/4a2fa53f-3215-4d71-8aaa-6b85c49e0885)

```c
typedef struct node
{
    int number;
    struct node *left;
    struct node *right;
}
node;
```

creating a tree search example:

```c
bool search(node *tree, int number)
{
    if (tree == NULL)
        return false;
    else if (number < tree->number)
        return search(tree->left, number);
    else if (number > tree->number)
        return search(tree->right, number);
    else
        return true;
}
```

## Dictionaries

dictionary is an array with `key` and `value`, like this:

 key | value
---- | -----
name | number

## Hashing

Hash is a `O(1)` data structure

`Hashing` is all about taking as input some value and outputting a simpler version thereof.

Converting something bigger to something smaller to this indeed finite range of values.

The hash has a certain thing, for example, if I search to a name with `Z` I go to the 25 and take `Z`

the example of hash in an image:

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/9548136b-bb2f-4012-897c-4982041171c4)

## Tries

The `tries` looks like a `tree` with a `hash table`. The image will show how it's work

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/755ffa8b-c1c9-450f-a3e6-eec4e94e3984)

And we need to say what is the final, is this case is D of `Hagrid`, so when we arrive to `D` we return a true or something to say `Is the final`, example:

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/a6cc1fc3-6f75-4916-b74d-5c08ff0196f5) 

What do each of these nodes look like in a tri

```c
typedef struct node
{
    char *number;
    struct node *children[26];
}
node;
```