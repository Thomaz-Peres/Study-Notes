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

Code within a module is private by default.

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

### Paths for referring to an item in the module tree

- An *absolute path* is the full path starting from a crate root;
- A *relative path* starts from the current module and uses `self`, `super`, or an 
identifier ih the current module.

The rust team preference in general is to specify absolute paths because it's more likely
we'll want to move code definitions and tiem call independently of each other.

Items in a parent module can't use the private items inside child modules,
but items in child modules can use the items in their ancestor modules.
This is because child modules wrap and hide their implementation details.

### Starting relative paths with super

`super`, is like using `..` em files in CLI for example.

```rust
fn deliver_order() {}

mod back_of_house {
    fn fix_incorrect_order() {
        cook_order();
        super::deliver_order();
    }

    fn cook_order() {}
}
```

### Using structs and class, functions class

This is interesting because in the compiler, I use a direct struct, like:

```rust
pub struct Breakfast {
    pub toast: String,
    seasonal_fruit: String,
}

impl Breakfast {
    pub fn summer(toast: &str) -> Breakfast {
        Breakfast {
            toast: String::from(toast),
            seasonal_fruit: String::from("peaches"),
        }
    }
}
```

And this like better, let see in the next chapters;

```rust
mod back_of_house {
    pub struct Breakfast {
        pub toast: String,
        seasonal_fruit: String,
    }

    impl Breakfast {
        pub fn summer(toast: &str) -> Breakfast {
            Breakfast {
                toast: String::from(toast),
                seasonal_fruit: String::from("peaches"),
            }
        }
    }
}

pub fn eat_at_restaurant() {
    let mut meal = back_of_house::Breakfast::summer("Rye");
    meal.toast = String::from("Wheat");
    println!("I'd like {} toast please", meal.toast);
}
```

### Bringing paths into scope with the use Keyword

This is like `using FrontOhHouse` in c#

```rust
mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist() {}
    }
}

use crate::front_of_house::hosting;

pub fn eat_at_restaurant() {
    hosting::add_to_waitlist();
}
```

other importante thing, if we create a new module before `eat_at_restaurant`,
we need move the use too, like;

```rust
mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist() {}
    }
}

use crate::front_of_house::hosting; // use here not work

mod customer {
    use crate::front_of_house::hosting;
    pub fn eat_at_restaurant() {
        hosting::add_to_waitlist();
    }
}
```

or use with super, example:

```rust
mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist() {}
    }
}

use crate::front_of_house::hosting; // now this work

mod customer {
    pub fn eat_at_restaurant() {
        super::hosting::add_to_waitlist();
    }
}
```

### Creating idiomatic use Paths

We can use the function directy in the use, like `use crate::front_of_house::hosting::add_to_waitlist;`
and just call

```rust
mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist() {}
    }
}

use crate::front_of_house::hosting::add_to_waitlist;

pub fn eat_at_restaurant() {
    add_to_waitlist();
}
```

### Providing new names with the `as` keyword

We can do this if we have the same name functions, and give a name to one of them (or for all)
and use their name, like below:

```rust
use std::fmt::Result;
use std::io::Result as IoResult;

fn function1() -> Result {
    // --snip--
}

fn function2() -> IoResult<()> {
    // --snip--
}
```

### Using nested paths to clean up large use Lists

If we want use two items defined in the same crate/module, like this below, where we use two
modules inside the `std` lib:

```rust
use std::cmp::Ordering;
use std::io;
```

We can do this:

`use std::{cmp::Odering, io}`

And we can use this for the same place, but share a subpath, for example:

```rust
use std::io;
use std::io::Write;
```

And use like this:

`use std::io::{self, Write};`

This above will brings `str::io` and `str::io::Write`

### The glob operator

If we want to bring all public items defined in a path, we can specify that path
followed by the `*` glob operator:

`use str::collections::*`

### Separating modules into different Files

Separating the code in files:

`lib.rs`
```rust
mod front_of_house;

pub use crate::front_of_house::hosting;

pub fn eat_at_restaurant() {
    hosting::add_to_waitlist();
}
```

`front_of_house`
```rust
pub mod hosting {
    pub fn add_to_waitlist() {}
}
```

Now we'll extrat the hosting module to its own file. The process is a bit different because
hosting is a child module of `front_of_house`, not of the root module.

To start moving `hosting`, we change `src/front_of_house.rs` to contain only the declaration
of the `hosting` module:

Filename: `src/front_of_house.rs`
```rust
pub mod hosting;
```

Then we create a `src/front_of_house` irectory and a file `hosting.rs` to contain the definitions
made in the `hosting` module;

Filname: `src/front_of_house/hosting.rs`
```rust
pub fn add_to_waitlist() {}
```

If we instead put `hosting.rs` in the src directory, the compiler would expect the `hosting.rs`
code to be in a `hosting` module declared in the crate root, and not declared as a child of
the `front_of_house` module.


## Error Handling

Rust groups errors into two major categories:

- **Recoverable :** A error like `file not found`, problaly we report the problem to the user
and retry the operation.

- **Unrecoverable :** This errors, are always symptoms of bugs, like trying to access a location
beyond the of an array, and so we want to immediately stop the program.

**Rust doesn't jave exceptions.**

Just has the types, `Result<T, E>` for recoverable errors and the `panic!` macro that stops
execution for unrecoverable errors.


##### Unrecoverable Errors with `panic!`

The `panic!` can come from your code, you some Lib you use.

By default, these panics will print a failure message, unwind, clean up the stack, and quit.

Via an environment varaible, you can also have rust display the call stack when a panic
occurs to make it easier to track down the source of the panic.


>**Unwinding the Stack or Aborting in Response to a Panic**
>
>The `unwinding (walk back up the stack and cleans up the data from each function it encounters)`
of the `panic!` is a lot of work.
>
>Rust allow yo choose the alternative of immediately *aborting*. which end the program
without cleaning up and the memory the program was using will then need to be
cleaned up by the SO.
>
>It's possible switch from unwinding to aborting upon a panic by adding `panic = 'abort'`
to the appropriate `[profile]` sections in your *Cargo.toml*.
>
>Exemple if you want to abort on panic in release mode, add:
>
>```rust
>[profile.release]
>panic = 'abort'
>```

## Recoverable Errors with `Result<T, E>`

The `T` and `E` are generic type parameters.

Let's call a function that return a `Result` value because the function could fail.

The return type of `File::open` is a `Result<T, E>`

```rust
use std::fs::File;

fn main() {
    let greeting_file_result = File::open("hello.txt");

    let greeting_file = match greeting_file_result {
        Ok(file) => file,
        Err(error) => panic!("Problem opening the file: {:?}", error),
    };
}
```

Now we will improve this, for different actions for different failure reasons.
If `File::open` failed because the file doesn't exist, we wanto to create and
return the handle to the new file.
If failed for any other reason, for example, we didn't jave permission to open
the file, we still want the `panic!`.

```rust
use std::fs::File;
use std::io::ErrorKind;

fn main() {
    let greeting_file_result = File::open("hello.txt");

    let greeting_file = match greeting_file_result {
        Ok(file) => file,
        Err(error) => match error.kind() {
            ErrorKind::NotFound => match File::create("hello.txt") {
                Ok(fc) => fc,
                Err(e) => panic!("Problem creating the file: {:?}", e),
            },
            other_error => {
                panic!("Problem opening the file: {:?}", other_error);
            }
        },
    };
}
```

The `Err` returns the variant `io::Error`, which is a struct provided by the std lib.
This struct has a method `kind` that we can call to get an `io::ErrorKind` value.

The enum `io::ErrorKind` is provided by the std lib and has variant representing the
different kinds of errors that might result fron as `io` operation.

>Have some alternatives to use `match` with `Result<T, E>`
>
>The match expression is very much a primitive. In other chapter, we'll learn about
closures.
>
>These methods can be more concise than using `match`
>
>Example:
>
>```rust
>use std::fs::File;
>use std::io::ErrorKind;
>
>fn main() {
>    let greeting_file = File::open("hello.txt").unwrap_or_else(|error| {
>        if error.kind() == ErrorKind::NotFound {
>            File::create("hello.txt").unwrap_or_else(|error| {
>                panic!("Problem creating the file: {:?}", error);
>            })
>        } else {
>            panic!("Problem opening the file: {:?}", error);
>        }
>    });
>}
>```
>
> The `unwrap_or_else` not is a closure

##### Shortcuts for Panic on Error: `unwrap` and `expect`

The `unwrap` method is will return the value inside the `Ok`.
If the `Result` is the `Err` variant, `unwrap` will call the `panic!` macro for us.
(is a shortchut method like the `match` expression we wrote some lines above).

```rust
use std::fs::File;

fn main() {
    let greeting_file = File::open("hello.txt").unwrap();
}
```

If we run this code without a `hello.txt` file, we'll see an error message from the `panic!`.

The `expect` method lets us also choose the `panic!` error message.

We use `expect` in the same way as `unwrap`, to return the file handle or call the `panic!` macro.

Using `expect` instead of `unwrap` and providing good error messages can convey your intent
and make tracking down the source of a panic easier.

The syntas of `expect`:

```rust
use std::fs::File;

fn main() {
    let greeting_file = File::open("hello.txt")
        .expect("hello.txt should be included in this project");
}
```

The `panic!` error will use the `expect` message we sent

**OBS: In production-quality code, most Rustaceans choose `expect` rather than `unwrap`**
**and give more context about why the operation is expected to always succeed.**

### Propagating Errors

This is a propagating error to functins called other functions, and this gives more
control to the calling code, and this calling code dictates how the error should be handled.

This is a example, we propagating the `Error` and the `Ok`.

For exemplae, in the second match, who call this function, will receive a `Error`, and the
calling function, see what we do with the error.

```rust
use std::fs::File;
use std::io::{self, Read};

fn read_username_from_file() -> Result<String, io::Error> {
    let username_file_result = File::open("hello.txt");

    let mut username_file = match username_file_result {
        Ok(file) => file,
        Err(e) => return Err(e),
    };

    let mut username = String::new();

    match username_file.read_to_string(&mut username) {
        Ok(_) => Ok(username),
        Err(e) => Err(e),
    }
}

```

###### A shortcut for Propagating Error: the `?` Operator

The `?` work in almost the same way as the `match` expressions.

```rust
use std::fs::File;
use std::io::{self, Read};

fn read_username_from_file() -> Result<String, io::Error> {
    let mut username_file = File::open("hello.txt")?;
    let mut username = String::new();
    username_file.read_to_string(&mut username)?;
    Ok(username)
}

```

If the value of the `Result` is an `Ok`, the value inside the `Ok` will get returned from this
expression, and the program will continue.

If the value is an `Err`, the `Err` will be returned from the whole function as if we had
used the `return` keyword, so the error value gets propagated to the callind code.

###### Where the `?` operator can be used

The `?` operator can only be used in functions whose return type is compatible with the value
the `?` is used on.
This is because the `?` operator is defined to perform an early return of a value out of the function.

Let's look at the error we'll get if we use the `?` operator in a `main` function with a return type
incompatible with the type of the value we use `?` on:

```rust
use std::fs::File;

fn main() {
    let greeting_file = File::open("hello.txt")?;
}
```

This code opens a file, which might fail. The `?` operator follows the `Result` value returned by
`File::open`, but this `main` function has the return type of `()`, not `Result`. When we compile
this code, we will receive a error.

We're only allowed to use the `?` operator in a function that returns `Result`, `Option`, or another
type that implements `FromResidual`

The `Option<T>` is similar to `Result` but, (ao inves de) `Err` and `Ok`, `Option` return
`None (Err)` and `Some (Ok)`

Other good example, is the `?` operator extracts the `string slice`, and the code above, we can
call `chars` on that string slice to get an iterator of its characters

```rust
fn last_char_of_first_line(text: &str) -> Option<char> {
    text.lines().next()?.chars().last()
}
```

The `?` won't automatically convert a `Result` to an `Option` or vice versa

## Generic Types, Traits, and Lifetimes

**Lifetimes:** A variety of generics that give the compiler information about
how references relate to each other. Lifetimes allow us to give the compiler
enough information about borrowed values so that it can ensure references will
be valid in more situations that it could without our help.

#### Removing Duplication by extracting a function

Let's first look at how to remove duplication in a way that doesn't involve generic
types by extracting a function that replaces specific values with a placeholder that
represents multiple values.

Then we'll apply the same technique to extract a generic function!

(How I already know how works generics because the C#, I will only write some examples in
Rust, in general not is too much different)

*Declaring a generic function in Rust*:
```rust
fn largest<T>(list: &[T]) -> &T {}
```

This code above will give a error (in this case a *trait*).

In this case, the error occurs because the body of `largest` won't work for all possible types
that `T` could be.

To enable comparisons, the standar library has the `std::cmp::PartialOrd` trait that you can
implement on types.
By following the help text's suggetions, we restrict the types valid for `T` to only those that
implement `PartialOrd` and this example will compile, because `i32` and`char` implements `PartialOrd`

The code will look like this:

```rust
fn largest<T: std::cmp::PartialOrd>(list: &[T]) -> &T {
    let mut largest = &list[0];

    for item in list {
        if item > largest {
            largest = item;
        }
    }

    largest
}
```

### In Struct Definitions

We can also define structs to use generic type:

```rust
struct Point<T> {
    x: T,
    y: T,
}

fn main() {
    let integer = Point { x: 5, y: 10 };
    let float = Point { x: 1.0, y: 4.0 };
}
```

Note the `x` and `y` need to be the same type, if we do this, will give an error:

```rust
struct Point<T> {
    x: T,
    y: T,
}

fn main() {
    let wont_work = Point { x: 5, y: 4.0 };
}
```

We can use multiple generic type parameters, for example:

```rust
struct Point<T, U> {
    x: T,
    y: U,
}

fn main() {
    let both_integer = Point { x: 5, y: 10 };
    let both_float = Point { x: 1.0, y: 4.0 };
    let integer_and_float = Point { x: 5, y: 4.0 };
}
```

Let's remember the `Result<T, E>` and `Option<T>` is a generic, but a enum generic, like this:

```rust
enum Option<T> {
    Some(T),
    None,
}

enum Result<T, E> {
    Ok(T),
    Err(E),
}
```

##### In Method Definitions

We can implement generics Methods too, like this:

```rust
struct Point<T> {
    x: T,
    y: T,
}

impl<T> Point<T> {
    fn x(&self) -> &T {
        &self.x
    }
}

fn main() {
    let p = Point { x: 5, y: 10 };

    println!("p.x = {}", p.x());
}
```

Note that we have to declare `T` just after `impl`.

By declaring `T` as a generic type after `impl`, Rust can identify that the type
in the angle brackets in `Point` is a generic type rather than a concrete type.

We can also specify contraints on generic types when defining methods on the type.
We could, for example, implement methods only on `Point<f32>`:

```rust
impl Point<f32> {
    fn distance_from_origin(&self) -> f32 {
        (self.x.powi(2) + self.y.powi(2)).sqrt()
    }
}
```

We can create a `impl` with generic type, and in the method we create other Generic.
The method creates a new Point instance with the x value from the self Point
(of type X1) and the y value from the passed-in Point (of type Y2).

```rust
struct Point<X1, Y1> {
    x: X1,
    y: Y1,
}

impl<X1, Y1> Point<X1, Y1> {
    fn mixup<X2, Y2>(self, other: Point<X2, Y2>) -> Point<X1, Y2> {
        Point {
            x: self.x,
            y: other.y,
        }
    }
}

fn main() {
    let p1 = Point { x: 5, y: 10.4 };
    let p2 = Point { x: "Hello", y: 'c' };

    let p3 = p1.mixup(p2);

    println!("p3.x = {}, p3.y = {}", p3.x, p3.y);
}
```

Here, the generic parameters `X1` and `Y1` are declared after impl because they go with the
struct definition. The generic parameters `X2` and `Y2` are declared after `fn mixup`, because
they're only relevant to the method.


## Performance of code using Generics

TODO: Search about performance about generics vs object in c#


The program with generics not lose performance, or made the program run slower
than it would with concrete types.

Rust use *Monomorphization*, is the process of turning generic code into specific
code by filing in the concrete types that are used when compiled.

In the compiler, the compiler expands the generics in two specific function for
each use case, for example:

```rust
enum Option_i32 {
    Some(i32),
    None,
}

enum Option_f64 {
    Some(f64),
    None,
}

fn main() {
    let integer = Option_i32::Some(5);
    let float = Option_f64::Some(5.0);
}
```

## Traits: Defining shared behavior

> NOTE: Traits are similar to a feature ofter called `interfaces` in other
> languages, although with some differences.

##### Defining a trait

A type's behavior consists of the methods we can call on that type.

Different types share the same behavior if we can call the same methods
on all of those types.

Trait defintions are a way to group method to define a set of behaviors
necessary to accomplish some purpose.

**Creating a trait**

```rust
pub trait Summary {
    fn summarize(&self) -> String;
}
```

##### Implementing a Trait on a Type

The implementation of a trait in a tpye is similar to implemeting regular methods.
The difference is that after `impl`, we put the trait name we want to implement
then use the `for` keyword, and then specify the name of the type we want to
implement the trait for.

```rust
pub struct NewsArticle {
    pub headline: String,
    pub location: String,
    pub author: String,
    pub content: String,
}

impl Summary for NewsArticle {
    fn summarize(&self) -> String {
        format!("{}, by {} ({})", self.headline, self.author, self.location)
    }
}

pub struct Tweet {
    pub username: String,
    pub content: String,
    pub reply: bool,
    pub retweet: bool,
}

impl Summary for Tweet {
    fn summarize(&self) -> String {
        format!("{}: {}", self.username, self.content)
    }
}
```

Using the struct with the trait:

```rust
use crate::{Summary, Tweet};

fn main() {
    let tweet = Tweet {
        username: String::from("horse_ebooks"),
        content: String::from(
            "of course, as you probably already know, people",
        ),
        reply: false,
        retweet: false,
    };

    println!("1 new tweet: {}", tweet.summarize());
}
```

This will prints `1 new tweet: horse_ebooks: of course, as you probably already know, people`.

#### Default implementations

We can create a default trait implementation, and then when we will implement the trait
in a particular type, we can keep or override each method's default behavior.

Default trait:

```rust
pub trait Summary {
    fn summarize(&self) -> String {
        String::from("(Read more...)")
    }
}

```

To use a default implementation to `summarize`  instances of something, we specify an
empty `impl` block with `impl Summary for SomeStructure {}`.

With this, we have provided a dafault implementation of `Summary`.

We can create traits using another traits, for example:

```rust
pub trait Summary {
    fn summarize_author(&self) -> String;

    fn summarize(&self) -> String {
        format!("(Read more from {}...)", self.summarize_author())
    }
}

```

And to use this version, of `Summary` we only need to define `summarize_author` when we
implement the trait on a type:

```rust
impl Summary for Tweet {
    fn summarize_author(&self) -> String {
        format!("@{}", self.username)
    }
}
```

And after that, we can call `summarize` on instances of the `Tweet` struct, and the default
implementation of `summarize` will call the definition of `summarize_author` that we've
provided.

```rust
    let tweet = Tweet {
        username: String::from("horse_ebooks"),
        content: String::from(
            "of course, as you probably already know, people",
        ),
        reply: false,
        retweet: false,
    };

    println!("1 new tweet: {}", tweet.summarize());
```

This code prints `1 new tweet: (Read more from @horse_ebooks...)`.

##### Traits as Parameters

We can use traits as parameters too. we use the syntax `impl Trait`, for example:

```rust
pub fn notify(item: &impl Summary) {
    println!("Breaking news! {}", item.summarize());
}
```

With this, we can use any methods that comes from the `Summary` trait.

##### Trait bound Syntax

The `impl Trait` is a syntax sugar for `trait bound`, looks like this:

```rust
pub fn notify<T: Summary>(item: &T) {
    println!("Breaking news! {}", item.summarize());
}
```

The example in `Traits as parameters` is the same of the code above, but is more berbose.

The `bound syntax` can express more complexity, for example, when we have two parameters.

With syntax sugar:
```rust
pub fn notify(item1: &impl Summary, item2: &impl Summary) { }
```

With `bound syntax`:

```rust
pub fn notify<T: Summary>(item1: &T, item2: &T) { }
```

##### Specifying multiple trait bounds with the + Syntax

We can use more than one trait for variable. We can implement both `x` and `y`
using the `+` syntax:

With the syntax sugar:
`pub fn notify(item: &(impl Summary + Display)) { }`

With the trait bounds:
`pub fn notify<T: Summary + Display>(item: &T) { }`

##### Clearer trait bounds with where Clauses

Rust has the `where` syntax too (like in C#). Example:

```rust
fn some_function<T, U>(t: &T, u: &U) -> i32
where
    T: Display + Clone,
    U: Clone + Debug,
{
```

##### Returning Types that implement Traits

We can use the trait in the return to return a value of some type that implements
a trait, as show below:

```rust
fn returns_summarizable() -> impl Summary {
    Tweet {
        username: String::from("horse_ebooks"),
        content: String::from(
            "of course, as you probably already know, people",
        ),
        reply: false,
        retweet: false,
    }
}
```

`Tweet` return a trait Summary. If has another type where implements `Summary`,
the function `returns_summarizable()` can return this type that implements the
`Summary` trait.

##### Using Trait Bounds to Conditionally Implement Methods

The `impl` block the uses generics parameters, with you want to create a new `impl`
just use like this:

```rust
use std::fmt::Display;

struct Pair<T> {
    x: T,
    y: T,
}

impl<T> Pair<T> {
    fn new(x: T, y: T) -> Self {
        Self { x, y }
    }
}

impl<T: Display + PartialOrd> Pair<T> {
    fn cmp_display(&self) {
        if self.x >= self.y {
            println!("The largest member is x = {}", self.x);
        } else {
            println!("The largest member is y = {}", self.y);
        }
    }
}
```

It's possible too conditionally implement a trait for any type that implements
another trait.

They are called *blanket implementations*, are extensibely used in the Rust
standard library. For example, the standard library implements the `ToString` trait
on any type that implements the `Display` trait.

For example, integers implement `Display`, because that we can use

`let s = 3.to_string()`;

The blanket implementation appear in the documentation for the trait in the `implementors`
section.

## Validatin references with lifetimes.

Lifetimes are another kind of generic.
In generics we want to ensure that a type has he behavior we want.
Lifetimes ensure that references are valid as long as we need them to be.

Every reference in Rust has a `lifetime`, which is the scope for which that
reference is valid.

Most of the time, lifetimes are implicit and inferred, just like mosto of the time,
types are inferred. We must only annotate types when multiple types are possible.

Is similar for `lifetimes`.
Rust requires to annotate the relationships using generic lifetime parameters
to ensure the actual references used at runtimne will definitely be valid.


##### Generic lifetimes in functions

Note that below we want the function to take string slices, which are references,
rather than strings, because we don't want the `longest` function take ownership
of its parameters.

```rust
fn main() {
    let string1 = String::from("abcd");
    let string2 = "xyz";

    let result = longest(string1.as_str(), string2);
    println!("The longest string is {}", result);
}
```

If we try to implement the `longest` function as follow, it won't compile.

```rust
fn longest(x: &str, y: &str) -> &str {
    if x.len() > y.len() {
        x
    } else {
        y
    }
}
```

This happen becasue we don't know wheter the `if` case or the `else` case will execute.
We also don't know the concrete lifetimes of the references that will be passed in,
we can't determine wheter the reference we return will always be valid.

And the `borrow checker` can't determine this eiter, because ii doesn't know how the lifetimes
of `x` and `y` relate to the lifetime of ther return value. To fix this error, we'll
add generic lifetime parameters that define the relationship between the references so the
borrow checker can perform its analysis.

##### Lifetime Annotation Syntax

Lifetimes don't change how long any reference live. They describe the relationships of the
lifetimes of multiple references to each other without affecting the lifetimes.

Functins can accept references with any lifetime by specifying a generic lifetime parameter.

Lifetime annotations have a slightly unusual syntax: the names of lifetimes parameters must
start with an apostrophe (`'`) and are usually all lowercase and very short, like generic types.
Most people use the name `'a` for the first lifetime annotation.

We place lifetime parameter annotations after the `&` of a reference, using a space to separate
the annotation from the reference's type.

##### Lifetime Annotations in Function Signatures

Declaring a generic *lifetime*.

`fn longest<'a>(x: &'a str, y: &'a str) -> &'a str { ... }`

With this, we want the signature to express the following constraint: the returned reference
will be valid as long as both the parameters are valid. This is a relationship between
lifetimes of the parameters and the return value.

```rust
fn longest<'c>(x: &'c str, y: &'c str) -> &'c str {
    if x.len() > y.len() {
        x
    } else {
        y
    }
}
```

The functions signature tells Rust for some lifetime `a` the function takes two parameters,
also tells Rust the return has the lifetime `a`, and the *variable/type* live at least as
long as lifetime `a`.

In practice, it means that the lifetime of the reference returned by the longest function is
the same as the smaller of the lifetimes of the values referred to by the function arguments.
These relationships are what we want Rust to use when analyzing this code.

This lifetimes parameters specified in the function signature, not change the lifetimes of
any values passed in or returned. rather, we're specifying that the borrow checker should
reject any values that don't adhere to these constraints. Note the `longents` function
doesn't need to know exactly how long `x` and `y` will live, only that some scope can be
substituted for `'a` that will satisfy this signature.

The lifetimes references in `longest` function will be the same in `x`, `y` and the for
the return

Another example about lifetimes, let's look this code:

```rust
fn main() {
    let string1 = String::from("long string is long");
    let result;
    {
        let string2 = String::from("xyz");
        result = longest(string1.as_str(), string2.as_str());
    }
    println!("The longest string is {}", result);
}
```

This will return this error:

```
$ cargo run
   Compiling chapter10 v0.1.0 (file:///projects/chapter10)
error[E0597]: `string2` does not live long enough
 --> src/main.rs:6:44
  |
6 |         result = longest(string1.as_str(), string2.as_str());
  |                                            ^^^^^^^^^^^^^^^^ borrowed value does not live
                                                                long enough
7 |     }
  |     - `string2` dropped here while still borrowed
8 |     println!("The longest string is {}", result);
  |                                          ------ borrow later used here

For more information about this error, try `rustc --explain E0597`.
error: could not compile `chapter10` due to previous error
```

This happens because the Rust compiler not understand the `string1` will be valid for the
`println!` statement.

##### Thinking in Terms of Lifetimes

If we changed the implementation of the `longest` function to always return the first parameter rather than the longest string slice, we wouldn't need to specify a lifetime on the `y` parameter, and we can change the function to this:

```rust
fn longest<'a>(x: &'a str, y: &str) -> &'a str { 
    x
}
```
(Of course, this only is a example)

When returning a reference from a function, the lifetime parameter for the return type needs to match the lifetime parameter for one of the paremeters. With you return a new value without being the same lifetimes this would be a dangling referencec because the value will go out of scope at the end of the function. This code for example, not work:

```rust
fn longest<'a>(x: &str, y: &str) -> &'a str {
    let result = String::from("really long string");
    result.as_str()
}
```

##### Lifetime Annotations in Struct Definitions

We can define structs to hold references, just adding a lifetime annotation on every reference in the struct's definition. Code example:

```rust
struct ImportantExcerpt<'a> {
    part: &'a str,
}

fn main() {
    let novel = String::from("Call me Ishmael. Some years ago...");
    let first_sentence = novel.split('.').next().expect("Could not find a '.'");
    let i = ImportantExcerpt {
        part: first_sentence,
    };
}
```

In this `main` function, the variable `novel` is the owned. The variable `novel` doens't go out of scope until after the `ImportantExcerpt` goes out of scope, so the reference in the `ImportantExcerpt` instance is valid.

##### Lifetime Elision

The patterns programmed into Rust’s analysis of references are called the lifetime elision rules. These aren’t rules for programmers to follow; they’re a set of particular cases that the compiler will consider, and if your code fits these cases, you don’t need to write the lifetimes explicitly.


Lifetimes on function or method parameters are called *input lifetimes*, and lifetimes on return values are called *output lifetimes*.

*Lifetime Elision Rules* is a three rules to figure out the lifetimes of the reference, but it's to long I thing it's better stay updated with the [page](https://doc.rust-lang.org/book/ch10-03-lifetime-syntax.html#lifetime-elision).

##### Lifetime Annotation in Method Definitions

Lifetimes names for struct fields always need to be decalred after the `impl` keyword and then used after the struct's name, because those lifetimes are part of the struct's type. In addition, the `lifetime elision rules` ofter make it so that lifetime annotations aren't necessary in method signatures.

Let's see some examples:

```rust
impl<'a> ImportantExcerpt<'a> {
    fn level(&self) -> i32 {
        3
    }
}
```

We're not required to annotate the lifetime of the reference to `self` because of the first elision rule.

Here is an example where the third lifetime elision rule applies:

```rust
impl<'a> ImportantExcerpt<'a> {
    fn announce_and_return_part(&self, announcement: &str) -> &str {
        println!("Attention please: {}", announcement);
        self.part
    }
}
```

There are two input lifetime,s so Rust applies the first lifetime elision rule and gives both `&self` and `announcement` their own lifetimes. Then, because one of the aprameters is `&self`, the return type gets the lifetime of `&self`, and all lifetimes have been accounted for.

##### The static lifetime

One special lifetime we need to discuss is `'static`, which denotes that the affected reference can live for the entire duration of the program. All string literals have the `'static` lifetime, which we can annotate as follows:

`let s: &'static str = "I have a static lifetime.`;

The text of this string is stored directly in the program's binary, which is always available. Therefore, the lifetime of all string literals is `'static`.

##### Generic Type Parameters, Trait Bounds, and Lifetimes Together.

Let's see some examples using traits, generics and lifetimes:

```rust
use std::fmt::Display;

fn longest_with_an_announcement<'a, T>(
    x: &'a str,
    x: &'a str,
    ann: T,
) -> &'a str
where
    T: Display,
{
    println!("Announcement! {}", ann);

    if x.len() > y.len() {
        x
    } else {
        y
    }
}
```

Because lifetimes are a type of generic, the declarations of the lifetime parameter `'a` and the generic type parameter `T` go in the same list inside the angle brackets after the function name.

### Automated Tests

We will looks at the features Rust provides speciafically for writing tests that take these actions, which include the `test` attribute, a few macros, and the `should_panic` attribute.

#### The Anatomy of a Test Function

A test in Rust is a function that's annotated with the `test` attribute.

To run the tests, just run `cargo test`.

When we make a new library project with Cargo, a test module it is automatically generated for us.

Let's see an example of tests:

```rust
#[cfg(test)]
mod tests {
    #[test]
    fn it_works() {
        let result = 2 + 2;
        assert_eq!(result, 4);
    }
}
```

When we annotate a function with the `#[test]`, this indicates a test function, and we can have non-test function in the tests module to help set up common scenarios or perform common operation, so always need to indicate which functions are tests.

And the `assert_eq` is a macro to assert the result (almost the same as `Assert.xxx` in C#).

This is a example a part of the return:

```
test result: ok. 1 passed; 0 failed; 0 ignored; 0 measured; 0 filtered out; finished in 0.00s
```

We will explain each statistic.

The `measured` statistic if for benchmark tests that measure performance. Benchmark tests are, as of this writing, only available in nightly Rust. See [the documentation abou benchmark tests](https://doc.rust-lang.org/unstable-book/library-features/test.html) to learn more.

Now lets adding a fail test:

```rust
#[cfg(test)]
mod tests {
    #[test]
    fn exploration() {
        assert_eq!(2 + 2, 4);
    }

    #[test]
    fn another() {
        panic!("Make this test fail");
    }
}
```

The return:

```
$ cargo test
   Compiling adder v0.1.0 (file:///projects/adder)
    Finished test [unoptimized + debuginfo] target(s) in 0.72s
     Running unittests src/lib.rs (target/debug/deps/adder-92948b65e88960b4)

running 2 tests
test tests::another ... FAILED
test tests::exploration ... ok

failures:

---- tests::another stdout ----
thread 'tests::another' panicked at 'Make this test fail', src/lib.rs:10:9
note: run with `RUST_BACKTRACE=1` environment variable to display a backtrace


failures:
    tests::another

test result: FAILED. 1 passed; 1 failed; 0 ignored; 0 measured; 0 filtered out; finished in 0.00s

error: test failed, to rerun pass `--lib`
```

##### Adding Custom Failure Messages

```rust
    #[test]
    fn greeting_contains_name() {
        let result = greeting("Carol");
        assert!(
            result.contains("Carol"),
            "Greeting did not contain name, value was `{}`",
            result
        );
    }
```

The error:

```
$ cargo test
   Compiling greeter v0.1.0 (file:///projects/greeter)
    Finished test [unoptimized + debuginfo] target(s) in 0.93s
     Running unittests src/lib.rs (target/debug/deps/greeter-170b942eb5bf5e3a)

running 1 test
test tests::greeting_contains_name ... FAILED

failures:

---- tests::greeting_contains_name stdout ----
thread 'tests::greeting_contains_name' panicked at 'Greeting did not contain name, value was `Hello!`', src/lib.rs:12:9
note: run with `RUST_BACKTRACE=1` environment variable to display a backtrace


failures:
    tests::greeting_contains_name

test result: FAILED. 0 passed; 1 failed; 0 ignored; 0 measured; 0 filtered out; finished in 0.00s

error: test failed, to rerun pass `--lib`
```

##### Using `Result<T, E>` in tests

Here is a exampkle to test with `Result<T, E>`

```rust
#[cfg(test)]
mod tests {
    #[test]
    fn it_works() -> Result<(), String> {
        if 2 + 2 == 4 {
            Ok(())
        } else {
            Err(String::from("two plus two does not equal four"))
        }
    }
}
```

Rather than calling the `assert_eq!` macro, we return `Ok(())` whe the test passes and an `Err` with a `String` inside when the test fails.

Writing tests so they return a `Result<T, E>` enables you to use the question mark operation in the body of tests, which can be a convenient way to write tests that should fail if any operation within them return an `Err` variant.

You can't use the `#[should_panic]` annotation on tests that use `Result<T, E>`. To assert that an operation return an `Err` variant, *don't* use the question mark operation on the `Result<T, E>` value. Instead, use `assert!(value.is_err())`.

# I will stop to see tests for now, and back after.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Accepting Command Line Arguments

Create a new project, the first task is accept its two command line aruments: the file path and a string to search for. That is, we want to be able to run our program with `cargo run`, two hyphens to indicate the following arguments are for our program rather than for `cargo`, a string to search for, and a path to a file to search in, like so:

`cargo run -- searchstring example-filename.txt`.

[The project](./minigrep/)

### Reading the Argument Values

To enable to a project to read the values of command line we pass to it, we need the `std::env::args` function.
This function returns an iterator of the command line arguments passed.

Iterators: Iterators produces a series of values, and we can call the `collect` method on an iterator to turn it into a collection, such as a vector, that contains all the elements the iterator produces

(Iterator em c# e acredito que é igual em tudo: e um objeto que percorre conteineres, particularmente listas)

We can use the `collect` function to create many kinds of collections, so we explicitly annotate the type of `args` to specify that we want a vector of strings. `collect` is one function you do often need to annotate because Rust isn't able to infer the kind of collection you want.