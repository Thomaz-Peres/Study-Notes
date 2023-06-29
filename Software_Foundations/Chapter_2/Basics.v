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

Example test_orb1:  (orb true  false) = true.
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

