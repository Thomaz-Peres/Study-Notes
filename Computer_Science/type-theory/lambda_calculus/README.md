# Lambda Calculus

Lambda Calculus can be written as $\lambda$.

The simplest form of lambda calculus, terms are built only the following rules:

1. ${x:}$ A variable representing a parameter.
2. ${(\lambda \ x. \ M):}$ A lambda abstraction is a function definition. Take as input the bound variable ${x}$ and return the body ${M}$.
3. ${(M \ N):}$ An application, applying a function $M$ to an argument $N$. Both $M$ and $N$ are lambda terms.

Lambda calculus can be used to simulate any Turing machine.

The lambda symbol, is used in lambda expressions and lambda terms to denote binding a variable in a function.

Lambda calculus it is an important role in the development of the theory of programming languages. Functional programming languages implement lambda calculus.

Lambda has two simplifications that make its semantics simple. The first is the anonymous functions, it doesn't give them explicit names.

${{square\_sum}(x,y) = x^2 + y^2}$

Can be rewritten as:

${(x,y) \to x^2 + y^2}$

Similarly, the function:

${id(x) = x}$

In anonymous form as

${x \to x}$

Where the input is simply mapped to itself

The second simplification is the Lambda Calculus only uses single input functions. For an ordinary function like **square_sum** function where requires two inputs, we reworked into an equivalent function that accepts a single input, and as output returns another function. Example:

${(x,y) \mapsto x^2 + y^2}$

can be reworked into:

${x \mapsto (y \mapsto x^2 + y^2)}$

An example in C# where a functions returns other function:

```csharp
Func<double, Func<double, double>> square_sum = x => y =>
    x * x + y * y;

var b = square_sum(5);
double result = b(2);
Console.WriteLine("Function result: " + result);
// Function result: 29

// You can write the function like this too

Func<double, Func<double, double>> square_sum = (double n) =>
{
  return new Func<double, double>((double x) =>
  {
	return n * n + x * x;
  });
};
```

This method, know as currying, transforms a function that takes multiple arguments into a chain of function each with a single argument.

Example:

${((x,y) \mapsto x^2 + y^2)(5,2) = 5^2 + 2^2 = 29}$

${((x \mapsto (y \mapsto x^2 + y^2))(5))(2) = (y \mapsto 5^2 + y^2)(2) = 5^2 + 2^2 = 29}$

Similar to ${\beta- reduction}$

## Lambda Terms

A valid lambda calculus expressions is called a **"lambda term"**.

- Variable ${x}$ is itself a valid lambda term.
- If ${t}$ is a lambda term, and ${x}$ is a variable, then ${(\lambda x. t)}$ is a lambda term (called an abstraction);
- If ${t}$ and ${s}$ are lambda terms, then ${(t \ s)}$ is a lambda term (called an application).

An abstraction ${\lambda x. t}$ denotes an anonymous function that takes a single input $x$ and returns $t$.

Examples:

-------
${\lambda x . \ t}$ = ${x \mapsto t}$
${\lambda x . (x^2 + 2)}$ represents the function (${f}$) defined by ${f(x) = x^2 + 2}$, using the term ${x^2 + 2}$ for ${t}$.

---

The syntax ${(\lambda x . t)}$ binds the variable $x$ in the term $t$.

An application ${t \ s}$ represents the application of a function $t$ to an input $s$ to produce ${t(s)}$.

${\lambda x. (x + 2)}$ = ${f(x) = x + y}$.

In this term, the variable $y$ has not been defined and is considered an unknown.

The abstraction is a syntactically valid term and represents a functions that adds its input to the yer-unknown $y$.

Parentheses is used and might be needed to disambiguate terms.

1. ${\lambda x . ((\lambda x . x)x)}$ is of form ${\lambda x . B}$ = abstraction
2. ${(\lambda x . (\lambda x . x))x}$ if of form $M \ N$ = application

Both examples would evaluate to the identity function ${\lambda x . x}$.

###### Functions that operate on function

Is a function composition, can be defined as ${\lambda f. \lambda g. \lambda x.}$ = ${(f(gx))}$


###### Capture-avoiding substitutions

$t, s$ and $r$ are lambda terms, and $x$ and $y$ are variables. The notation ${t[x := r]}$ indicates substitution of $r$ for $x$ in $t$ in a capture avoinding manner. 

- ${x[x := r] = r}$; = $r$ are substituted for $x$, $x$ becomes $r$
- ${y[x := r] = y \}$ if ${\ x \neq y}$; With $r$ substituted for $x$, $y$  (which is not $x$) remains y.
- ${(ts)[x := r] = (t[x := r])(s[x += r])}$; Substitution distributes to both sides of an application
- ${(\lambda x .t)[x := r] = \lambda x .t}$; A variable bound by an abstraction is not subject to substitution; substituting such variable leaves the abstraction unchanged
- ${(\lambda y .t)[x := r] = \lambda y.(t[x := r])}$ if ${x \neq y}$; Substituting a variable with is not bound by abstraction proceeds in the abstraction body, provided that the abstracted variable $y$ is "fresh" for the substitution term $r$.

For example:
*obs: is good remember about evaluation* 

${(\lambda x.x)[y := y] = \lambda x.(x [y := y]) = \lambda x.x}$ 

and

${((\lambda x.y) x)[x := y] = ((\lambda x.y)[x := y](x[x := y]) = (\lambda x.y)y)}$.

The freshness condition (requiring that $y$ is not in the free variables of $r$) is crucial in order to ensure that substitution does not change the meaning of functions.

For example, that substitution ignores the freshness condition could lead to error:

${(\lambda x.y)[y := x] = \lambda x.(y[y := x]) = \lambda x.x}$. This substitution turn the constant function ${\lambda x.y}$ to an identity ${\lambda x.x}$ 

### Notation

Some conventions are usually applied:

- Applications are assumed to be left associative: ${M N P}$ may be written instead of ${((M N ) P)}$.
- The body of an abstraction extends as far right as possible: ${\lambda x. M N}$ means ${\lambda x. (M N)}$ and not ${(\lambda x. M) N}$
- A sequence of abstractions is contracted: ${\lambda x. \lambda y. \lambda z. N}$ is abbreviated as ${\lambda xyz. N}$

### Encoding datatypes

The basic lambda calculus may be used to model arithmetic, boolean, data structures, and recursions.

###### Arithmetic in lambda calculus

The most common ways to define natural numbers in lambda calculus are the Church numerals, example

0 := ${\lambda f. \lambda x. x}$

1 := ${\lambda f. \lambda x. f \ x}$

2 := ${\lambda f. \lambda x. f \ (f \ x)}$

3 := ${\lambda f. \lambda x. f \ (f \ (f \ x))}$

Using the alternative syntax presented above in [Notation](#notation)

0 := ${\lambda f x. x}$

1 := ${\lambda fx. f \ x}$

2 := ${\lambda fx. f \ (f \ x)}$

3 := ${\lambda fx. f \ (f \ (f \ x))}$

A Church numeral is a higher-order function - it takes a single-argument function $f$, and returns another single-argument function.

The function $f$ composed with itself $n$ times. This is denoted ${f(^n)}$

### Standard Terms

I   := ${\lambda x.x}$

S  := ${\lambda x. \lambda y. \lambda x. z (y z)}$

K  := ${\lambda x. \lambda y. x}$

B  := ${\lambda x. \lambda y. \lambda z.x (y z)}$

C  := ${\lambda x. \lambda y. \lambda z. x z y}$

W := ${\lambda x. \lambda y. x y y}$

ω or Δ or U := ${\lambda x. x x}$

Ω := ω ω

**I** is the identity function (f(x) -> x)

[Reference](https://en.m.wikipedia.org/wiki/Lambda_calculus)