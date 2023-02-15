# Datatype Bindings: Our Own "One-Of" Types.

We start with a silly but simple example because it will help us see the many different aspects of a datatype binding. We can write:

        datatype mytype = TwoInts of int * int
        | Str of string
        | Pizza

Roughly, this defines a new type where values have an ***int * int or a string or nothing***. Any value will also be “tagged” with information that lets us know which variant it is: These “tags,” which we will call constructors, are TwoInts, Str, and Pizza. Two constructors could be used to tag the same type of underlying data; in fact this is common even though our example uses different types for each variant


More precisely, the example above adds four things to the environment:
- A new type mytype that we can now use just like any other type
- Three constructors TwoInts, Str, and Pizza


A constructor is two different things. First, it is either a function for creating values of the new type (if the variant has of t for some type t) or it is actually a value of the new type (otherwise). In our example, `TwoInts is a function of type int*int -> mytype`, `Str is a function of type string -> mytype` and `Pizza is a value of type mytype`. Second, we use constructors in case-expressions as described further below.