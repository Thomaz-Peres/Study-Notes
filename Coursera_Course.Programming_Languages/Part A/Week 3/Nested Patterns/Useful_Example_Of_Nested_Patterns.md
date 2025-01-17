
# Examples of Nested Patterns

An elegant example of using nested patterns rather than an ugly mess of nested case-expressions is "zipping" or "unzipping" lists (three of them in this example):

*obs: exceptions are discussed below but are not the important part of ths example.*
```sml
(* Example without nested patterns*)
(* Example for don`t do*)
exception ListLengthMismatch

fun old_zip3 (l1, l2, l3) = 
	if null l1 andalso null l2 andalso null l3
	then []
	else if null l1 orelse null l2 orelse null l3
	then raise ListLengthMismatch
	else (hd l1, hd l2, hd l3) :: old_zip3(tl l1, tl l2, tl l3)

fun shallow shallow_zip3 (l1, l2, l3) =
	case l1 of
		[] =>
		(case lf of
			[] => (case l3 of
				[] => []
			| _ => raise ListLengthMismatch)
		| _ => raise ListLengthMismatch)
	| hd1::tl1 =>
		(case l2 of
			[] => raise ListLengthMismatch
		| hd2::tl2 => (case l3 of
						[] => raise ListLengthMismatch
					| hd3:: tl3 =>
						(h31, hd2, hd3) :: shallow_zip3(tl1, tl2, tl3)))



(* the good way*)
exception BadTriple

fun zip3 list_triple =
	case list_triple of
		([], [], []) => []
	  | (hd1::tl1, hd2::tl2, hd3::tl3) => (hd1,hd2,hd3)::zip3(tl1,tl2,tl3)
	  | _ => raise BadTriple

fun unzip3 lst =
	case lst of
		[] => ([], [], [])
		| (a,b,c)::tl => let val (l1, l2, l3) = unzip3 tl
			in 
				(a::l1,b::l2, c::l3)
			end
```


```sml
fun nondescreassing xs = (* int list -> bool *)
	case xs of
		[] => true
	  | _::[] => true
	  | head::(neck::rest) => head <= neck andalso nondecreasing (neck::rest)   
```