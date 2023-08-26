From LF Require Export Basics.

(* Proof by Induction *)

(* We can prove that 0 is a neutral element for + on the left using just reflexivity.
But the proof that it is also a neutral element on the right ... *)

Theorem add_0_r_firsttry : forall n:nat,
  n + 0 = n.