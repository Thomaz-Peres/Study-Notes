(* The new type is called day and its member are `monday, tuesday, etc`. *)
Inductive day : Type :=
  | monday
  | tuesday
  | wednesday
  | thursday
  | friday
  | saturday
  | sunday.

(* Having defined day, we can write function that operate on days. *)
Definition next_weekday (d:day) : day :=
  match d with
  | monday    => tuesday
  | tuesday   => wednesday
  | wednesday => thursday
  | thursday  => friday
  | friday    => monday
  | saturday  => monday
  | sunday    => monday
  end.

Compute (next_weekday friday).
(* ==> monday : day *)

Compute (next_weekday (next_weekday sunday)).
(* ==> tuesday : day *)

Example test_next_weekday:
  (next_weekday (next_weekday saturday)) = tuesday.

Proof. simpl. reflexivity. Qed.
(* The details are not important just now, but essentially this can be read as (The assertion we've just made can be proved by observing that both sides of the equality evaluate to the same thing.) *)

From Coq Require Export String.
(* ------------------------------------------------------------------------ *)
(* Booleans *)

Inductive bool : Type :=
  | true
  | false.

(** Functions over booleans can be defined in the same way as
    above: *)

Definition negb (b:bool) : bool :=
  match b with
  | true => false
  | false => true
  end.

Definition andb (b1:bool) (b2:bool) : bool :=
  match b1 with
  | true => b2
  | false => false
  end.

Definition orb (b1:bool) (b2:bool) : bool :=
  match b1 with
  | true => true
  | false => b2
  end.

  (* (Although we are rolling our own booleans here for the sake of building up everything from scratch, Coq does, of course, provide a default implementation of the booleans, together with a multitude of useful functions and lemmas. Whenever possible, we'll name our own definitions and theorems so that they exactly coincide with the ones in the standard library.)
The last two of these illustrate Coq's syntax for multi-argument function definitions. The corresponding multi-argument application syntax is illustrated by the following "unit tests," which constitute a complete specification -- a truth table -- for the orb function *)

Example test_orb1:  (orb true false) = true.
Proof. simpl. reflexivity. Qed.
Example test_orb2: (orb false false) = false.
Proof. simpl. reflexivity. Qed.
Example test_orb3: (orb false true) = true.
Proof. simpl. reflexivity. Qed.
Example test_orb4: (orb true true) = true.
Proof. simpl. reflexivity. Qed.


(* We can also introduce some familiar infix syntax for the boolean operations we have just defined. The Notation command defines a new symbolic notation for an existing definition. *)
Notation "x && y" := (andb x y).
Notation "x || y" := (orb x y).
(* Me creating this notation to test negation (not or problaly work but it is a test) *)
Notation "/ x" := (negb x).
Example test_orb5: false || false || true = true.
Proof. simpl. reflexivity. Qed.
Example test_orb6: / true = false.
Proof. simpl. reflexivity. Qed.


(* conditional expressions... (like SML) *)
Definition negb' (b:bool) : bool :=
  if b then false
  else true.
Definition andb' (b1:bool) (b2:bool) : bool :=
  if b1 then b2
  else false.
Definition orb' (b1:bool) (b2:bool) : bool :=
  if b1 then true
  else b2.


(* ------------------------------------------------------------------------ *)
(* Types *)

(* Every expression in Coq has a type, describing what sort of thing it computes.
The Check command asks Coq to print the type of an expression. *)
Check true.
(* ===> true : bool *)
Check 2.
(* ===> 2 : nat *)

(* If the expression after Check is followed by a colon and a type,
Coq will verify that the type of the expression matches the given type
and halt with an error if not. *)
Check true
  : bool.
Check (negb true)
  : bool.

(* Functions like negb itself are also data values, just like true and false.
Their types are called function types, and they are written with arrows. *)
Check negb.
(* : bool -> bool *)


(* ------------------------------------------------------------------------ *)
(* New Types from Old *)

(* The types we have defined so far are examples of "enumerated types": their
definitions explicitly enumerate a finite set of elements, called constructors *)

(* Here is a more interesting type definition,
where one of the constructors takes an argument: *)
Inductive rgb : Type :=
  | red
  | green
  | blue.
Inductive color : Type :=
  | black
  | white
  | primary (p : rgb).

  (* An Inductive definition does two things: *)
(* It defines a set of new constructors. E.g., red, primary, true, false, monday, etc. are constructors. *)
(* It groups them into a new named type, like bool, rgb, or color. *)

(* if p is a constructor expression belonging to the set rgb,
then primary p (pronounced "the constructor primary applied to the argument p")
is a constructor expression belonging to the set color *)

(* We can define functions on colors using pattern matching just as we did for day and bool. *)

Definition monochrome (c : color) : bool :=
  match c with
  | black => true
  | white => true
  | primary p => false
  end.

(* Since the primary constructor takes an argument,
a pattern matching primary should include either a variable
(as above -- note that we can choose its name freely) 
or a constant of appropriate type (as below). *)

Definition isred (c : color) : bool :=
  match c with
  | black => false
  | white => false
  | primary red => true
  | primary _ => false
  end.

(* The pattern "primary _" here is shorthand for
"the constructor primary applied to any rgb constructor except red."
(The wildcard pattern _ has the same effect as the dummy pattern variable p
in the definition of monochrome.) *)

(* Explication to myself (to escrevendo isso que e a mesma coisa acima, porem no dia
eu tava meio burro).

The "primary _" says the blue and green is false.
Por que como vemos no tipo color, primary recebe um tipo RGB na variavel P, seria
como se eu fizesse isto aqui.
primary (_) => false

Ou seja, eu poderia fazer isso aqui (ou qualquer coisa de p tambem):
primary p => false (alterando o (_)
*)

(* ------------------------------------------------------------------------ *)
(* Modules *)

(* Coq provides a module system to aid in organizing large developments *)

(* If we enclose a collection of declarations between Module X and End X markers, then,
in the remainder of the file after the End,
these definitions are referred to by names like X.foo instead of just foo *)

Module Playground.
  Definition b : rgb := blue.
End Playground.

Definition b : bool := true.
Check Playground.b : rgb.
Check b : bool.

(* ------------------------------------------------------------------------ *)
(* Tuples *)

Module TuplePlayground.

(* A single constructor with multiple parameters can be used to create a tuple type.
As an example, consider representing the four bits in a nybble (half a byte) *)

(* We first define a datatype bit that resembles bool
(using the constructors B0 and B1 for the two possible bit values)
and then define the datatype nybble, which is essentially a tuple of four bits *)

Inductive bit : Type :=
  | B0
  | B1.

Inductive nybble : Type :=
  | bits (b0 b1 b2 b3 : bit).

  Check (bits B1 B0 B1 B0)
  : nybble.

(* The bits constructor acts as a wrapper for its contents *)
(* Wrapper = embrulhar *)
(* Unwrapping can be done by pattern-matching,
as in the all_zero function which tests a nybble to see if all its bits are B0
We use underscore (_) as a wildcard pattern to
avoid inventing variable names that will not be used*)

Definition all_zero (nb : nybble) : bool :=
  match nb with
  | (bits B0 B0 B0 B0) => true
  | (bits _ _ _ _) => false
  end.

Compute (all_zero (bits B1 B0 B1 B0)).
(* ===> false : bool *)

Compute (all_zero (bits B0 B0 B0 B0)).
(* ===> true : bool *)
End TuplePlayground.

(* ------------------------------------------------------------------------ *)
(* Numbers *)

(* We put this section in a module so that our own definition of natural numbers does not interfere
with the one from the standard library.
In the rest of the book, we'll want to use the standard library's. *)

Module NatPlayground.

(* All the types we have defined so far -- both "enumerated types"
such as day, bool, and bit and tuple types such as nybble built from them -- are finite
The natural numbers, on the other hand, are an infinite set,
so we'll need to use a slightly richer form of type declaration to represent them*)

(* The binary representation is valuable in computer hardware because the digits can be represented with just two distinct voltage levels, resulting in simple circuitry. Analogously, we wish here to choose a representation that makes proofs simpler *)

(* In fact, there is a representation of numbers that is even simpler than binary, namely unary (base 1), *)

(* To represent unary numbers with a Coq datatype, we use two constructors.
The capital-letter O constructor represents zero. When the S constructor is applied to
the representation of the natural number n, the result is the representation of n+1,
where S stands for "successor" (or "scratch"). Here is the complete datatype definition.
 *)

Inductive nat : Type :=
  | O
  | S (n : nat).

(* With this definition, 0 is represented by O, 1 by S O, 2 by S (S O), and so on. *)

(* Informally, the clauses of the definition can be read:
- O is a natural number (remember this is the letter "O," not the numeral "0").
- S can be put in front of a natural number to yield another one -- if n is a natural number, then S n is too. *)

(* Again, let's look at this in a little more detail.
The definition of nat says how expressions in the set nat can be built:

- the constructor expression O belongs to the set nat;
- if n is a constructor expression belonging to the set nat, then S n is also a constructor expression belonging to the set nat; and
- constructor expressions formed in these two ways are the only ones belonging to the set nat. *)

(* These conditions are the precise force of the Inductive declaration.
They imply that the constructor expression O,
the constructor expression S O, the constructor expression S (S O),
the constructor expression S (S (S O)),
and so on all belong to the set nat, while other constructor expressions,
 like true, andb true false, S (S false), and O (O (O S)) do not *)

 (* A critical point here is that what we've done so far is just to define a representation of numbers: a way of writing them down. The names O and S are arbitrary, and at this point they have no special meaning -- they are just two different marks that we can use to write down numbers (together with a rule that says any nat will be written as some string of S marks followed by an O) *)

 (* If we like, we can write essentially the same definition this way: *)

Inductive nat' : Type :=
  | stop
  | tick (foo : nat').

Definition pred (n : nat) : nat :=
  match n with
  | O => O
  | S n' => n'
  end.

(* The following End command closes the current module, so nat will refer back to the type from the standard library. *)
End NatPlayground.

(* Because natural numbers are such a pervasive form of data, Coq provides a tiny bit of built-in magic for parsing and printing them: ordinary decimal numerals can be used as an alternative to the "unary" notation defined by the constructors S and O. Coq prints numbers in decimal form by default *)

(* Pred sempre me retorna um numero a menos do que eu to enviado *)
Compute (pred (S (S (S (S O))))).
(* ==> 3 : nat *)

Compute (S (S (S (S O)))).

Check (S (S (S (S O)))).

Definition minustwo (n : nat) : nat :=
  match n with
  | O => O
  | S O => O
  | S (S n') => n'
  end.

Compute (minustwo 4).
(* ===> 2 : nat *)
Check S : nat -> nat.
Check pred : nat -> nat.
Check minustwo : nat -> nat.

(* However, there is a fundamental difference between S and the other two: functions like pred and minustwo are defined by giving computation rules -- e.g., the definition of pred says that pred 2 can be simplified to 1 -- while the definition of S has no such behavior attached *)

(* For most interesting computations involving numbers, simple pattern matching is not enough: we also need recursion 
For example, to check that a number n is even, we may need to recursively check whether n-2 is even. Such functions are introduced with the keyword Fixpoint instead of Definition*)

Fixpoint even (n : nat) : bool :=
  match n with
  | O => true
  | S O => true
  | S (S n') => even n'
  end.

Definition odd (n:nat) : bool :=
  negb (even n).

Example test_odd1: odd 1 = false.
Proof. simpl. reflexivity. Qed.
Example test_odd2: odd 4 = false.
Proof. simpl. reflexivity. Qed.

(* You may notice if you step through these proofs that simpl actually has no effect on the goal -- all of the work is done by reflexivity. We'll discuss why that is shortly. *)

(* Naturally, we can also define multi-argument functions by recursion. *)
Module NatPlayground2.

Fixpoint plus (n : nat) (m : nat) : nat :=
  match n with
  | O => m
  | S n' => S (plus n' m)
  end.

Compute (plus 3 2).
(* ===> 5 : nat *)

(* The steps of simplification that Coq performs can be visualized as follows: *)
(*      plus 3 2
   i.e. plus (S (S (S O))) (S (S O))
    ==> S (plus (S (S O)) (S (S O)))
          by the second clause of the match
    ==> S (S (plus (S O) (S (S O))))
          by the second clause of the match
    ==> S (S (S (plus O (S (S O)))))
          by the second clause of the match
    ==> S (S (S (S (S O))))
          by the first clause of the match
   i.e. 5  *)

(* As a notational convenience, if two or more arguments have the same type,
they can be written together.
In the following definition,
(n m : nat) means just the same as if we had written (n : nat) (m : nat). *)
Fixpoint mult (n m : nat) : nat :=
  match n with
  | O => O
  | S n' => plus m (mult n' m)
  end.

Example test_mult1: (mult 3 3) = 9.
Proof. simpl. reflexivity. Qed.

(* You can match two expressions at once by putting a comma between them: *)
Fixpoint minus (n m:nat) : nat :=
  match n, m with
  | O , _ => O
  | S _ , O => n
  | S n', S m' => minus n' m'
  end.
End NatPlayground2.
Fixpoint exp (base power : nat) : nat :=
  match power with
  | O => S O
  | S p => mult base (exp base p)
  end.

Example exp1: (exp 3 5) = 243.
Proof. simpl. reflexivity. Qed.
Example exp2: (exp 0 0) = 1.
Proof. simpl. reflexivity. Qed.

(* Exp in this case, do exponentiation i Do 3^5 *)

(* Exercise: 1 star, standard (factorial) *)
Fixpoint factorial (n:nat) : nat :=
  match n with
  | O => S O
  | S z => mult n (factorial z)
  end .

Example test_factorial1: (factorial 3) = 6.
Proof. simpl. reflexivity. Qed.
Example test_factorial2: (factorial 5) = (mult 10 12).
Proof. simpl. reflexivity. Qed.
(* Stack overflow kkkkkkk
Example test_factorial3: (factorial 10) = 3628800.
Proof. simpl. reflexivity. Qed. *)
Example test_factorial3: (factorial 6) = 720.
Proof. simpl. reflexivity. Qed.

(* Again, we can make numerical expressions easier to read and
write by introducing notations for addition, multiplication, and subtraction. *)
Notation "x + y" := (plus x y)
                      (at level 50, left associativity)
                       : nat_scope.
Notation "x - y" := (minus x y)
                      (at level 50, left associativity)
                       : nat_scope.
Notation "x * y" := (mult x y)
                      (at level 40, left associativity)
                       : nat_scope.
Notation "x ^" := (factorial x)
                      (at level 6, left associativity)
                       : nat_scope.

Check ((0 + 1) + 1) : nat.
Compute (3 ^).
(* ===> 12 -> nat *)


(* The level, associativity, and nat_scope annotations control how these notations
are treated by Coq's parser. The details are not important for present purposes,
but interested readers can refer to the "More on Notation" section at the end of this chapter. *)


(* When we say that Coq comes with almost nothing built-in, we really mean it:
even equality testing is a user-defined operation!
Here is a function eqb, which tests natural numbers for equality,
yielding a boolean. Note the use of nested matches
(we could also have used a simultaneous match, as we did in minus.) *)

Fixpoint eqb (n m : nat) : bool :=
  match n with
  | O => match m with
         | O => true
         | S m' => false
         end
  | S n' => match m with
            | O => false
            | S m' => eqb n' m'
            end
  end.

Example test_eqb1: eqb 2 2 = true.
Proof. simpl. reflexivity. Qed.
Example test_eqb2: eqb 2 4 = false.
Proof. simpl. reflexivity. Qed.
Example test_eqb3: eqb 4 2 = false.
Proof. simpl. reflexivity. Qed.

Fixpoint leb (n m : nat) : bool :=
  match n with
  | O => true
  | S n' =>
      match m with
      | O => false
      | S m' => leb n' m'

      end
  end.

Example test_leb1: leb 2 2 = true.
Proof. simpl. reflexivity. Qed.
Example test_leb2: leb 2 4 = true.
Proof. simpl. reflexivity. Qed.
Example test_leb3: leb 4 2 = false.
Proof. simpl. reflexivity. Qed.

(* We'll be using these (especially eqb) a lot, so let's give them infix notations. *)
Notation "x =? y" := (eqb x y) (at level 70) : nat_scope.
Notation "x <=? y" := (leb x y) (at level 70) : nat_scope.
Example test_leb3': (4 <=? 2) = false.
Proof. simpl. reflexivity. Qed.

(* We now have two symbols that look like equality: = and =?.
We'll have much more to say about the differences and similarities between
them later. For now, the main thing to notice is that x = y is a logical claim -- a "proposition" --
that we can try to prove, while x =? y is an expression whose value
(either true or false) we can compute. *)

(* Exercise: 1 star, standard (ltb) *)
Fixpoint ltb (n m : nat) : bool :=
  match n with
  | O => 
        match m with
        | O => false
        | S m' => true
        end
  | S n' => 
        match m with
        | O => false
        | S m' => ltb n' m'
        end
  end.

Notation "x <? y" := (ltb x y) (at level 70) : nat_scope.
Example test_ltb1: (ltb 2 2) = false.
Proof. simpl. reflexivity. Qed.
Example test_ltb2: (ltb 2 4) = true.
Proof. simpl. reflexivity. Qed.
Example test_ltb3: (ltb 4 2) = false.
Proof. simpl. reflexivity. Qed.


(* ------------------------------------------------------------------------ *)
(* Proof by Simplification *)
(* Now that we've defined a few datatypes and functions, let's turn to stating and proving properties of their behavior.
Actually, we've already started doing this: each Example in the previous sections makes a precise claim about the
behavior of some function on some particular inputs. The proofs of these claims were always the same: use simpl
to simplify both sides of the equation, then use reflexivity to check that both sides contain identical values. *)

(* The same sort of "proof by simplification" can be used to prove more interesting properties as well.
For example, the fact that 0 is a "neutral element" for + on the left can be proved just by observing
that 0 + n reduces to n no matter what n is -- a fact that can be read directly off the definition of plus. *)
(* the universal quantifier ∀ using the reserved identifier "forall." *)
Theorem plus_O_n : forall n : nat, 0 + n = n.
Proof.
  intros n. simpl. reflexivity. Qed.

(* 
  This is a good place to mention that [reflexivity] is a bit more
  powerful than we have acknowledged. In the examples we have seen,
  the calls to [simpl] were actually not needed, because
  [reflexivity] can perform some simplification automatically when
  checking that two sides are equal; [simpl] was just added so that
  we could see the intermediate state -- after simplification but
  before finishing the proof.  Here is a shorter proof of the
  theorem:
*)
Theorem plus_O_n' : forall n : nat, 0 + n = n.
Proof.
intros n. reflexivity. Qed.
(* 
Moreover, it will be useful to know that reflexivity does somewhat
more simplification than simpl does - for example,
    it tries "unfolding" defined terms, replacing them with their
    right-hand sides.  The reason for this difference is that, if
    reflexivity succeeds, the whole goal is finished and we don't need
    to look at whatever expanded expressions [reflexivity] has created
    by all this simplification and unfolding;
    by contrast, [simpl] is used in situations where we may have to
    read and understand the new goal that it creates, so we would not
    want it blindly expanding definitions and leaving the goal in a messy state
    
    First, we've used the keyword [Theorem] instead of [Example].
    This difference is mostly a matter of style; the keywords
    [Example] and [Theorem] (and a few others, including [Lemma],
    [Fact], and [Remark]) mean pretty much the same thing to Coq.

    Second, we've added the quantifier [forall n:nat], so that our
    theorem talks about _all_ natural numbers [n].  Informally, to
    prove theorems of this form, we generally start by saying "Suppose
    [n] is some number..."  Formally, this is achieved in the proof by
    [intros n], which moves [n] from the quantifier in the goal to a
    _context_ of current assumptions. Note that we could have used
    another identifier instead of [n] in the [intros] clause, (though
    of course this might be confusing to human readers of the proof):
*)

Theorem plus_O_n'' : forall n : nat, 0 + n = n.
Proof.
  intros m. reflexivity. Qed.

(* ------------------------------------------------------------------------ *)
(* That it is me, tryint (and with succesfull I guess) creating a notation to [forall] *)
Notation "∀ n , P" := (forall n, P) (at level 200, n ident).
Theorem plus_O_n_test_me : ∀ n, 0 + n = n.
Proof.
  intros m. reflexivity. Qed.
(* ------------------------------------------------------------------------ *)


(** The keywords [intros], [simpl], and [reflexivity] are examples of
    _tactics_.  A tactic is a command that is used between [Proof] and
    [Qed] to guide the process of checking some claim we are making.
    We will see several more tactics in the rest of this chapter and
    many more in future chapters. *)

(** Other similar theorems can be proved with the same pattern. *)

Theorem plus_1_l : forall n : nat, 1 + n = S n.
Proof.
  intros n. reflexivity. Qed.
Theorem mult_0_l : forall n : nat, 0 * n = 0.
Proof.
  intros n. reflexivity. Qed.

(* The [_l] suffix in the names of these theorems is pronounced "on the left." *)


(* ------------------------------------------------------------------------ *)
(* ------------------------------------------------------------------------ *)
(* Proof by Rewriting *)

(* The following theorem is a bit more interesting than the ones we've seen: *)
Theorem plus_id_example : forall n m : nat,
  n = m ->
  n + n = m + m.

(* Instead of making a universal claim about all numbers n and m,
it talks about a more specialized property that only holds when n = m.
The arrow symbol is pronounced "implies."
As before, we need to be able to reason by assuming we are given such numbers n and m.
We also need to assume the hypothesis n = m. *)

(* Since n and m are arbitrary numbers, we can't just use simplification
to prove this theorem. Instead, we prove it by observing that,
if we are assuming n = m, then we can replace n with m in the goal
statement and obtain an equality with the same expression on both sides.
The tactic that tells Coq to perform this replacement is called rewrite *)
Proof.
  (* move both quantifiers into the context: (We can use any letter here) *)
  intros n m.
  (* move the hypothesis into the context: (hyphotesis is the first part before the arrow) *)
  intros H.
  (* rewrite the goal using the hypothesis: (i take the hyphotesis, and rewrite the "implies" after the arrow) *)
  rewrite -> H.
  reflexivity. Qed.

(* The first line of the proof moves the universally quantified variables n and m into the context.

The second moves the hypothesis n = m into the context and gives it the name H.

The third tells Coq to rewrite the current goal (n + n = m + m) by replacing the left side
of the equality hypothesis H with the right side. *)

(* (The arrow symbol in the rewrite has nothing to do with implication: it tells Coq to
apply the rewrite from left to right. In fact, you can omit the arrow, and Coq will default
to rewriting in this direction. To rewrite from right to left, you can use rewrite <-.
Try making this change in the above proof and see what difference it makes.) *)

(* Proof.
  intros n m.
  intros H.
  rewrite -> H.
  reflexivity. Qed. *)

  (* Exercise: 1 star, standard (plus_id_exercise) *)

  Theorem plus_id_exercise : forall n m o : nat,
  n = m -> m = o -> n + m = m + o.
Proof.
  intros n m o.
  intros H.
  intros B.
  rewrite -> H.
  rewrite -> B.
  reflexivity. Qed.

(* The Check command can also be used to examine the statements of previously declared
lemmas and theorems. The two examples below are lemmas about multiplication that are
proved in the standard library. (We will see how to prove them ourselves in the next chapter.) *)

Check mult_n_O.
(* ===> forall n : nat, 0 = n * 0 *)
Check mult_n_Sm.
(* ===> forall n m : nat, n * m + n = n * S m *)

(* We can use the rewrite tactic with a previously proved theorem instead of a
hypothesis from the context. If the statement of the previously proved theorem involves quantified
variables, as in the example below, Coq tries to instantiate them by matching with the current goal. *)

Theorem mult_n_0_m_0 : forall p q : nat,
  (p * 0) + (q * 0) = 0.
Proof.
  intros p q.
  rewrite <- mult_n_O.
  rewrite <- mult_n_O.
  reflexivity. Qed.

  (* Exercise: 1 star, standard (mult_n_1) *)

(* Use those two lemmas about multiplication that we just checked to prove the following theorem.
Hint: recall that 1 is S O. *)
Theorem mult_n_1 : forall p : nat,
  p * S O = p.
Proof.
  intros p.
  rewrite <- mult_n_Sm.
  rewrite <- mult_n_O.
  reflexivity. Qed.

(* ------------------------------------------------------------------------ *)
(* ------------------------------------------------------------------------ *)
(* Proof by Case Analysis *)

(* Of course, not everything can be proved by simple calculation and rewriting: In general,
unknown, hypothetical values (arbitrary numbers, booleans, lists, etc.) can block simplification.
For example, if we try to prove the following fact using the simpl tactic as above, we get stuck.
(We then use the Abort command to give up on it for the moment.) *)
Theorem plus_1_neq_0_firsttry : forall n : nat,
  (n + 1) =? 0 = false.
Proof.
  intros n.
  simpl. (* does nothing! *)
Abort.

(* The reason for this is that the definitions of both eqb and + begin by performing a match on
their first argument. But here, the first argument to + is the unknown number n and the argument
to eqb is the compound expression n + 1; neither can be simplified. *)

(* To make progress, we need to consider the possible forms of n separately. If n is O,
then we can calculate the final result of (n + 1) =? 0 and check that it is, indeed, false.
And if n = S n' for some n', then, although we don't know exactly what number n + 1 represents,
we can calculate that, at least, it will begin with one S, and this is enough to calculate that,
again, (n + 1) =? 0 will yield false. *)

(* The tactic that tells Coq to consider, separately, the cases where n = O and where n = S n' is called destruct. *)
(* To a better understood, it is good run that *)
Theorem plus_1_neq_0 : forall n : nat,
  (n + 1) =? 0 = false.
Proof.
  intros n. destruct n as [ | n'] eqn:E.
  - reflexivity.
  - reflexivity. Qed.

  (* The destruct generates two subgoals, which we must then prove, separately, in order to get Coq to accept the theorem. *)

  (* The annotation "as [| n']" is called an intro pattern. It tells Coq what variable names to introduce in each subgoal.
  In general, what goes between the square brackets is a list of lists of names, separated by |.
  In this case, the first component is empty, since the O constructor is nullary (it doesn't have any arguments). The second component gives a single name, n', since S is a unary constructor.*)

(* either n = 0 or n = S n' for some n'
The eqn:E annotation tells destruct to give the name E to this equation.
Leaving off the eqn:E annotation causes Coq to elide these assumptions in the subgoals
in this case (n = 0 or n = S n')
This slightly streamlines proofs where the assumptions are not explicitly used
but it is better practice to keep them for the sake of documentation, as they can help keep you oriented when working with the subgoals *)

(* The - signs on the second and third lines are called bullets,
and they mark the parts of the proof that correspond to the two generated subgoals. 
In this example, each of the subgoals is easily proved by a single use of reflexivity, which itself performs some simplification 

e.g., the second one simplifies (S n' + 1) =? 0 to false by first rewriting (S n' + 1) to S (n' + 1), then unfolding eqb, and then simplifying the match *)

(* Marking cases with bullets is optional: if bullets are not present, Coq simply asks you to prove each subgoal in sequence, one at a time. But it is a good idea to use bullets.
Also, bullets instruct Coq to ensure that a subgoal is complete before trying to verify the next one *)

(* For example, we use it next to prove that boolean negation is involutive *)
Theorem negb_involutive : forall b : bool,
  negb (negb b) = b.
Proof.
  intros b. destruct b eqn:E.
  - reflexivity.
  - reflexivity. Qed.

(* Note that the destruct here has no as clause because none of the subcases of the destruct need to bind any variables, so there is no need to specify any names *)

(* It is sometimes useful to invoke destruct inside a subgoal, generating yet more proof obligations. In this case, we use different kinds of bullets to mark goals on different "levels." For example: *)

Theorem andb_commutative : forall b c, andb b c = andb c b.
Proof.
  intros b c. destruct b eqn:Eb.
  - destruct c eqn:Ec.
    + reflexivity.
    + reflexivity.
  - destruct c eqn:Ec.
    + reflexivity.
    + reflexivity.
Qed.

(* Besides - and +, we can use × (asterisk) or any repetition of a bullet symbol (e.g. -- or ***)
(* as a bullet. We can also enclose sub-proofs in curly braces: *)
Theorem andb_commutative' : forall b c, andb b c = andb c b.
Proof.
  intros b c. destruct b eqn:Eb.
  { destruct c eqn:Ec.
    { reflexivity. }
    { reflexivity. } }
  { 
    destruct c eqn:Ec.
      { 
        reflexivity.
      }
      {
        reflexivity.
      }
  }
Qed.

Theorem andb_commutative'' : forall b c, andb b c = andb c b.
Proof.
  intros b c. destruct b eqn:Eb.
  * destruct c eqn:Ec.
    ** reflexivity.
    ** reflexivity.
  * destruct c eqn:Ec.
    ** reflexivity.
    ** reflexivity.
Qed.

(* curly braces allow us to reuse the same bullet shapes at multiple levels in a proof. The choice of braces, bullets, or a combination of the two is purely a matter of taste *)

Theorem andb3_exchange :
  forall b c d, andb (andb b c) d = andb (andb b d) c.
Proof.
  intros b c d. destruct b eqn:Eb.
  - destruct c eqn:Ec.
    { destruct d eqn:Ed.
      - reflexivity.
      - reflexivity. }
    { destruct d eqn:Ed.
      - reflexivity.
      - reflexivity. }
  - destruct c eqn:Ec.
    { destruct d eqn:Ed.
      - reflexivity.
      - reflexivity. }
    { destruct d eqn:Ed.
      - reflexivity.
      - reflexivity. }
Qed.

(* ------------------------------------------------------------------------ *)
(* Exercise: 2 stars, standard (andb_true_elim2) *)

(*
  Prove the following claim, marking cases (and subcases) with bullets when you use destruct.
  Hint: You will eventually need to destruct both Booleans, as in the theorems above. But, delay introducing the hypothesis until after you have an opportunity to simplify it.
  Hint 2: When you reach contradiction in the hypotheses, focus on how to rewrite with that contradiction.
*)

Theorem plus_1_neq_0' : forall n : nat,
  (n + 1) =? 0 = false.
Proof.
  intros n. destruct n as [ | n'] eqn:E.
  - reflexivity.
  - reflexivity. Qed.

Theorem andb_true_elim2 : forall b c : bool,
  andb b c = true -> c = true.
Proof.
  intros b c. destruct c eqn:E.
  - destruct b eqn:Eb.
    { reflexivity. }
    { reflexivity. }
  - destruct c eqn:Ec.
    { destruct c eqn:Eb.
        { reflexivity.}}
Qed.