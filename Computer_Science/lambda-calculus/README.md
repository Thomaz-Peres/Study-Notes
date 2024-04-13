# Lambda Calculus

Lambda ($\lambda$) calculus, normally is used for computation based on function abstractions and application using variable binding and substitution.

Can be used to simulate any Turing Machine.

Lambda calculus consists in construct lambda terms and perform reduction operation on them.

In the simplest form of lambda calculus, terms are built using only the following rules.

1. $x$: A variable is a character or string representing a parameter.
2. $(\lambda x.M)$: A lambda abstraction if a function definition, taking as input the bound variable $x$ (between the $\lambda$ and the punction/dot **.**) and returning the body $M$.
3. $(M \ N)$: An application, applying a function $M$ to an argument $N$. Both $M$ and $N$ are lambda terms.

The reduction operation include:

- $(\lambda x.M[x]) \to (\lambda y.M[y])$: $\alpha$-conversion,  renaming the bound variables in the expression. Used to avoid name collisions.
- $((\lambda x.M) N) \to (M [x := N])$: $\beta$-reduction, replacing the bound variables with the argument expression in the body of the abstraction.


## Motivation

Lambda calculus treats functions "anonymously". It does not give them explicit names. For example, the function:

$square_sum(x, y) = x^2 + y^2$

Can be rewritten in *anonymous* form as

$(x, y) \mapsto  x^2 + y^2$

(Is read as "a tuple of $x$ and $y$ is mapped to $x^2 + y^2$).
Similarly, the function

$id(x) = x$

can be rewritten in *anonymous* for as

$x \mapsto x$

Where the input is simply mapped to itself.

The lambda calculus only uses functions of a single input. When a function requires two inputs, example the **square_sum** function, we can rework in a function, that receive a single input, and the output return *another* function, that it turn accepts a single input. For example,
$(x, y) \mapsto x^2 + y^2$

can be reworked into

$x \mapsto (y \mapsto x^2 + y^2)$

## Lambda terms

The following three rules give an inductive definition that can be applied to build all syntactically valid lambda terms:

- variable $x$ is itself a valid lambda term.
- if $t$ is a lambda term, and $x$ is a variable, then $(\lambda x.t)$ is a lambda term (called an abstraction);
- it $t$ and $s$ are lambda terms, then $(t \ s)$ is a lambda term (called an application).

Nothing else is a lambda term. Thus a lambda term is valid if and only if it can be obtained by repeated application of these three rules.

