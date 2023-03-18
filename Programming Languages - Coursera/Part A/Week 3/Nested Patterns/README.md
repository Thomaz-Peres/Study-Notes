**After read that, you can se some examples of nested patterns here:** [Useful_Example_Of_Nested_Patterns](Useful_Example_Of_Nested_Patterns.md)

- We can nest patterns as deep as we want.
- Often avoids hard-to-read, wordy nested case expressions.
- More precise recursive definitions.

It turns out the definition of patterns is recursive: anywhere we have been putting a variable in our patterns, we can instead put another pattern.

The semantics of pattern-matching is that the value being matched must have the same "shape" as the pattern and variables are bound to the "right pieces". 
Until here, is very hand-wavy explanation which is why a precise definition is described below.

Examples:

- The pattern `a::(b::(c::d))` would match any list with at least 3 elements and it would bind `a` to the first element, `b` to the second, `c` to the third, and `d` to the list holding all the other elements (if any).
	- ![image](https://user-images.githubusercontent.com/58439854/225187105-d830660b-46e1-4bee-b63d-6d7b21b80f21.png)
- The pattern `a::(b::(c::[]))` would match only lists with exactly three elements.
	- ![image](https://user-images.githubusercontent.com/58439854/225187185-7c64bbd4-539c-4343-8867-9e5140d2fed0.png)
- Another nested patterns is `(a,b,c)::d`, which matches any non-empty list of triples, binding `a` to the first component of the head, `b` to the second component of the head, `c` to the third component of the head, and `d` to the tail of the list.
--------
In general, pattern-matching is about taking a value and a pattern and:
1. Decigin if the pattern matches the value, and
2. If so, binding variables to the right parts of the value.
Here are some key parts to the elegant recursive definition of pattern matching:
- A variable pattern (x) matches any value `v` and introduces one binding (from `x` to `v`).
- The pattern `C` matches the value `C`, if `C` is a constructor that carries no data.
- The pattern `C p` where `C` is a constructor and `p` is a pattern matches a value of the form `C v` (notice the constructors are the same) if `p` matches `v` (i.e. (ou seja), the nested pattern matches the carried value). It introduces the bindings that `p` matching `v` introduces.
- The pattern `(p1, p2, ..., pn)` matches a tuple value `(v1, v2, ..., vn)` if `p1` matches `v1`, and `p2` matches `v2` and `pn` matches `vn`. It introduces all the bindings that the recursive matches introduce.
- (A similar case for record patterns of the form {f1=p1, ... , fn=pn} ...).
---

This recursive definition extends our previous understanding in two interesnting ways. First, for a constructor `C` that carries multiple arguments, we do not have to write patterns like `C(x1, ..., xn)` though we often do. We could also write `C x;` this would bind `x` to the tuple that the value `C(v1, ..., vn)` carries.
What is really going on is that all constructors take 0 or 1 arguments, but the 1 argument can itself be a tuple. So `C(x1, ..., xn` is really a nested pattern where the `(x1, ..., xn)` part is just a pattern that matches all tuples with `n` parts. Second, and more importantly, we can use nested patterns instead of nested case expressions when we want to match only values that have a certain "shape".

There are additional kinds of patterns as well. Somentimes we do not need to bind a variable to part of a value. For example, consider this function for computing a list's length;

```sml
fun les xs =
	case xs of
		[] => 0
	| x::xs' => 1 + len xs'
```

We do not use the variable `x`. In such cases, it is better style not to introduce a variable.
Instead, the `wildcard pattern` *_* matches everyrhing (just like a variable pattern matches everything), but does not introduce a binding.  So we would write:
```sml
fun len xs =
	case xs of
		[] = 0
	| _::xs' => 1 + len xs'
```
In terms of our general definition, wildcard patterns are straightforward:
- A wildcard pattern `(_)` matches any value `v` and introduces no bindings.

Lastly, you can use integer constants int patterns. For example, the pattern 37 matches the value 37 and introduces no bindings.