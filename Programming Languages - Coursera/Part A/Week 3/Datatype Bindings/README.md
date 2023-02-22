# Datatype Bindings: Our Own "One-Of" Types.

We start with a silly but simple example because it will help us see the many different aspects of a datatype binding. We can write:

        datatype mytype = TwoInts of int * int
        | Str of string
        | Pizza

Roughly, this defines a new type where values have an ***int * int or a string or nothing***. Any value will also be “tagged” with information that lets us know which variant it is: These “tags,” which we will call constructors, are TwoInts, Str, and Pizza. Two constructors could be used to tag the same type of underlying data; in fact this is common even though our example uses different types for each variant


More precisely, the example above adds four things to the environment:
- A new type mytype that we can now use just like any other type
- Three constructors TwoInts, Str, and Pizza


A constructor is two different things. First, it is either a function for creating values of the new type (if the variant has of t for some type t) or it is actually a value of the new type (otherwise). In our example, `TwoInts is a function of type int*int -> mytype`, `Str is a function of type string -> mytype` and `Pizza is a value of type mytype`. Second, we use constructors in case-expressions as described further below.

![image](https://user-images.githubusercontent.com/58439854/218908319-898ad7db-0020-435a-a251-e6898ba05ddb.png)

# Using this datypes and access the values (How ML Does Not Provide Access to Datatype Values)

`OBS: for me at this time and my english, it is little hard to understand, so i save all the text in the document, here`

***The thing thing the text use is a [Case Expressions](../Case%20Expressions/README.md)***

Given a value of type mytype, how can we access the data stored in it? First, we need to find out which
variant it is since a value of type mytype might have been made from TwoInts, Str, or Pizza and this
affects what data is available. Once we know what variant we have, then we can access the pieces, if any,
that variant carries.

Recall how we have done this so for lists and options, which are also one-of types: We had functions for
testing which variant we had (null or isSome) and functions for getting the pieces (hd, tl, or valOf), which
raised exceptions if given arguments of the wrong variant.

ML could have taken the same approach for datatype bindings. For example, it could have taken our
datatype definition above and added to the environment functions isTwoInts, isStr, and isPizza all of
type mytype -> bool. And it could have added functions like getTwoInts of type mytype -> int*int and
getStr of type mytype -> string, which might raise exceptions.

But ML does not take this approach. Instead it does something better. You could write these functions
yourself using the better thing, though it is usually poor style to do so. In fact, after learning the better
thing, we will no longer use the functions for lists and options the way we have been — we just started with
these functions so we could learn one thing at a time

`I asked to ChatGPT to translate the the above for me to Portuguese`

Dado um valor do tipo mytype, como podemos acessar os dados armazenados nele? Primeiro, precisamos descobrir qual variante é, uma vez que um valor do tipo mytype pode ter sido criado a partir de TwoInts, Str ou Pizza e isso afeta quais dados estão disponíveis. Assim que soubermos qual variante temos, podemos acessar as partes, se houver, que a variante carrega.

Lembre-se de como fizemos isso para listas e opções, que também são tipos one-of: tínhamos funções para testar qual variante tínhamos (nulo ou isSome) e funções para obter as partes (hd, tl ou valOf), que geravam exceções se fossem dados argumentos da variante errada.

ML poderia ter adotado a mesma abordagem para as vinculações de tipos de dados. Por exemplo, poderia ter levado nossa definição de tipo de dados acima e adicionado ao ambiente funções isTwoInts, isStr e isPizza, todas do tipo mytype -> bool. E poderia ter adicionado funções como getTwoInts do tipo mytype -> int*int e getStr do tipo mytype -> string, que poderiam gerar exceções.

Mas ML não adota essa abordagem. Em vez disso, faz algo melhor. Você poderia escrever essas funções por conta própria usando a coisa melhor, embora geralmente seja considerado um estilo ruim fazê-lo. Na verdade, depois de aprender a coisa melhor, não usaremos mais as funções para listas e opções da maneira como fizemos - apenas começamos com essas funções para aprender uma coisa de cada vez.