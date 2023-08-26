# Data and Functions

In coq, having defined a function, we should next check that it works on some examples

Having defined a function, we should next check that it works on some examples. There are actually three different ways to do the examples in Coq. First, we can use the command `Compute` to evaluate a compound expression involving `next_weekday (explication.v file)`.

- Conditional expressions

Coq's conditionals are exactly like those found in any other language, with one small generalization. Since the bool type is not built in, Coq actually supports conditional expressions over any inductively defined type with exactly two clauses in its definition. The guard is considered true if it evaluates to the "constructor" of the first clause of the Inductive definition (which just happens to be called true in this case) and false if it evaluates to the second

with the first constructor considered true and the second constructor considered false.

Example:
`if <condition> then constructor1 else constructor2`

### Admitteds

Admitteds can be used as a placeholder for an incomplete proof.

_____________________________________________________________________
The arrow is receive bool, another bool, and return bool (bool -> bool -> bool)


![image](https://github.com/Thomaz-Peres/Thomaz-Peres/assets/58439854/e00fbddd-3911-4853-bd69-1e5437526819)