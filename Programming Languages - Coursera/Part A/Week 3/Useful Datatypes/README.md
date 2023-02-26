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
{ student_num : int,
  first : string,
  middle : string option,
  last : string }
```

- This approach requires all the code to follow the rules in the comment, with no help from the type-checker. It also wastes space, having fields in every record that should not be used.

-------------------------------------------------------------------------

On the other hand, each-of types are exactly the right approach if we want to store for each student their id-number (if they have one) and their full name:

```sml
{ student_num : int option,
  first : string,
  middle : string option,
  last : string }
```

-------------------------------------------------------------------------

Our last example is a data definition for arithmetic expressions containing constants constants, negationx, additions and multiplications.

```sml
datatype ex = Const of int | Negate of exp | Add of exp * exp | Multiply of exp * exp
```

-------------------------------------------------------------------------

Thanks to the self-reference, what this data definition really describes is trees where the leaves are integers and the internal nodes are either negations with one child, additions with two children or multiplications with two children. We can write a function that takes an exp and evaluates it:

```sml
fun eval e =
    case e of
        Constant i => i |
        Negate e2 => ~ (eval e2) |
        Add(e1, e2) => (eval e1) + (eval e2) |
        Multiply(e1, e2) => (eval e1) * (eval e2)
```

` OBS: Note Constant, Negate, Add and Multiply are constructors, and work like a function`

![image](https://user-images.githubusercontent.com/58439854/221384278-8a25b8b4-0715-4021-a894-91b401a6362f.png)

![image](https://user-images.githubusercontent.com/58439854/221384286-55430331-c8e9-4630-b85b-7bd0c2cb31fa.png)

```sml
fun number_of_add e =
    case e of
        Constant i => 0 |
        Negate e2 => number_of_adds e2 |
        Add(e1, e2) => 1 + number_of_adds e1 + number_of_adds e2 |
        Multiply(e1, e2) => number_of_adds e1 + number_of_adds e2
```