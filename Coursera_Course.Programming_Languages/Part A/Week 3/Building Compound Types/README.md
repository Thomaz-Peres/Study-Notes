# Conceptual Ways to build new types

In this segmente, is give a general way to think abou how to build new types.

This class is going to be more general than even in ML.


Existem base types and compound types(tipos compostos)

Base types (describe sort of the basic values in your langugage):

- int
- bool
- unit
- char
- real
-------------------------------------------------------------------------
Compund types (it is when we create new types with other types inside him):

- Tuples
- Lists
- Options
-------------------------------------------------------------------------
To create a compound type, there are really only three essential building blocks. Any decent programming language provides these building blocks in some way

        As a matter of jargon you do not need to know, the terms “each-of types,” “one-of types,” and “self-reference types” are not
        standard – they are just good ways to think about the concepts. Usually people just use constructs from a particular language
        like “tuples” when they are talking about the ideas. Programming-language researchers use the terms “product types,” “sum
        types,” and “recursive types.” Why product and sum? It is related to the fact that in Boolean algebra where 0 is false and 1
        is true, and works like multiply and or works like addition.


- __“Each-of”__: A compound type t describes values that contain each of values of type t1, t2, ..., and tn.
- __“One-of”__: A compound type t describes values that contain a value of one of the types t1, t2, ..., or tn.
- __“Self-reference”__: A compound type t may refer to itself in its definition in order to describe recursive data structures like lists and trees.


Naturally, since compound types can nest, we can have any nesting of each-of, one-of, and self-reference. For
example, consider the type (int * bool) list list * (int option) list * bool.