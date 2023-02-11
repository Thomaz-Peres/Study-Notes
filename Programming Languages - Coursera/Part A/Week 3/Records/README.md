# Records: Another Approach to "Each-Of" Types

Record types are “each-of” types where each component is a named field. For example, the type {foo : int, bar : int*bool, baz : bool*int} describes records with three fields named foo, bar, and baz.

It's like tuples.

Example:

- Create variable:
        
        val x = {bar = (1+2,true andalso true), foo = 3+4, baz = (false,9) };
- Variable type:

        val x = {bar=(3,true),baz=(false,9),foo=7}
        : {bar : int * bool, baz : bool * int, foo : int}


The order of fields never matter. (The SML language always alphabetizes order)

To access their records:


```sml
val x = {bar = (1+2,true andalso true), foo = 3+4, baz = (false,9) };

access:
#foo;
        Result = 7