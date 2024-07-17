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
		Math.Pow(x, x) + Math.Pow(y, y);

var b = square_sum(5);
double result = b(5);
Console.WriteLine("Function result: " + result);
// Function result: 6250

// You can write the function like this too

Func<double, Func<double, double>> square_sum = (double n) =>
{
  return new Func<double, double>((double x) =>
  {
	return Math.Pow(n, n) + Math.Pow(x, x);
  });
};
```

This method, know as currying, transforms a function that takes multiple arguments into a chain of function each with a single argument.

[Reference](https://en.m.wikipedia.org/wiki/Lambda_calculus)