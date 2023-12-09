# Type Synonyms

Type synonyms creates another name for an existing type that is entirely interchangeable with the existing type.

For example, if we write:
```sml
type foo = int;
```
Then we can write **foo** wherever we write int and vice-versa.
![image](https://user-images.githubusercontent.com/58439854/224166408-e45d4c4f-71d0-4026-8b40-02e99888cc4f.png)
![image](https://user-images.githubusercontent.com/58439854/224166817-1c76d7d0-8da0-4f09-a615-8975ad98f55d.png)
---
For complicated types, it can be convenient to create types synonyms. Some examples for types we created above:

```sml
type card = suit * rank

type name_record { 
student_num : int option,
first : string,
middle : string option,
last : string }

```
Just remember these synonyms are fully interchangeable. For example, if a homework question requires a function of type card -> int and the REPL reports your solution has type suit * rank -> int, this is okay because the types are “the same.” 

In contrast, datatype bindings introduce a type that is not the same as any existing type. It creates constructors that produces values of this new type. So, for example, the only type that is the same as suit is suit unless we later introduce a synonym for it.

