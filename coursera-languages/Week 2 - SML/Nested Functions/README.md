## Nested Functions

Mested Functions is used to use a function inside another function


```sml
fun countup_from1(x : int) =
    let 
        fun count (from : int) =
        if from = x
        then x::[]
        else from :: count(from+1)
    in
        count(1)
    end
```


