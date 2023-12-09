# By Name vs. By Position, Syntactic Sugar and The Truth About Tuples.

**OBS:** Syntactic sugar is usually a shorthand for a common operation that could also be expressed in an alternate, more verbose, form


Abstractly, an array reference is a procedure of two arguments: an array and a subscript vector, which could be expressed as `get_array(Array, vector(i,j))`. Instead, many languages provide syntax such as `Array[i,j]`

_____________________________________

Records and tuples are very similar and they are bioth "each-of" type.

The only real difference is records are "by name" and tuples are "by positions" 

Tuples is not more not less then records with particular field names.

- When you write (e1,...,en), it is another way of writing {1=e1,...,n=en}, i.e., a tuple expression is a record expression with field names 1, 2, ..., n

- The type t1 * ... * tn is just another way of writing {1:t1, ..., n:tn}.

- Notice that #1 e, #2 e, etc. now already mean the right thing: get the contents of the field named 1,
2, etc.


_____________________________________

This is the first of many examples we will see of syntactic sugar. We say, “tuples are just syntactic sugar for records with fields named 1, 2, ..., n.”

- It is syntactic because we can describe everything about tuples in terms of equivalent record syntax.
- It is sugar because it makes the language sweeter


Syntactic sugar is a great way to keep the key ideas in a programming-language small (making it easier to implement) while giving programmers convenient ways to write things