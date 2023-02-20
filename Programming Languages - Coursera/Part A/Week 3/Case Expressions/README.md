# How ML Provides access to Datatype Values: Case Expressions

The better thing is a case expression. Here is a basic example for our example datatype binding

```sml
(* f has type MyType -> int *)
fun f x =
    case x of
        Pizza => 3
        | TwoInts(i1, i2) => i1 + i2
        | Str s => String.size s
```

In one sense, a case-expression is like a more powerful if-then-else expression.

Each branch has the form p => e where `p` is a `pattern` and `e` is an `expression`, and we separate the branches with the | character.
Patterns look like expressions, but do not think of them as expressions. Instead they are used to match against the result of evaluating the case’s first expression (the part after case). This is why evaluating a case-expression is called `pattern-matching`.

## Why are case-expressions better than functions for testing variants and extracting pieces?

- We can never "mess up" and try to extract something from the wrong variant. That is, we will not get exceptions like we get with __hd []__.
- If a case expressions forgets a variant, then the type-checker will give a warning message. This indicates that evaluating the case-expressions could find no matching branch, in which case it will raise an exception. If you have no such warnings, then you know thid does not occur.
- If a case expressions uses a variant twice, then the type-checker will give an error message since one of the branch could never possibly be used.
- If you still want functions like __null__ and __hd__, you can easily write them yourself (but do not do so for your homework).
- Pattern-matching is must more general and powerful than we have indicated so far. We give the "whole truth" about pattern-matching below.