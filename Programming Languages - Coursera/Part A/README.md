## This is a course in coursera (https://www.coursera.org/learn/programming-languages/home/week/2)


#### About languages: (i go need to revisit to update and separete better)

# Week 2
- **Syntax** is just how you write something
- **Semantics** is what that somethings means
   - Type-checking (before program runs) 
   - Evaluation (as program runs)

- For variable bindings:
   - Type-check expressions and extend static environment
   - Evaluate expression and extend dynamic environment


### Variables rules

val x = 34;
val x = "teste";

#### Rules for expressions

Every kind a expression ask your selfies the same three questions:

- What is the syntax, how do you write it down ?
- Quais são as regras de verificação de digitação. Em outras palavras, que tipo tem uma expressão e o que pode fazer com que ela não digite a verificação, caso em que você receba uma mensagem de erro.
- E se as regras de avaliação. Assumindo que ele faz verificação de tipo, como ele executa seu cálculo, a fim de produzir um resultado.


#### What define variables

- Syntax: Any sequence of
    - Letters.
    - Digits.
    - Or sublinhados (_).
    - Except not starting with digit.

- Type-checking rules
    - when we're using a variable, not when we're defining it with a variable binding, but when we're using it as an expressions or like as part of large expression.

- Evaluation rules
    - Here it's similar to the type checking rules, except we looked the variable up in the dynamic environment and we used whatever value we find there.


#### Shadowing

Shadowing é quando uma váriavel que já esta no código, vira uma váriavel de ambiente.

#### Functions in ML

Functions is a like methods in OOP, receive value and return a value.




# Week 3