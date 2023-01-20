(* (int * int * int) * (int * int * int) -> bool *)
(* year, month, day *)
(* test 1 *)
fun is_older (pr : (int*int*int) * (int*int*int)) =
    if (#1 (#1 pr) < #1 (#2 pr))
    then true
    else if ((#1 (#1 pr) = #1 (#2 pr)) andalso (#2 (#1 pr) = #2 (#2 pr)) andalso (#3 (#1 pr) = #3 (#2 pr) ))
    then false
    else
    false


(* [int * int * int] list * int -> int *)
(* year, month, day *)
(* test 2 *)
fun number_in_month (xs : (int * int * int) list, m : int) =
    if null xs then 0
    else let
            val y = 0 : int
        in
        if #2 (hd xs) = m then (y + 1) + number_in_month(tl xs, m)
        else
        number_in_month(tl xs, m)
        end

(* [int * int * int] list * int list -> int *)
(* year, month, day *)
(* Assume the list of months has no number repeated. *)
(* test 3 *)
fun number_in_months (xs : (int * int * int) list, m : int list) = 
    if null m then 0
    else number_in_month(xs, hd m) + number_in_months(xs, tl m)


(* [int * int * int] list * int -> int list *)
(* year, month, day *)
(* test 4 *)
fun dates_in_month (xs : (int * int * int) list, m : int) =
    if null xs then []
    else if #2 (hd xs) = m then hd xs :: dates_in_month(tl xs, m)
    else dates_in_month(tl xs, m)


(* [int * int * int] list * int list -> int list *)
(* year, month, day *)
(* test 5 *)
fun dates_in_months (xs : (int * int * int) list, m : int list) =
    if null m then []
    else dates_in_month(xs, hd m) @ dates_in_months(xs, tl m)


(* string list * int -> string *)
(* year, month, day *)
(* test 6 *)
fun get_nth (w : string list, x : int) =
    if null w then "fail"
    else if x = 1 then (hd w)
    else
    get_nth(tl w, x-1)