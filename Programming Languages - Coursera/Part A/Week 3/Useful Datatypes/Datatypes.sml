datatype exp = 
    Constant of int |
    Negate of exp |
    Add of exp * exp |
    Multiply of exp * exp


fun eval (e) =
    case e of
        Constant i => i |
        Negate e2 => ~ (eval e2) |
        Add(e1,e2) => (eval e1) + (eval e2) |
        Multiply(e1,e2) => (eval e1) * (eval e2)


fun number_of_add e =
    case e of
        Constant i => 0 |
        Negate e2 => ~ (number_of_adds e2) |
        Add(e1, e2) => 1 + number_of_adds e1 + number_of_adds e2 |
        Multiply(e1, e2) => number_of_adds e1 * number_of_adds e2