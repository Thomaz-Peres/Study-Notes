# Digression: Polymorphic Types and Equality Types

Polymorphic types as read with one aposthophes like `'a`. 

But you may also see type variables with two leading apostrophes, like `''a`.
These are called `Equality Types` and they are fairly strange feature of ML not relevant to our current studies. Basically, the `=` operation in ML.

A type like `''a` can only have an "equality type" substituted for it.

```sml
(*has type ''a * ''a ->s string)
fun same_thing(x,y) = 
	if x=y
	then "yes"
	else
	"no"

(* has type int -> string *)
fun is_three x =
	if x=3
	then "yes"
	else
	"no" 
```

If you write a function that the REPL gives a more general type to than you need, that is okay.
Also remember, as discussed above, that it is also okay in the REPL uses different type synonyms than you expect.