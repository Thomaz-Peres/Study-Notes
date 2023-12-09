(* f has type MyType -> int *)
fun f x =
    case x of
          Pizza => 3
        | TwoInts(i1, i2) => i1 + i2
        | Str s => String.size s