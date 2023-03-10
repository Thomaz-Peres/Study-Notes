# Lists and Options are Datatypes

Because datatype definitions can be recursive, we can use them to create our own types for lists.

For example, this binding works well for a linked list of integers.

```sml
datatype my_int_list = Empty | Cons of int * my_int_list
```

We can use the constructors **Empty** and **Cons** to make values of my_int_list and we can use case expressions to use such values:

```sml
val one_two_three = Cons(1,Cons(2,Cons(3,Empty)))

fun append_mylist (xs, ys) = 
	case xs of 
		Empty => ys
	| Cons(x, xs) => Cons (x, append_mylist(xs, ys));
```

It turns out the lists and options “built in” (i.e., predefined with some special syntactic support) are just datatypes. As a matter of style, it is better to use the built-in widely-known feature than to invent your own.

------

More importantly, it it better style use pattern-matching for accessing list and option values, **not** the function **null, hd, tlk, isSome and valOf** we saw previously.

For **options**, all you need to know is **SOME** and **NONE** are constructors, which we use to create values (just like before) and in patterns to acccess the values. Here is a shot example of the latter:

```sml
fun inc_or_zero intoption =
	case intoption of
		NONE => 0
	  | SOME i => i+1
```

------
### Lists
The story for lists is similar with a few convenient syntactic peculiarities: [] really is a constructor that carries nothing and :: really is a constructor that carries two things, but :: is unusual because it is an infix operator (it is placed between its two operands), both when creating things and in patterns:

```sml
fun sum_list xs = case xs of [] => 0 | x::xs’ => x + sum_list xs’

fun append (xs,ys) = case xs of [] => ys | x::xs’ => x :: append(xs’,ys)
```

Notice here x and xs’ are nothing but local variables introduced via pattern-matching. We can use any names for the variables we want. We could even use hd and tl — doing so would simply shadow the functions predefined in the outer environment.

The reasons why you should usually prefer pattern-matching for accessing lists and options instead of functions like null and hd is the same as for datatype bindings in general: you cannot forget cases, you cannot apply the wrong function, etc. So why does the ML environment predefine these functions if the approach is inferior? In part, because they are useful for passing as arguments to other functions, a major topic for the next section of the course.