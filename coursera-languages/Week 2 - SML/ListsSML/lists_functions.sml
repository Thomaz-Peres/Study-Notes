fun sum_list(xs : int list) = 
    if null xs
    then 0
    else hd xs + sum_list(tl xs)

fun countdown(x : int) = 
    if x = 0
    then []
    else
    x :: countdown(x - 1)

fun append (xs : int list, ys : int list) = 
    if null xs
    then ys
    else (hd xs) :: append((tl xs), ys)

fun sum_pairs_lists (xs : (int * int) list) =
    if null xs
    then 0
    else #1 (hd xs) + #2 (hd xs) + sum_pairs_lists(tl xs)

fun firsts (xs : (int * int) list) =
    if null xs
    then []
    else (#1 (hd xs)) :: firsts(tl xs)