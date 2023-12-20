This thinks in here, I'm learned from the [own rust book](https://doc.rust-lang.org/book/ch12-00-an-io-project.html)
and [comprenhensive ruse](https://google.github.io/comprehensive-rust/)

I will improving this in some time. (like I said with all this notations 😅).

# Understanding Ownership

Ownership is Rust’s most unique feature and has deep implications for the rest of the language. It enables Rust to make memory safety guarantees without needing a garbage collector, so it’s important to understand how ownership works. In this chapter, we’ll talk about ownership as well as several related features: borrowing, slices, and how Rust lays data out in memory.

## What Is Ownership?

_Ownership_ is a set of rules that govern how a Rust program manages memory. All programs have to manage the way they use a computer’s memory while running. Some languages have a garbage collection that regularly looks for no-longer-used memory.
In other languages, the programmer must explicitly allocate and free the memory.

Rust uses a third approach: memory is managed through a system of ownership with a set of rules that the compiler checks.

None of the features of ownership will slow down your program while it’s running

You’ll learn ownership by working through some examples that focus on a very common data structure: strings

To learn about how to add the `Copy` trait annotation to your type to implement the trait,
see [Derivable Traits](https://doc.rust-lang.org/book/appendix-03-derivable-traits.html) in Appendix C.

## Ownership rules

- Each value is rust has an `owner`;
- There can only be one owner at a time.
- When the owner goes out of scope, the value will be dropped.

## Ownership and functions

```rust
fn main() {
    let s = String::from("hello");  // s comes into scope

    takes_ownership(s);             // s's value moves into the function...
                                    // ... and so is no longer valid here

    println!("{}", s); // this give me an error, but if in "takes_ownership" I'm use (s.clone()) not will give a error

    let x = 5;                      // x comes into scope

    makes_copy(x);                  // x would move into the function,
                                    // but i32 is Copy, so it's okay to still
                                    // use x afterward

    println!("{}", x); // this not give me an error

} // Here, x goes out of scope, then s. But because s's value was moved, nothing
  // special happens.

fn takes_ownership(some_string: String) { // some_string comes into scope
    println!("{}", some_string);
} // Here, some_string goes out of scope and `drop` is called. The backing
  // memory is freed.

fn makes_copy(some_integer: i32) { // some_integer comes into scope
    println!("{}", some_integer);
} // Here, some_integer goes out of scope. Nothing special happens.
```

## The Stack and the Heap

In rust whether a value is on the stack or the heap affects how the language behaves and why you have to make certain decisions.

Both the stack and the heap are parts of memory available to your code to use at runtime, but they are structured in different ways

The **stack** stores values in the order it gets them and removes the values in the opposite order. This is referred to as last in, first out.

All data stored on the stack must have a known, fixed size. 
Data with an unknown size at compile time or a size that might change must be stored on the heap instead.
Adding data is called pushing onto the stack, and removing data is called popping off the stack

The **heap** is less organized: when you put data on the heap, you request a certain amount of space.
The memory allocator finds an empty spot in the heap that is big enough, marks it as being in use, and returns a pointer, which is the address of that location (pointer in C).

Pushing values onto the stack is not considered allocating.

Because the pointer to the heap is a known, fixed size, you can store the pointer on the stack, but when you want the actual data, you must follow the pointer.

_______________________________________________________
Pushing to the stack is faster than allocating on the heap because the allocator never has to search for a place to store new data. because is always on the top.

Comparatively, allocating space on the heap requires more work because the allocator must first find a big enough space to hold the data and then perform **bookkeeping** to prepare for the next allocation.

A processor can do its job better if it works on data that’s close to other data (as it is on the stack) rather than farther away (as it can be on the heap).

When your code calls a function, the values passed into the function (including, potentially, pointers to data on the heap) and the function’s local variables get pushed onto the stack. When the function is over, those values get popped off the stack.

Keeping track of what parts of code are using what data on the heap, minimizing the amount of duplicate data on the heap, and cleaning up unused data on the heap so you don’t run out of space are all problems that ownership addresses.
________________________________________
So, what’s the difference here? Why can String be mutated but literals cannot?
The difference is in how these two types deal with memory.

```rust
var s = "text"; // this is literal string

var mut z = String::from("Hello"); // this a String, of course
```

## Memory and Allocation

In the case of a string literal, we know the contents at compile time, so the text is hardcoded directly into the final executable. This is why string literals are fast and efficient. But these properties only come from the string literal’s immutability. Unfortunately, we can’t put a blob of memory into the binary for each piece of text whose size is unknown at compile time and whose size might change while running the program.

With the String type, in order to support a mutable, growable piece of text, we need to allocate an amount of memory on the heap, unknown at compile time, to hold the contents. This means:

- The memory must be requested from the memory allocator at runtime.
- We need a way of returning this memory to the allocator when we’re done with our String.

That first part is done by us: when we call String::from, its implementation requests the memory it needs.

Rust takes a different path: the memory is automatically returned once the variable that owns it goes out of scope. Here’s a version of our scope example from Listing 4-1 using a String instead of a string literal:

```rust
    {
        let s = String::from("hello"); // s is valid from this point forward

        // do stuff with s

    }// this scope is now over, and s is no longer valid
```

There is a natural point at which we can return the memory our String needs to the allocator: when s goes out of scope. When a variable goes out of scope, Rust calls a special function for us. This function is called drop, and it’s where the author of String can put the code to return the memory. Rust calls drop automatically at the closing curly bracket.
```
Note: In C++, this pattern of deallocating resources at the end of an item’s lifetime is sometimes called Resource Acquisition Is Initialization (RAII). The drop function in Rust will be familiar to you if you’ve used RAII patterns.
```

______________________________________________________________
### Variables and Data Interacting with Move

```rust
    let x = 5;
    let y = x;
```

```rust
    let s1 = String::from("hello");
    let s2 = s1;
```

This looks very similar, so we might assume that the way it works would be the same: that is, the second line would make a copy of the value in `s1` and bind it to `s2`. But this isn’t quite what happens.

When we assign `s1` to `s2`, the String data is copied, meaning we copy the pointer, the length, and the capacity that are on the stack. We do not copy the data on the heap that the pointer refers to. In other words, the data representation in memory looks like below.

![image](https://github.com/Thomaz-Peres/Thomaz-Peres/assets/58439854/c35dc93d-7269-4b2b-91ce-1bc50e483823)

The representation does not look like, which is what memory would look like if Rust instead copied the heap data as well. If Rust did this, the operation `s2 = s1` could be very expensive in terms of runtime performance if the data on the heap were large.
![image](https://github.com/Thomaz-Peres/Thomaz-Peres/assets/58439854/149971cd-5376-403e-bc9a-3cdbaa3a4859)

Earlier, we said that when a variable goes out of scope, Rust automatically calls the drop function and cleans up the heap memory for that variable. But Figure 4-2 shows both data pointers pointing to the same location. This is a problem: when s2 and s1 go out of scope, they will both try to free the same memory. This is known as a double free error and is one of the memory safety bugs we mentioned previously. Freeing memory twice can lead to memory corruption, which can potentially lead to security vulnerabilities.

To ensure memory safety, after theeelin `let s2 = s1;`, Rust considers s1 as no longer valid. Therefore, Rust doesn't need to free anything when s1 goes out of scope. Check out what happer when you try to use `s1` after `s2` is created; it won't work
```rust
    let s1 = String::from("hello");
    let s2 = s1;

    println!("{}, world!", s1); // this will give an error
```

________________________________
```rust
    let x = 5;
    let y = x;

    println!("x = {}, y = {}", x, y);
```

But this code seems to contradict what we just learned: we don’t have a call to clone, but x is still valid and wasn’t moved into y.

This happens because intergers, that have a known size at compile time are stored entirely on the stack, so copies of the actual values are quick to make.

Rust has a special annotation called the `Copy` trait that we can place on types that are stored on the stack. Rust won’t let us annotate a type with `Copy` if the type, or any of its parts, has implemented the `Drop` trait.

So, what types implement the `Copy` trait?
- All the integer types, such as u32.
- The Boolean type, bool, with values true and false.
- All the floating-point types, such as f64.
- The character type, char.
- Tuples, if they only contain types that also implement Copy. For example, (i32, i32) implements Copy, but (i32, String) does not.


_______________________________________


### Reference and Borrowing

The ampersands (&) represent `references`.

When we send a reference, the variable isn't dropped because the `&s (reference of s)`
doesn't have ownership.

When functions have references as parameters instead of the actual values,
we won’t need to return the values in order to give back ownership, because we never had ownership.

We call the action of creating a reference `borrowing (empréstimo)`.
When you're done, you have to give it back. You don't own it.

So, what happens if we try to modify something we’re borrowing?
Try the code in above. `Spoiler alert`: it doesn’t work!

```rust
fn main() {
    let s = String::from("hello");

    change(&s);
}

fn change(some_string: &String) {
    some_string.push_str(", world");
}
```

The `&s1` syntax lets us create a reference that refers to the value of `s1` but does not own it.
Because it does not own it, the value it points to will not be dropped when the reference stops being used.

```rust
// Here I can called s1 again, because I passed a reference to the value,
// not the value to a neww variabel
fn main() {
    let s1 = String::from("hello");

    let (s2, len) = calculate_length(&s1);
    println!("{s1}");

    println!("The length of '{}' is {}.", s2, len);
}

fn calculate_length(s: &String) -> (&String, usize) {
    let length = s.len(); // len() returns the length of a String

    (&s, length)
}

// Here I can't called s1 again, because I passed the value,
// not a reference
fn main() {
    let s1 = String::from("hello");

    let (s2, len) = calculate_length(s1);
    println!("{s1}");


    println!("The length of '{}' is {}.", s2, len);
}

fn calculate_length(s: String) -> (String, usize) {
    let length = s.len(); // len() returns the length of a String

    (&s, length)
}
```

### Mutable References

Mutable references have one big restriction: if you have a mutable reference to a value,
you can have no other references to that value. This code that attempts to create two mutable
references to `s` will fail:

```rust
    let mut s = String::from("hello");

    let r1 = &mut s;
    let r2 = &mut s;

    println!("{}, {}", r1, r2);
```

This error says that this code is invalid because we cannot borrow s as mutable more than once at a time.

The restriction preventing multiple mutable references to the same data at the same time allows for mutation but in a very controlled fashion. It’s something that new Rustaceans struggle with because most languages let you mutate whenever you’d like. The benefit of having this restriction is that Rust can prevent data races at compile time. A data race is similar to a race condition and happens when these three behaviors occur:

- Two or more pointers access the same data at the same time.
- At least one of the pointers is being used to write to the data.
- There’s no mechanism being used to synchronize access to the data.

As always, we can use curly brackets to create a new scope, allowing for multiple mutable references, just not simultaneous ones:

```rust
    let mut s = String::from("hello");

    {
        let r1 = &mut s;
    } // r1 goes out of scope here, so we can make a new reference with no problems.

    let r2 = &mut s;
```


Rust enforces a similar rule for combining mutable and immutable references. This code results in an error:
```rust
    let mut s = String::from("hello");

    let r1 = &s; // no problem
    let r2 = &s; // no problem
    let r3 = &mut s; // BIG PROBLEM

    println!("{}, {}, and {}", r1, r2, r3);
```
Whew! We also cannot have a mutable reference while we have an immutable one to the same value.

Users of an immutable reference don’t expect the value to suddenly change out from under them! However, multiple immutable references are allowed because no one who is just reading the data has the ability to affect anyone else’s reading of the data.

Note that a reference’s scope starts from where it is introduced and continues through the last time that reference is used. For instance, this code will compile because the last usage of the immutable references, the `println!`, occurs before the mutable reference is introduced:

```rust
    let mut s = String::from("hello");

    let r1 = &s; // no problem
    let r2 = &s; // no problem
    println!("{} and {}", r1, r2);
    // variables r1 and r2 will not be used after this point

    let r3 = &mut s; // no problem
    println!("{}", r3);
```

## Dangling References

In Rust, the compiler guarantees that references will never be dangling references:
If you have a reference to some data, the compiler will ensure that the data will not go out
of scope before the reference to the data does.

This is a dangling reference, and will return a error:

```rust
fn main() {
    let reference_to_nothing = dangle();
}

fn dangle() -> &String {
    let s = String::from("hello");

    &s
}
```

The solution is to return the `String` directly:

```rust
fn main() {
    let reference_to_nothing = dangle();
}

fn no_dangle() -> String {
    let s = String::from("hello");

    s
}
```

## The Slice Type

Slices let you reference a contiguous sequence of elements in a collection rather than the whole collection. A slice is a kind of reference, so it does not have ownership.

Here’s a small programming problem: write a function that takes a string of words separated by spaces and returns the first word it finds in that string. If the function doesn’t find a space in the string, the whole string must be one word, so the entire string should be returned.

Here’s a small programming problem: write a function that takes a string of words separated by spaces and returns the first word it finds in that string. If the function doesn’t find a space in the string, the whole string must be one word, so the entire string should be returned.

```rust
fn first_word(s : &String) -> ?
```

The `first_word` function has a `&String` as a parameter. We don’t want ownership, so this is fine. But what should we return? We don’t really have a way to talk about part of a string. However, we could return the index of the end of the word, indicated by a space. Let’s try that, as show below.

```rust
fn first_word(s: &String) -> usize {
    let bytes = s.as_bytes();

    for (i, &item) in bytes.iter().enumerate() {
        if item == b' ' {
            return i;
        }
    }

    s.len()
}
```

Because we need to go through the String element by element and check whether a value is a space, we’ll convert our String to an array of bytes using the as_bytes method.

know that `iter` is a method that returns each element in a collection and that enumerate wraps the result of `iter` and returns each element as part of a tuple instead. The first element of the tuple returned from enumerate is the index, and the second element is a reference to the element. This is a bit more convenient than calculating the index ourselves.

In the for loop, we specify a pattern that has i for the index in the tuple and &item for the single byte in the tuple.

Inside the for loop, we search for the byte that represents the space by using the byte literal syntax.

We now have a way to find out the index of the end of the first word in the string, but there’s a problem. We’re returning a usize on its own, but it’s only a meaningful number in the context of the &String. In other words, because it’s a separate value from the String, there’s no guarantee that it will still be valid in the future
```rust
fn main() {
    let mut s = String::from("hello world");

    let word = first_word(&s); // word will get the value 5

    s.clear(); // this empties the String, making it equal to ""

    // word still has the value 5 here, but there's no more string that
    // we could meaningfully use the value 5 with. word is now totally invalid!
}
```

This program compiles without any errors and would also do so if we used `word` after calling `s.clear()`
```rust
fn main() {
    let mut s = String::from("hello world");

    s.clear(); // this empties the String, making it equal to ""

    let word = first_word(&s); // word will get the value 0
}
```
Having to worry about the index in word getting out of sync with the data in s is tedious and error prone! Managing these indices is even more brittle if we write a second_word function. Its signature would have to look like this:

```rust
fn second_word(s: &String) -> (usize, usize) {
```
Now we’re tracking a starting and an ending index, and we have even more values that were calculated from data in a particular state but aren’t tied to that state at all. We have three unrelated variables floating around that need to be kept in sync.

Luckily, Rust has a solution to this problem: string slices.

### String slices
A string slice is a reference to part of a String, and it looks like this:

```rust
    let s = String::from("hello world");

    let hello = &s[0..5];
    let world = &s[6..11];
```

Rather than a reference to the entire String, hello is a reference to a portion of the String

We create slices using a range within brackets by specifying `[starting_index..ending_index]`
![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/477bc417-aaec-49b3-b0f9-541797938638)

```rust
let s = String::from("hello");

let slice = &s[0..2]; // he
let slice = &s[..2]; // he
```

```rust
let s = String::from("hello");

let slice = &s[3..len]; // llo
let slice = &s[3..]; // llo
```

```rust
let s = String::from("hello");

let len = s.len();

let slice = &s[0..len]; // hello
let slice = &s[..]; // hello
```

With all this information in mind, let’s rewrite `first_word` to return a slice. The type that signifies “string slice” is written as `&str`:

```rust
fn first_word(s: &String) -> &str {
    let bytes = s.as_bytes();

    for (i, &item) in bytes.iter().enumerate() {
        if item == b' ' {
            return &s[0..i];
        }
    }

    &s[..]
}
```

```
Note: String slice range indices must occur at valid UTF-8 character boundaries. If you attempt to create a string slice in the middle of a multibyte character, your program will exit with an error. For the purposes of introducing string slices, we are assuming ASCII only in this section; a more thorough discussion of UTF-8 handling is in the “Storing UTF-8 Encoded Text with Strings” section of Chapter 8.
```

Now when we call `first_word`, we get back a single value that is tied to the underlying data. The value is made up of a reference to the starting point of the slice and the number of elements in the slice.

## Method syntax

Methods are similar to functions: we declare them with the `fn` keyword and a name, they can have parameters and a return value, and they contain some code that’s run when the method is called from somewhere else. Unlike functions, methods are defined within the context of a struct (or an enum or a trait object, which we cover in `Chapter 6` and `Chapter 17`, respectively), and their first parameter is always `self`, which represents the instance of the struct the method is being called on.

```rust
#[derive(Debug)]
struct Rectangle {
    width: u32,
    height: u32,
}

impl Rectangle {
    fn area(&self) -> u32 {
        self.width * self.height
    }
}

fn main() {
    let rect1 = Rectangle {
        width: 30,
        height: 50,
    };

    println!(
        "The area of the rectangle is {} square pixels.",
        rect1.area()
    );
}
```
This will act like a new variable in the struct.

In the signature for `area`, we use `&self` instead of `rectangle: &Rectangle` (in a functions this would like this)
```rust
fn area(rectangle: &Rectangle) -> u32 {
    rectangle.width * rectangle.height
}
```

The `&self` is actually short for `self: &Self`. Within an `impl` block, the type `Self` is an alias for the type that the `impl` block is for.
Note that we still need to use the & in front of the self shorthand to indicate that this method borrows the Self instance.

We don’t want to take ownership, and we just want to read the data in the struct, not write to it. If we wanted to change the instance that we’ve called the method on as part of what the method does, we’d use `&mut self` as the first parameter.
Having a method that takes ownership of the instance by using just self as the first parameter is rare; This technique is usually used when the method transforms self into something else and you want to prevent the caller from using the original instance after the transformation.

We can define a method name with the same name as one of the scruct field.
When we follow rect1.width with parentheses, Rust knows we mean the method width. When we don’t use parentheses, Rust knows we mean the field width.

```Notes
Where’s the -> Operator?
In C and C++, two different operators are used for calling methods: you use . if you’re calling a method on the object directly and -> if you’re calling the method on a pointer to the object and need to dereference the pointer first. In other words, if object is a pointer, object->something() is similar to (*object).something().

Rust doesn’t have an equivalent to the -> operator; instead, Rust has a feature called automatic referencing and dereferencing. Calling methods is one of the few places in Rust that has this behavior.

Here’s how it works: when you call a method with object.something(), Rust automatically adds in &, &mut, or * so object matches the signature of the method. In other words, the following are the same:

p1.distance(&p2);
(&p1).distance(&p2);
The first one looks much cleaner. This automatic referencing behavior works because methods have a clear receiver—the type of self. Given the receiver and name of a method, Rust can figure out definitively whether the method is reading (&self), mutating (&mut self), or consuming (self). The fact that Rust makes borrowing implicit for method receivers is a big part of making ownership ergonomic in practice.

- Rust will auto-dereference in some cases, in particular when invoking methods (try ref_x.count_ones()).
```

Dereference example:

```rust
fn main() {
    let mut x: i32 = 10;
    let ref_x: &mut i32 = &mut x;
    *ref_x = 20;
    println!("ref_x: {ref_x}");
    println!("x: {x}");
}
```

## Pattern Matching in Rust

```rust
enum Coin {
    Penny,
    Nickel,
    Dime,
    Quarter,
}

fn value_in_cents(coin: Coin) -> u8 {
    match coin {
        Coin::Penny => 1,
        Coin::Nickel => 5,
        Coin::Dime => 10,
        Coin::Quarter => 25,
    }
}
```

##### Patterns That Bind to Values

We can do a enum carry another enum, like this:

```rust
fn main(){
    let x = value_in_cents(Coin::Quarter(UsState::Alabama));

    println!("{x}");
    // State quarter from Alabama!
	// 25
}

#[derive(Debug)] // so we can inspect the state in a minute
enum UsState {
    Alabama,
    Alaska,
    // --snip--
}

enum Coin {
    Penny,
    Nickel,
    Dime,
    Quarter(UsState),
}

fn value_in_cents(coin: Coin) -> u8 {
    match coin {
        Coin::Penny => 1,
        Coin::Nickel => 5,
        Coin::Dime => 10,
        Coin::Quarter(state) => {
            println!("State quarter from {:?}!", state);
            25
        }
    }
}
```

##### Matching with Option`<T>`

We can do like in Coq, SML, or some functional language, like this:

```rust
    fn plus_one(x: Option<i32>) -> Option<i32> {
        match x {
            None => None,
            Some(i) => Some(i + 1),
        }
    }

    let five = Some(5);
    let six = plus_one(five);
    let none = plus_one(None);
```

### Vectors

```rust
    let v: Vec<i32> = Vec::new();
```

For now, know that the `Vec<T>` type provided by the standard library can hold any type. When we create a vector to hold a specific type, we can specify the type within angle brackets
##### Updating a Vector

```rust
 let mut v = Vec::new();

    v.push(5);
    v.push(6);
    v.push(7);
    v.push(8);
```

As with any variable, if we want to be able to change its value, we need to make it mutable

##### Reading Elements of Vector
```rust
    let v = vec![1, 2, 3, 4, 5];

    let third: &i32 = &v[2];
    println!("The third element is {third}");

    let third: Option<&i32> = v.get(2);
    match third {
        Some(third) => println!("The third element is {third}"),
        None => println!("There is no third element."),
    }
```

Using & and [] gives us a reference to the element at the index value


We can also iterate over mutable references to each element in a mutable vector in order
to make changes to all the elements. The `for loop` in will add 50 to each.

```rust
    let mut v = vec![100, 32, 57];
    for i in &mut v {
        *i += 50;
    }
```

I found this, I will take a look on that after (https://google.github.io/comprehensive-rust/)

## String vs str

We can now understand the two string types in Rust:
```rust
    fn main() {
        let s1: &str = "World";
        println!("s1: {s1}");

        let mut s2: String = String::from("Hello ");
        println!("s2: {s2}");
        s2.push_str(s1);
        println!("s2: {s2}");
        
        let s3: &str = &s2[6..];
        println!("s3: {s3}");
    }
```

Rust terminology:

&str an immutable reference to a string slice.
String a mutable string buffer.

## Function Overloading

Overloading is not supported:
    - Each function has a single implementation:
        - Always takes a fixed number of parameters.
        - Always takes a single set of parameter types.
    - Default values are no supported:
        - All call sites have the same number of arguments.
        - Macros are sometimes used as an alternative.

However, function parameters can be generic:

```rust
fn pick_one<T>(a: T, b: T) -> T {
    if std::process::id() % 2 == 0 { a } else { b }
}

fn main() {
    println!("coin toss: {}", pick_one("heads", "tails"));
    println!("cash prize: {}", pick_one(500, 1000));
}
```

## Implicit Conversions

Rust will not automatically apply implicit conversions between types (unlike C++). You can see
this in a program like this:

```rust
fn multiply(x: i16, y: i16) -> i16 {
    x * y
}

fn main() {
    let x: i8 = 15;
    let y: i16 = 1000;

    println!("{x} * {y} = {}", multiply(x, y));
}
```

The Rust integer types all implement the `From<T>`and `Into<T>` traits to let us convert between
them.

Converting the `x` of type `i8` to an `i16` by calling `i16::from(x)`.

## Type inference

Rust will look at how the variable is used to determine the type:

```rust
fn takes_u32(x: u32) {
    println!("u32: {x}");
}

fn takes_i8(y: i8) {
    println!("i8: {y}");
}

fn main() {
    let x = 10;
    let y = 20;

    takes_u32(x);
    takes_i8(y);
    // takes_u32(y);
}
```
markdown
This code above demonstrates how the Rust compiler infers types based on constraints given by variable declarations and usages.

It is very important to emphasize that variables declared like this are not of some sort of dynamic “any type” that can hold any data. The machine code generated by such declaration is identical to the explicit declaration of a type. The compiler does the job for us and helps us write more concise code.

## Static and Constant Variables

static and constant varables are two different ways to create globally-scoped values that cannot be moved or reallocated during the execution of the program.

##### constant

Constant variables are evaluated at compile time and their values are inlined wherever they are used:

According to the [Rust RFC Book](https://rust-lang.github.io/rfcs/0246-const-vs-static.html) these are inlined upon use.

##### Static

Static variables will live during the whole execution of the program, and therefore will not move:

As noted in the Rust RFC Book, these are not inlined upon use and have an actual associated memory location. This is useful for unsafe and embedded code, and the variable lives through the entirety of the program execution. When a globally-scoped value does not have a reason to need object identity, const is generally preferred.

Because static variables are accessible from any thread, they must be Sync. Interior mutability is possible through a Mutex, atomic or similar. It is also possible to have mutable statics, but they require manual synchronisation so any access to them requires unsafe code. We will look at mutable statics in the chapter on Unsafe Rust.

## Variant Payloads

You can define richer enums where the variant carry data. You can then use the `match` statement
to extract the data from each variant:

```rust
enum WebEvent {
    PageLoad,                 // Variant without payload
    KeyPress(char),           // Tuple struct variant
    Click { x: i64, y: i64 }, // Full struct variant
}

#[rustfmt::skip]
fn inspect(event: WebEvent) {
    match event {
        WebEvent::PageLoad       => println!("page loaded"),
        WebEvent::KeyPress(c)    => println!("pressed '{c}'"),
        WebEvent::Click { x, y } => println!("clicked at x={x}, y={y}"),
    }
}

fn main() {
    let load = WebEvent::PageLoad;
    let press = WebEvent::KeyPress('x');
    let click = WebEvent::Click { x: 20, y: 80 };

    inspect(load);
    inspect(press);
    inspect(click);
}
```

## Enum sizes

```Notes
I need to understand this better.
```

Rust enums are packed tightly, taking constraints due to alignment into account:

```rust
use std::any::type_name;
use std::mem::{align_of, size_of};

fn dbg_size<T>() {
    println!("{}: size {} bytes, align: {} bytes",
        type_name::<T>(), size_of::<T>(), align_of::<T>());
}

enum Foo {
    A,
    B,
}

fn main() {
    dbg_size::<Foo>();
}
```

## Destructing enums

It's possible destruct structs too

```rust
enum Result {
    Ok(i32),
    Err(String),
}

fn divide_in_two(n: i32) -> Result {
    if n % 2 == 0 {
        Result::Ok(n / 2)
    } else {
        Result::Err(format!("cannot divide {n} into two equal parts"))
    }
}

fn main() {
    let n = 100;
    match divide_in_two(n) {
        Result::Ok(half) => println!("{n} divided in two is {half}"),
        Result::Err(msg) => println!("sorry, an error happened: {msg}"),
    }
}
```

## Using structs to structure Related Data

Defining a struct:

```rust
struct User {
    active: bool,
    username: String,
    email: String,
    sin_in_count: u64,
}
```

A good thing in rust:

The `user2` has a different email, and the rest if the same of the `user1`

```rust
fn main() {
    // --snip--

    let user2 = User {
        email: String::from("another@example.com"),
        ..user1
    };
}
```

## Using tuple structs without named fields to create different types.

Rust supports structs that look similar to tuples, called `tuple structs`.
Tuple structs have the added meaning the struct name provides but dont't have names
associated with their fields; rather, they just have the types of the fields.

Example to a `tuple struct`:

```rust
struct Color(i32, i32, i32);
struct Point(i32, i32, i32);

fn main() {
    let black = Color(0, 0, 0);
    let origin = Point(0, 0, 0);
}

```

## Associated Functions

All functions defined within an `impl` block are called `associated function` because
they're associated with the type named after tem `impl`. 

We can define `associated functions` that don't have self as their first parameter
(and thus are not methods) because they don't need an instance of the type to work with.
(We've already used one function like this: the `String::from` function that's defined on the String type.)

`Associated functions` that aren't methods are often used for constructors that
will return a new instance of the struct. These are often called new, but new
isn't a special name and isn't built into the language.

For example, we could choose to provide an associated function named `square`
that would have one dimension parameter and use that as both width and height,
thus making it easier to create a square Rectangle rather than having to specify
the same value twice:

```rust
impl Rectangle {
    fn square(size: u32) -> Self {
        Self {
            width: size,
            height: size,
        }
    }
}
```

The Self keywords in the return type and in the body of the function
are aliases for the type that appears after the impl keyword, which
in this case is Rectangle.

To call this associated function we use the `::` syntax with the struct name;
`let square = Rectangle::square(3);`

# Managing growing projects with packages, crates and modules

Here is a chapter from a project when he grows, and need to organize code by
splitting it into multiple modules and then multiple files. A package can
contain multiple binary crates and optionally one library crate. You can extract
parts into separete crates that become external dependencies.

For a very large projects comprising a ser of interrelated pakages that evolve
together, Cargo provides `workspaces`.

Rust has a number of features that allow you to manage your code's organization,
including which details are exposed, which details are private, and what names
are in each scope in your programs.
These features, sometimes collectively referred to as the `module system`, include:

- *Packages*: A Cargo feature that lets you build, test, and share crates;
- *Crates*: A tree of modules that procedures a library or executable;
- *Modules* and *use*: Let you control the organization, scope, and privacy of panths;
- *Paths*: A way of naming an item, such as a struct, function, or module;

### Packages and Crates

A `crate` is the smallest amount of code that the rust compiler considers at a time.
If run with `rustc` or `cargo` and pass a single source code file, the compiler considers
that file to be a crate. Crates can contain module, and the modules may be defined in other
files that get compiled with the crate, as we'll see in the coming sections.

`Crate` can come in one of two forms: 

- *Binary crate*: Is a executable we can run, by CLI or a server (has the functions `main`).
- *Library crate*: Don't have a `main` function, and not is compile to an executable.

A `package` is a bundle of one or more crates that provides a set of functionality.
Packa  contains a `Cargo.toml` file that describes how to build those crates.

### Defining modules to control scope and privacy

We'll discuss external packages and the glob operator.

##### Modules Cheat Sheet

We'll will show how modules, paths, `use`m pub work in the compiler.

This is a great place to refer to as a reminder of how modules work.

**Declaring modules**: you declare a `garden` module with `mod garden;`

**Paths to code in modules**: Once a module is part of your crate, you can refer
to code in that module from anywhere else in that same crate, as long as the privacy
rules allow, using the path to the code. For example, an `Asparagus` type in the garden
vegetables module would be found at `crate::garden::vegetables::Asparagus`.

**The `use` keyword**: Within a scope, the `use` keyword creates shortcuts to items
to reduce repetition of longs paths. In any scope that can refer to
`crate::garden::vegetables::Asparagus`, you can create a shortcut with
`use crate::garden::vegetables::Asparagus;` and from them on you only need to write
`Asparagus` to make use of that type in the scope.

Ilustratin this rules:

```
backyard
├── Cargo.lock
├── Cargo.toml
└── src
    ├── garden
    │   └── vegetables.rs
    ├── garden.rs
    └── main.rs

```

The crate root file is `src/main.rs`.

Inside the `main.rs`

```rust
use crate::garden::vegetables::Asparagus;

pub mod garden;

fn main() {
    let plant = Asparagus {};
    println!("I'm growing {:?}!", plant);
}
```

The `pub mod garden;` line tells to compiler to include the code it finds in `src/garden.rs`

And inside the `garden.rs`, we have the code:

```rust
pub mod vegetables;
```

And this `pub mod vegetables;` include the code inside the `vegetables`.

And the code included is:

```rust
#[derive(Debug)]
pub struct Asparagus {}
```

### Grouping Related Code in Modules

Modules allow us to control the *privacy* or items, because code with modules
is private by default.

After here the rust documentation create a lib that provides a restaurant functionality,
the project [restaurant](./restaurant/).

