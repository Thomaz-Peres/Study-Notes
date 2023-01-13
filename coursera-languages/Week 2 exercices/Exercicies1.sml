(* (int * int * int) * (int * int * int) -> bool *)
(* year, month, day *)
fun is_older (pr : (int*int*int) * (int*int*int)) =
    if (#1 (#1 pr) < #1 (#2 pr))
    then true
    else if ((#1 (#1 pr) = #1 (#2 pr)) andalso (#2 (#1 pr) = #2 (#2 pr)) andalso (#3 (#1 pr) = #3 (#2 pr) ))
    then false
    else
    false