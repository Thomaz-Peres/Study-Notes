## Introducing Lists

To reate a list in SML = val it = [1, 2, 3];

To put a value in list, use 1 :: x
(you put the value 1 in the begging of a list)

To put an value in a final of list z @ [1];
(a list into a list 1 it the final of a list) https://stackoverflow.com/questions/42148055/sml-how-to-append-an-element-to-a-list-in-sml

To take the first value in an list = hd it;

you can use tl too, like = hd (tl it2) = 2


![image](https://user-images.githubusercontent.com/58439854/210684988-23e2d731-8c92-42b9-9df1-cf4033b79a0e.png)

## List functions

it is a convention to give variables that hold lists names that end in s, but whatever


This is a 
```sml
fun sum_list(xs : int list) = 
    if null xs
    then 0
    else hd xs + sum_list(tl xs) (* pega o primeiro elemento da lista e soma com o ultimo *)
```
This is a simple recursive list example

The function works with receiving a int list, and return a int (int list -> int)

![image](https://user-images.githubusercontent.com/58439854/211104173-ff28ffbc-4185-4f44-8274-fd9b38f02c20.png)

Calling the function

![image](https://user-images.githubusercontent.com/58439854/211104885-633d8d8b-e6ef-48a6-9f82-746cef5c9d35.png)

- function who takes an int and return an int list

When the function is called, she worksd like, I send 7 and return [7, 6, 5, 4, 3, 2, 1]

```sml
fun countdown(x : int) = 
    if 0 
    then []
    else
    x :: countdown(x-1)
```

Examples:

![image](https://user-images.githubusercontent.com/58439854/211161295-a1032c56-d474-4a8e-b0f4-ea2e32900c89.png)

![image](https://user-images.githubusercontent.com/58439854/211161324-9191ebec-8958-4f0e-b6af-adb3fbf08109.png)

![image](https://user-images.githubusercontent.com/58439854/211161350-a1c3c1b6-1a27-4ff0-b0f2-48d6e781fe84.png)


- another example to append lists with recursion

```sml
fun append (xs : int lists, ys : int list) = 
    if null xs
    then ys
    else (hd xs) :: append((tl xs), ys)
```

- sum pairs of a list of tuples

this function I sum the first tuple with another tuples

```sml
fun sum_pairs_list (xs : (int * int) list) =
    if null xs
    then 0
    else #1 (hd xs) + #2 (hd xs) + sum_pair_list(tl xs)
```

Examples:

![image](https://user-images.githubusercontent.com/58439854/211163756-7ba9835c-fe32-4234-a6e6-cbb7da6fc159.png)


-  taking the firsts elements in the tuples int list

```sml
fun firsts (xs : (int * int) list) =
    if null xs
    then []
    else (#1 (hd xs)) :: firsts(tl xs)
```

Examples:

![image](https://user-images.githubusercontent.com/58439854/211163963-634df995-e281-4c17-87aa-a11d8865690a.png)