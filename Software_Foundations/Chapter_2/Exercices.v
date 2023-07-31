(* Inductive bool : Type :=
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

Notation "x && y" := (andb x y).
Notation "x || y" := (orb x y).

(* Standard (nandb) *)
Definition nandb (b1:bool) (b2:bool) : bool :=
    if b1 && b2 then false
    else true.

Example test_nandb1: (nandb true false) = true.
Proof. reflexivity. Qed.
Example test_nandb2: (nandb false false) = true.
Proof. reflexivity. Qed.
Example test_nandb3: (nandb false true) = true.
Proof. reflexivity. Qed.
Example test_nandb4: (nandb true true) = false.
Proof. reflexivity. Qed.


(* Standard (andb3) *)

Definition andb3 (b1:bool) (b2:bool) (b3:bool) : bool :=
  if b1 && b2 && b3 then true
  else false.
Example test_andb31: (andb3 true true true) = true.
Proof. simpl. reflexivity. Qed.
Example test_andb32: (andb3 false true true) = false.
Proof. simpl. reflexivity. Qed.
Example test_andb33: (andb3 true false true) = false.
Proof. simpl. reflexivity. Qed.
Example test_andb34: (andb3 true true false) = false.
Proof. simpl. reflexivity. Qed.

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

Fixpoint leb (n m : nat) : bool :=
  match n with
  | O => true
  | S n' =>
      match m with
      | O => false
      | S m' => leb n' m'
      end
  end.

Notation "x =? y" := (eqb x y) (at level 70) : nat_scope.
Notation "x <=? y" := (leb x y) (at level 70) : nat_scope.
Example test_leb3': (4 <=? 2) = false.
Proof. simpl. reflexivity. Qed.


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

 *)

 (*
  Prove the following claim, marking cases (and subcases) with bullets when you use destruct.
  Hint: You will eventually need to destruct both Booleans, as in the theorems above. But, delay introducing the hypothesis until after you have an opportunity to simplify it.
  Hint 2: When you reach contradiction in the hypotheses, focus on how to rewrite with that contradiction.
*)

Theorem andb_true_elim2 : forall b c : bool,
 andb b c = true -> c = true.
Proof.
 intros b c. destruct c eqn:E.
 - destruct b eqn:Eb.
   { destruct c eqn:Ec.
      { reflexivity. }
      { reflexivity. }
    }
   { reflexivity. }
 - destruct b eqn:Eb.
   { destruct c eqn:Ec.
       { reflexivity. }
       { reflexivity. }
  }
Qed.