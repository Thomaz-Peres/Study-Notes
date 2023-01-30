(* (int * int * int) * (int * int * int) -> bool *)
(* year, month, day *)
(* test 1 *)
fun is_older (pr : (int*int*int) * (int*int*int)) =
    if (#1 (#1 pr) < #1 (#2 pr)) then true
    else if (#1 (#1 pr) <= #1 (#2 pr)) then true
    else if (#1 (#1 pr) > #1 (#2 pr)) then false
    else if (#2 (#1 pr) <= #2 (#2 pr)) then true
    else if (#2 (#1 pr) > #2 (#2 pr)) then false
    else if (#3 (#1 pr) <= #3 (#2 pr)) then true
    else
    false

(* [int * int * int] list * int -> int *)
(* year, month, day *)
(* test 2 *)
fun number_in_month (xs : (int * int * int) list, m : int) =
    if null xs then 0
    else let
            val y = 1 : int
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
    if null w then hd w
    else if x = 1 then (hd w)
    else
    get_nth(tl w, x-1)


(* (int * int * int) -> string *)
(* year, month, day *)
(* test 7 *)
fun date_to_string (date : int * int * int) =
    if #1 date <= 0 then "false"
    else
    let 
        val ms = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"] : string list
    in 
        if #2 date < 1 orelse #2 date > 12 
            then "false"
        else
            (get_nth(ms, #2 date)) ^ " " ^ Int.toString(#3 date) ^ ", " ^ Int.toString(#1 date)
    end


(* int * int list -> int *)
(* test 8 *)
fun number_before_reaching_sum (sum : int, xs : int list) =
    if hd xs >= sum
    then 0
    else
    let val x = 1 : int
    in
        x + number_before_reaching_sum(sum - hd xs, tl xs)
    end

(* int -> int *)
(* test 9 *)
fun what_month (day : int) =
    if day <= 0 andalso day > 365
    then 0
    else
    let
        val days_in_month = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    in
        number_before_reaching_sum(day, days_in_month) + 1
    end

(* int * int -> int list *)
(* test 10 *)
fun month_range (d1 : int, d2 : int) =
    if d1 > d2 then []
    else
    what_month d1 :: month_range(d1 + 1, d2)

(* int * int -> int list *)
(* test 11 *)
fun oldest (xs : (int * int * int) list) =
    if null xs
    then NONE
    else
    let
        fun max (xs : (int * int * int) list) = 
            if null (tl xs) then hd xs
            else
            let
                val tl_old = max(tl xs)
            in 
                if is_older(hd xs, tl_old) then hd xs
                else tl_old
            end
    in
        SOME(max xs)
    end

fun remove_duplicates (zs : int list) = 
    if null zs then []
    else 
    let
        fun remove (z : int, xs : int list) =
        if null xs then []
        else let val list_filter = remove(z, tl xs)
        in
            if hd xs = z then list_filter
            else hd xs :: list_filter
        end
    in
        hd zs :: remove_duplicates(remove(hd zs, tl zs))
    end


(*  Challenge Problem: Write functions number_in_months_challenge and dates_in_months_challenge
that are like your solutions to problems 3 and 5 except having a month in the second argument multiple
times has no more effect than having it once. (Hint: Remove duplicates, then use previous work. *)
(* [int * int * int] list * int list -> int *)
(* year, month, day *)
(* test 12 *)
fun number_in_months_challenge (xs : (int * int * int) list, m : int list) = 
    if null m then 0
    else number_in_months(xs, remove_duplicates m)


(*  Challenge Problem: Write functions number_in_months_challenge and dates_in_months_challenge
that are like your solutions to problems 3 and 5 except having a month in the second argument multiple
times has no more effect than having it once. (Hint: Remove duplicates, then use previous work. *)
(* [int * int * int] list * int list -> int list *)
(* year, month, day *)
(* test 12 *)
fun dates_in_months_challenge (xs : (int * int * int) list, m : int list) =
    if null m then []
    else dates_in_months(xs, remove_duplicates m)


(* Challenge Problem: Write a function reasonable_date that takes a date and determines if it
describes a real date in the common era. A “real date” has a positive year (year 0 did not exist), a
month between 1 and 12, and a day appropriate for the month. Solutions should properly handle leap
years. Leap years are years that are either divisible by 400 or divisible by 4 but not divisible by 100.
(Do not worry about days possibly lost in the conversion to the Gregorian calendar in the Late 1500s.) *)

(* [int * int * int] list * int list -> int list *)
(* test 13 *)
fun reasonable_date (date : int * int * int) =
    if #1 date < 4 andalso (#2 date < 1 orelse #2 date > 12) andalso (#3 date < 1 orelse #3 date > 365) then false
    else if (#1 date mod 400 = 0) orelse (#1 date mod 4 = 0) andalso not (#1 date mod 100 = 0)
    then true
    else false