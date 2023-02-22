# Useful Examples of "One-of" Types

Let us now consider several examples where “one-of” types are useful, since so far we considered only a silly
example.

`First, they are good for enumerating a fixed set of options – and much better style than using, say, small
integers. For example`

```sml
datatype suit = Club | Diamond | Heart | Spade
```
-------------------------------------------------------------------------
Many languages have support for this sort of enumeration including Java and C, but ML takes the next step
of letting variants carry data, so we can do things like this:

```sml
datatype rank = Jack | Queen | King | Ace | Num of int
```

We can then combine the two pieces with an each-of type: __suit__ * __rank__

-------------------------------------------------------------------------
One-of types are also useful when you have different data in different situations. For example, suppose you want to identify students by their id-numbers, but in case there are students that do not have one (perhaps they are new to the university), then you will use their full name instead (with first name, optional middle name, and last name). This datatype binding captures the idea directly:

```sml
datatype id = StudentNum of int
| Name of string * (string option) * string
```
Unfortunately, this sort of example is one where programmers often show a profound lack of understanding of one-of types and insist on using each-of types, which is like using a saw as a hammer (it works, but you are doing the wrong thing). __Consider BAD code like this:__

```sml
(* If student_num is -1, then use the other fields, otherwise ignore other fields *)
{ student_num : int, first : string, middle : string option, last : string }
```