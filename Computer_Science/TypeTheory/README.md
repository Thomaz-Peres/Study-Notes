The Type Theory is the study of [Type Systems](https://en.wikipedia.org/wiki/Type_system), Type Systems in resume is a area of study about types, with a set of rules, compilers, language design.

Some type theories serve as alternatives to set theory as a foundation of mathematics.

One of them (and is popular the conjunction) is the `typed λ-calculus` or `Lambda Calculus` and `Per Martin-Löf's intuitionistic type theory.`. In the future I will se more about `lambda calculus`.

Notable early example of `type theory` is Church's [simply typed lambda calculus](https://en.wikipedia.org/wiki/Simply_typed_lambda_calculus) ($\lambda ^{\to }$).

The type constructor ($\to$) that builds function types. It is the cannonical and simplest example of a typed lambda calculus.

Type theory is also particularly popular in conjunction with the lambda calculus.


## Type theory as a logic

A type theory has judments that defines types and assign them to a collection of formal objects, known as terms. A term and its type are often written together as `term : type`

### Terms

A term in logic is recursively defined as a constant symbol, variable or a function application, where a term s applied to another term.
Constant symbols could include the natural number `0`, the boolean value `true` and function such as the successor function `S` and conditional operator `if`. Thus some terms could be `0`, `(S 0)`, `(S (S 0))` and `(if true 0(S 0))`

### Judments

Most type theories have 4 judments:
- "$T$ is a type"
- "$t$ is a term of type $T$"
- "Type $T_1$ is equal to type $T_{2}$"
- "Terms $t_1$ and $t_2$ both of type $T$ are equal"

Judments may follow from assumptions. For example, one might say "assuming $x$ is a term of type **bool** and $y$  is a term of type **nat**, it follows that ($if\ \ x\ \ y\ \ y$) is a term of type **nat**". Such judments are formally written with the `*turnstile symbol` $\vdash$.

> $*_1$: In the typed lambda calculus, the turnstile is used to separate typing assumptions from the typing judgment.

$x : bool, y : nat \vdash (if\ \ x\ \ y\ \ y) : nat$.

If there are no assumption, there will be nothing to the left of the turnstile.

$\vdash S : nat \to nat$

The list of assumptions on the left is the *context* of the judment. Capital greek letters, such as $\Gamma$ (gamma) and $\Delta$ (delta), are common choices to represent some or all of the assumptions. The 4 different judments are thus usually written as follows.

| Formal notation for juddments | Description                                                                            |
| ----------------------------- | -------------------------------------------------------------------------------------- |
| $\Gamma \vdash T$  Type       | $T$ is a type (under assumptions $\Gamma$).                                            |
| $\Gamma \vdash t : T$         | $t$ is a term of type $T$ (under assumptions $\Gamma$)                                 |
| $\Gamma \vdash T_1 = T_2$     | Type $T_1$ is equal to type $T_2$ (under assumptions $\Gamma$)                         |
| $\Gamma \vdash t_1 = t_2 : T$ | Terms $t_1$ and $t_2$ are both of type $T$ and are equal (under assumptions $\Gamma$). |

### Rules of inference

A type theory's inference rules say what judments can be made, based on the existence of other judments.

Rules are expressed as a Gentzen-style deduction using a horizontal line, with the required input judments above the line and the resulting judment below the line. For example, the following inference rule states a substitution rule for judmental equality.