Module NatPlayground.

Inductive nat : Type :=
  | O
  | S (n : nat).

  Inductive nat' : Type :=
  | stop
  | tick (foo : nat').

Definition pred (n : nat) : nat :=
  match n with
  | O => O
  | S n' => n'
  end.

Compute (pred (O, O)).  