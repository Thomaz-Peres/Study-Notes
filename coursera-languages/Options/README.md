There's no such thing as the maximum integer in an empty list and returning zero was always an awkward workaround. (strange altenaltive solution)

Example:
```sml
fun good_max (xs : int list) =
    if null xs
    then 0
    else if null (tl xs)
    then hd xs
```

To use `option` you can write: `NONE or SOME`  

Accessing options:
`isSome has type 'a option -> bool
valOf has type 'a option -> 'a (exception if given NONE)`


Here is the old way, evaluates to 0 on empty list
```sml
fun ond_max (xs : int list) =
	if null xs
	then 0
	else if null (tl xs)
	then hd xs
	else
		let val tl_ans = old_max(tl xs)
		in
			if hd xs > tl_ans
			then hd xs
			else tl_ans;
		end
```

Better version level 1: (in this version always check the list is empty (NONE))
`fn : int list -> int option`
```sml
 fun max1 (xs : int list) =
	 if null xs
	 the NONE
	 else
		let val tl_and = max1(tl xs)
		in if isSome tl_ans andalso valOf tl_ans > hd xs
			 then tl_ans
			 else SOME (hd xs)
		end
```

![image](https://user-images.githubusercontent.com/58439854/211212865-d34a9bc1-cb49-4826-a3e5-66f8e7df636c.png)

![[Pasted image 20230108154435.png]]\

![[Pasted image 20230108154553.png]]

![[Pasted image 20230108154608.png]]

Better version level 2: (in this case, when the list is almost empty only returns the value)
`int list -> int`
```sml
fun max2 (xs : int list) = 
	if null xs
	then NONE
	else let
		fun max_nonempty (xs : int list) =
		then hd xs
		else let val tl_ans = max_nonempty(tl xs)
			in 
				if hd xs > tl_ans
				then hd xs
				else tl_ans
			end
		in
			SOME (max_nonempty xs)
		end
 ```
![[Pasted image 20230108155934.png]]