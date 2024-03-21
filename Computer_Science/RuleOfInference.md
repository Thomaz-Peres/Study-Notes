A **rule of inference**, **inference rule** or **transformation rule** consist a function which takes premises, analyzers the syntax and return a conclusion.

Rule Of inference is purely syntactic and does not need to preserve any semantic property. usually only rules that are recursive are important.

## Standard from

In many areas (formal logic for example), rules of inference are usually given in the following standard form:

> Premise#1
   Premise#2
     ...
  Premise#n   
  Conclusion


$\displaystyle A\to B$
$\displaystyle {\underline {A\quad \quad \quad }}\,\!$
$\displaystyle B\!$

> (A → (B → C)) → ((A → B) → (A → C))
> C

## Admissibility and Derivability

A derivable rule is one whose conclusion can be derived from its premises using the other rules. (All derivable rules are admissible)

Admissible rule is one whose conclusion holds whenever the premises hold.

To see the difference, the following set of rules for defining the natural numbers.
(the judment $n$ $nat$ asserts the fact that $n$ is a natural number).

$\displaystyle {\underline {\quad \quad \quad }}\,\,\,\,\,\,\,\,\,\,\,$ $\displaystyle {\underline {n \ nat }}\,\!$                   
$\displaystyle 0 \ nat\,\,\,\,\,\,\,\,\,\,\,\,\,$  $\displaystyle s(n) \ nat\!$

The first rule states that $0$ is a natural number, and the second states that $s(n)$ is a natural number if $n$ is. In this proof system, the following rule, demonstrating that the second successor of a natural number is also a natural number, is derivable:

$\displaystyle {\underline {\quad n \ nat \quad  }}\,\!$
$\displaystyle s(s(n)) \ nat\!$

>Some anotations:
>$\displaystyle {\underline {\quad \quad \quad \quad \quad \quad  }}\,\,\,\,\,\,\,\,\,\,\,\!$                  ${\underline {m \ \ day}}$
 $\ monday \ day \,\,\,\,\,\,\,\!$              $s(m) \ \ day$
>
>$\displaystyle {\underline {\quad d \ \ day \quad  }}\,\!$
   $\displaystyle s(s(d)) \ \ day\!$
>
>If i'm correct, this is okay $\uparrow$


 The following rule for asserting the existence of a predecessor for any nonzero number is merely admissible:

$\displaystyle {\underline {\quad s(n) \ \ nat \quad  }}\,\!$
$\displaystyle  {\quad n \ nat }\,\!$
