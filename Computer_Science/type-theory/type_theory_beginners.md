It's this youtube [video](https://www.youtube.com/watch?v=AJ-yQEfvdVc&t=726s&ab_channel=Jfokus)


Programmin languages use a type system to look at a program and determine if a represetation error will happen or not.


What are the possible stategies that a type system can use to handle representation errors ?

> Representation errors: All languages have *Data* and *Operations*. If you use a incompatible pieces of data for an operation, you will have a ***Representation Error***.


# Strategies.

(This order means nothing)

1. **Strong**
    - Genereate a compile error
    - Perform a type check before run the code.
    - Well defined error set (example: exceptions)

2. **Weak**
    - Unpredictable runtime errors.
    - Try implicit conversion
3. **Static**
    - A compiler tags pieces of code and tries to infer the behavior will be valid or not (before the program runs)
4. **Dynamic**
    - A compiler/interpreter to generates code to keep track of the data.


Assembly is a language where not use nothing.

Languages can have more than one.

Examples:

- C# is static and strong.
- Python is dynamic.
- JS weak.


Type theory is also about proofing statements in a precise way.

In order to do a deep analysi of a language:

1. Collect all the keywords and analyse the grammar for each of these works individually.


2. Make it look like mathematics - Replace text with variables.
