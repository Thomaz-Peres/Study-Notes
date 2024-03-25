The Type Theory is the study of [Type Systems](https://en.wikipedia.org/wiki/Type_system), Type Systems in resume is a area of study about types, with a set of rules, compilers, language design.

Some type theories serve as alternatives to set theory as a foundation of mathematics.

One of them (and is popular the conjunction) is the `typed λ-calculus` or `Lambda Calculus` and `Per Martin-Löf's intuitionistic type theory.`. In the future I will se more about `lambda calculus`.

Notable early example of `type theory` is Church's [simply typed lambda calculus](https://en.wikipedia.org/wiki/Simply_typed_lambda_calculus) ($\lambda ^{\to }$).

The type constructor ($\to$) that builds function types. It is the cannonical and simplest example of a typed lambda calculus.

Type theory is also particularly popular in conjunction with the lambda calculus.


## Type theory as a logic

A type theory has judments that defines types and assign them to a collection of formal objects, known as terms. A term and its type are often written together as `term : type`

### Terms

##### **Term are a collection of formal objects.**

A term in logic is recursively defined as a constant symbol, variable or a function application, where a term s applied to another term.
Constant symbols could include the natural number `0`, the boolean value `true` and function such as the successor function `S` and conditional operator `if`. Thus some terms could be `0`, `(S 0)`, `(S (S 0))` and `(if true 0(S 0))`

### Judments

Most type theories have 4 judments:
- "${T}$ is a type"
- "${t}$ is a term of type ${T}$"
- "Type ${T_1}$ is equal to type ${T_{2}}$"
- "Terms ${t_1}$ and ${t_2}$ both of type ${T}$ are equal"

Judments may follow from assumptions. For example, one might say "assuming $x$ is a term of type **bool** and $y$  is a term of type **nat**, it follows that ($if\ \ x\ \ y\ \ y$) is a term of type **nat**". Such judments are formally written with the `*turnstile symbol` $\vdash$.

> $*_1$: In the typed lambda calculus, the **turnstile** is used to separate typing assumptions from the typing judgment.

$x : bool, y : nat \vdash (if\ \ x\ \ y\ \ y) : nat$.

If there are no assumption, there will be nothing to the left of the turnstile.

$\vdash S : nat \to nat$

>In this like first-order logic in math. Looks like this:
> `(∀x ∈ R)(x ≤ 0 ∨ x > 0)`
>But implicity a `x` to a type (that of the real numbers). Looks like this:
>`(∀x)(x ∈ R → (x ≤ 0 ∨ x > 0))`
>
>You can read something like this in programming like
>`for all X, if x <= 0 or x > 0; return true else return false;`

The list of assumptions on the left is the *context* of the judment. Capital greek letters, such as $\Gamma$ (gamma) and $\Delta$ (delta), are common choices to represent some or all of the assumptions. The 4 different judments are thus usually written as follows.

| Formal notation for juddments | Description                                                                            |
| ----------------------------- | -------------------------------------------------------------------------------------- |
| $\Gamma \vdash T$  Type       | $T$ is a type (under assumptions $\Gamma$).                                            |
| $\Gamma \vdash t : T$         | $t$ is a term of type $T$ (under assumptions $\Gamma$)                                 |
| $\Gamma \vdash T_1 = T_2$     | Type $T_1$ is equal to type $T_2$ (under assumptions $\Gamma$)                         |
| $\Gamma \vdash t_1 = t_2 : T$ | Terms $t_1$ and $t_2$ are both of type $T$ and are equal (under assumptions $\Gamma$). |

### Rules of inference

A type theory's inference rules say what judgments can be made, based on the existence of other judgments.

Rules are expressed as a Gentzen-style deduction using a horizontal line, with the required input judgments above the line and the resulting judgment below the line. For example, the following inference rule states a substitution rule for judgmental equality:

${{\begin{array}{c}\Gamma \vdash t:T_{1}\qquad \Delta \vdash T_{1}=T_{2}\\\hline \Gamma ,\Delta \vdash t:T_{2}\end{array}}}$

> Reading something looks something like this: $t$ is a term of type $T_1$ (under assumptions $\Gamma$ )
> 
> And: $T_1$ is equal to type $T_2$ (under assumptions $\Delta$ )
> 
> And the conclusion is:  $t$ is a term of type $T_2$ (under assumptions $\Gamma$ $\Delta$ )


The metavariables ${\displaystyle \Gamma }$, ${\displaystyle \Delta }$, ${\displaystyle t}$,  ${\displaystyle T_{1}}$, and  ${\displaystyle T_{2}}$ may actually consist of complex term and types that contain many function applications, not just single symbols.

To generate judgments in type theory, there must be a rule to generate it, as well as rules to generate all of that rule's required inputs, and so on.

The applied rules form a proof tree, and the top-most rules need no assumptions.

One example of a rule does not required any inputs is one that states the type of a constant term. To assert that there is a term $0$ of type $nat$, we write the following.

${\underline \qquad \quad \quad \qquad \qquad}$
${\vdash 0 : nat }$

#### Type theory usually has several rules, including ones to:

- Create a judgment (known as a context in this case)
- Add an assumption to the context (context weakening)
- Rearrange the assumptions
- Use an assumption to create a variable
- Define reflexivity, symmetry and transitivity for judgmental equality
- Define substitution for application of lambda terms
- List all the interactions of equality, such as substitution
- Define a hierarchy of type universes
- Assert the existence of new types

Also, for each "by rule" type, there are 4 different kinds of rules:
- "Type formation" rules say  how to create the type.
- "Term introduction" rules define the canonical terms and constructor function like "pair" and "S".
- "Term elimination" rules define the other functions like "first", "second", and "R".
- "Computation" rules specify how computation is performed with the type-specific functions.

>For example of rules, an interested reader may follow Appendix A.2 of the *Homotopy Type theory* book, or Martin-Lof's Intuitionistic Type Theory.

______________________________________________
# Connections to foundations

### Intuitionistic logic

When used as a foundation, certain types are interpreted to be propositions (statements that can be proven), and terms inhabiting the type are interpreted to be proofs of that proposition.

Under this intuitionistic interpretation, there are common types that act as the logical operators:

| Logic Name  | Logic Notation           | Type Notation          | Type Name              |
| ----------- | ------------------------ | ---------------------- | ---------------------- |
| True        | ${\top}$                 | ${\top}$               | Unit Type              |
| False       | ${\bot}$                 | ${\bot}$               | Empty Type             |
| Implication | ${A \rightarrow B}$      | ${A \rightarrow B}$    | Function               |
| Not         | ${\neg \ A}$             | ${A \rightarrow \bot}$ | Function To Empty Type |
| And         | ${A \land B}$            | ${A \times B}$         | Product Type           |
| Or          | ${A \lor B}$             | ${A + B}$              | Sum Type               |
| For all     | ${\forall a \in A,P(a)}$ | ${\Pi a \ : A,P(a)}$   | Dependent Product      |
| Exists      | ${\exists a \in A,P(a)}$ | ${\Sigma a \ : P(a)}$  | Dependent Sum          |

### Constructive mathematics

Per Martin-Löf proposed his intuitionistic type theory as a foundation for constructive mathematics.
______________________________________________

# Definitions

## Terms and Types

> I have some some examples of (functions and lambda) terms in [C#](../DotnetThings/SomeTests/TypeTheory.cs)

#### Atomic terms

The most basic types are called atoms.

Some atomic terms:

- ${42 : nat}$
- ${true : bool}$
- ${x : nat}$
- ${y : bool}$

#### Function Terms

Functions introduce the arrow symbol and are defined inductively.

If ${a}$ and ${r}$ are types, then the notation ${a \rightarrow r}$ is the type of a function which takes a parameter of type ${a}$ and return a term of type ${r}$.

Some terms may be declared directly as having a simple type, such as the following term, **add**, which takes in two natural numbers in sequence and return one natural number.

${add : nat \rightarrow (nat \rightarrow nat)}$

Strictly speaking, a simple type only allows for one input and one output, so a more faithful reading of the above type is that **add** is a function which takes in a natural number and returns a function of the form ${nat \rightarrow nat}$. The parentheses clarify that **add** does not have the type ${(nat \rightarrow nat) \rightarrow nat}$ which would be a function which takes in a function of natural number and return a natural number.

The convention is that the arrow is right associative, so the parentheses may be dropped from The parentheses clarify that **add** does not have the type

> Some obs to help me
> 
> Em resumo, a principal diferença é que na primeira expressão, a entrada é uma função, e na segunda, a entrada é um número natural. Além disso, o resultado da primeira expressão é um número natural, enquanto o resultado da segunda é uma função. Isso muda completamente o tipo de operação que está sendo realizada e o tipo de dado que está sendo manipulado.

### Lambda Terms

New function term may be constructed with lambda expression (${\lambda}$). These terms are also defined inductively.

The lambda terms has the form: ${(\lambda v.t)}$ where ${v}$ is formal variable and ${t}$ is a term.
You can understand something like this ${v \to t}$.

This following lambda term represents a:

${(\lambda x.\mathrm {add} \,x\,x):{\mathsf {nat}}\to {\mathsf {nat}}}$

> For the 