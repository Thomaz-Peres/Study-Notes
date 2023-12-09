Pattern-Matching for Each-Of Types: The truth about val-bindings

We have used pattern-matching for one-of types (for val), but we can use it for eacg0of types also.
Given a record value {f1=v1, ...,fn=vn}.

As before, tuples are syntactic sugar for records: is the same as {1=v1, ..., n=vn}. So we could write this function for summing the three parts of an ***int * int * int*** :

```sml
fun sum_triple (triple : int * int * int) = 
	case triple of 
		(x, y, z) => z + y + x
```

And a similar example with records (and ML's string-concatenation operator) could look like this:

```sml
fun full_name (r : {first: string, middle: string, last: string}) =
	case r of 
		{first = x, middle = y, last = z} => x ^ " " ^ y ^ " " ^z
```

-------
***Thomaz notes =  For this example above***
```
Essa é uma função chamada `full_name` que recebe um registro `r` com três campos do tipo string: `first`, `middle` e `last`. A função faz uso do `case` e `pattern-matching` para extrair os valores de cada campo do registro.

O corpo da função possui uma expressão `case` que verifica o registro `r`. Se o registro corresponder ao padrão `{first = x, middle = y, last = z}`, então a função concatena os valores dos campos `first`, `middle` e `last`, separando-os por espaços, e retorna o nome completo como uma única string.

Por exemplo, se `r` for `{first="João", middle="da", last="Silva"}`, a função `full_name` irá retornar a string "João da Silva".
```
-------


However, a case-expressions with one branch is poor style -- it looks strange because the purpose of such expressions is to distinguish `cases`, plural.

So how should we use pattern-matching for `each-of` types, when we know that a single pattern will definitely match so we are using pattern-matching just for the convenient extraction of values? It turn out you can use patterns in val-bindings too! So this approach is better style:

```sml
fun full_name (r : {first:string,middle:string,last:string}) =
    let val {first=x,middle=y,last=z} = r
    in
        x ^ " " ^ y ^ " " ^z
    end

<!-- The function above, x,y,z receive the value from variable first, middle and last -->

fun sum_triple (triple : int * int * int) =
	let val (x,y,z) = triple
	in
		x + y + z
	end

<!-- and for this function above (sum_triple) x,y,z receive in order of the int because we don't specify name in variable like sum_triple (triple: int, two : int...) -->
```

----
***Thomaz notes again because my brain bug this time (in the night i need to sleep)***
```
Nos ainda podemos fazer melhor, como um pattern pode ser usado in a `val-binding` to bind variables (usar val-binding pra definir valores em uma variavel) como no exemplo de triple, onde usamos o val-binding para definir os valores de `x,y,z` respectivamente com os valores que recebemos de `int*int*int`.

Podemos usar um pattern ao definir uma function binding e o pattern vai ser usado para introduzir essas bindings(definir) correspondentes ao valor passado quando a função é chamada. 
```
------- 
So here is the third and best approach for our example functions:
```sml
fun full_name {first=x, middle=y, last = z} =
	x ^ " " ^ y ^ " " ^z

fun sum_triple (x,y,z) = 
	x + y + z
```

Indeed, is the type `int * int * int -> int` for three-argument functions or for one argument functions that take triples?

`It turns out we have been basically lying: There is no such thing as a multi-argument function in ML: Every function in ML takes exactly one argument!`

Every time we write multi-argument function, we are really writing a one-argument function that takes a tuple as an argument and uses pattern-matching to extract the pieces.

In term of the actual language definition, ir really is a one-argument function: syntactic sugar for expading out to the first version of **sum_triple** with a one-arm case expressions.

This flexibility is sometimes useful. In languages like C and Java, you can not have one function/method compute the result that are immediately passed to another multi-argument function/method. But with one-argument functions that are tuples, this works fine. Here is a silly example where we "rotate a triple to the right" by "rotating it to the left twice":

```sml
fun rotate_left(x,y,z) = (y,z,x)

fun rotate_right triple = rotate_left(rotate_left triple)
```

More generally, Can compute tuples and then pass them to functions even if the writer of that function was thinking in terms of multiple arguments.

----
Zero-arguments functions not existe either, The binding `fun f () = e` is using the unit-pattern `()`, `()` is the only value of type `unit`.

The type unit is just a datatype with only one constructor, which takes no arguments and uses the unusual syntas `()`. Basically, `datatype unit = ()` comes pre-defined.

