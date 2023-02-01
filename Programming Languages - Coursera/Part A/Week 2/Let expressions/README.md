Introducing to local varaibles with let expressions

## Let Expressions 

- syntax

![image](https://user-images.githubusercontent.com/58439854/211166133-707e084b-543e-4197-8c55-c568e761a208.png)

```sml
fun silly1 (z : int) = 
    let
        val x = if z > 0 then z else 34
        val y = x + z + 9
    in
        if x > z then x * 2 else y * y
    end
```

I can use let expressions like this too

```sml
fun silly2() =
    let 
        val x = 1
    in
        (let val x = 2 int x + 1 end) + (let val y  = x + 2 int Y + 1 end)
    end
```


## Let and efficiency

Let Expressions to Avoid Repeated Computation

Bad example:

```sml
fun bad_max (xs : int list) =
    if null xs
    then 0
    else if null (tl xs)
    then hd xs
    else if hd xs > bad_max(tl xs)
    then hd xs
    else bad_max(tl xs)
```

Good example:

```sml
fun good_max (xs : int list) =
    if null xs
    then 0
    else if null (tl xs)

    then hd xs
    else
        let val tl_ans = good_max(tl xd)
        in
            if hd xs > tl_ans
            then hd xs
            else tl_ans
        end
```