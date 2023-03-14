# Digression: Type inference

Resumo rapido em PT (I will translate that after, or not k): Inferencia apenas resume a função pra fazer o que ela precisa, um exemplo e a sum_triple abaixo, a gente sabe que ela quer somar tres numeros:
```sml
fun sum_triple(x,y,z) =
	x + y + z
```

`OBS: That can lead to surprisingly general types.`

By using pattern to access values of tuples and records rathe than `#foo`, you will find it is no longer necessary to write types on your function arguments.

In ML, every variable and function has a type (or your program fails to type-check) -- type inference `only` means you do not need to write down the type.

It is often better sttyle to write these less cluttered versions, where again the last one is the best:

```sml
fun sum_triple triple =
	case triple of
		(x,y,z) => z + y + x

fun sum_triple triple =
	let val (x,y,z) = triple
	in
		x + y + z
	end

(*the best version*)
fun sum_triple(x,y,z) =
	x + y + z
```

This version needs an explicit type on the argument:
```sml
fun sum_triple (triple: int * int * int)
	#1 triple + #2 triple + #3 triple
```
The reason is the type-checker cannot take:
```sml
fun sum_triple triple =
	#1 triple + #2 triple + #3 triple
```

If you do not use `#`, ML almost never requires explicit type annotations thanks to the convenience of type inference.

-------
In fact, type inference sometimes reveals that functions are more general than you might have thought.

Consider this code, which does use part of a tuple/record:

```sml
fun partial_sum(x,y,z) = x + z

fun partial_name {first=x, middle=y, last=z} = x ^ " " ^ z
```

In both cases, the inferred function types reveal that the type of `y` can be `any` type, so we can call `partial_sum( 3, 4, 5)` or `partial_sum(3, false, 5)/`

![image](https://user-images.githubusercontent.com/58439854/224590881-517cb55b-40cc-4d94-abd2-31cab7d66117.png)

We will discuss these `polymorphic functions` as well as how `type inference` works in futrure sections because they are major course topics in their own right. For now, just stop using `#`, stop writing argument types, and do not be confused if you see the occasional type like `'a` or `'b` due to type inference, as discussed a bit more next...