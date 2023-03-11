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

***Thomaz notes =  For this example above***
```
Essa é uma função chamada `full_name` que recebe um registro `r` com três campos do tipo string: `first`, `middle` e `last`. A função faz uso do `case` e `pattern-matching` para extrair os valores de cada campo do registro.

O corpo da função possui uma expressão `case` que verifica o registro `r`. Se o registro corresponder ao padrão `{first = x, middle = y, last = z}`, então a função concatena os valores dos campos `first`, `middle` e `last`, separando-os por espaços, e retorna o nome completo como uma única string.

Por exemplo, se `r` for `{first="João", middle="da", last="Silva"}`, a função `full_name` irá retornar a string "João da Silva".
```

