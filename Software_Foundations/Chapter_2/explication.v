(* The new type is called day and its member are `monday, tuesday, etc`. *)
Inductive day : Type :=
    | monday
    | tueday
    | wednesday
    | thurday
    | friday
    | saturday
    | sunday.

(* Having defined day, we can write function that operate on days. *)
Definition next_weekday (d:day) : day :=
  match d with
  | monday ⇒ tuesday
  | tuesday ⇒ wednesday
  | wednesday ⇒ thursday
  | thursday ⇒ friday
  | friday ⇒ monday
  | saturday ⇒ monday
  | sunday ⇒ monday
  end.

Compute (next_weekday friday).
(* ==> monday : day *)

Compute (next_weekday (next_weekday saturday)).
(* ==> tuesday : day *)