// const THREE_HOURS_IN_SECONDS: u32 = 60 * 60 * 3;

// fn main() {
//     let x = 5;
//     println!("The value of x is {x}");
//     let mut y = 5;
//     println!("The value of y is {y}");
//     y = 10;
//     println!("The value of y is {y}");
//     println!("The value of y is {THREE_HOURS_IN_SECONDS}");
// }


// shadowing
// fn main() {
//     let x = 5;

//     let x = x + 1;

//     {
//         let x = x * 2;
//         println!("The value of x in the inner scope is: {x}");
//     }

//     println!("The value of x is: {x}");
    
//     let spaces = "   ";
//     println!("The value of spaces is: {spaces}");
//     let spaces = spaces.len();
//     println!("The value of spaces is: {spaces}");
    
//     // The value of spaces is:
//     // The value of spaces is: 3
    
//     // let mut spaces = "   ";
//     // println!("The value of spaces is: {spaces}");
//     // spaces = spaces.len(); // error
// }

// fn main() {
//     // addition
//     let sum = 5 + 10;

//     // subtraction
//     let difference = 95.5 - 4.3;

//     // multiplication
//     let product = 4 * 30;

//     // division
//     let quotient = 56.7 / 32.2;
//     let truncated = -5 / 3; // Results in -1

//     // remainder
//     let remainder = 43 % 5;
// }

// tuples
// fn main() {
//     let tup: (i32, f64, u8) = (500, 6.4, 1);
// }

// more tuple
// fn main() {
//     let x: (i32, f64, u8) = (500, 6.4, 1);

//     let five_hundred = x.0;

//     let six_point_four = x.1;

//     let one = x.2;

//     println!("The value of x0 is: {five_hundred}");
//     println!("The value of x1 is: {six_point_four}");
//     println!("The value of x2 is: {one}");
// }

// arrays
// fn main() {
//     let a = [1, 2, 3, 4, 5];
//     let a: [i32; 5] = [1, 2, 3, 4, 5];
//     // Here, i32 is the type of each element. After the semicolon, the number 5 indicates the array contains five elements.
//     let a = [3; 5];
//     // The array named a will contain 5 elements that will all be set to the value 3 initially. This is the same as writing let a = [3, 3, 3, 3, 3]; but in a more concise way.
// }

// fn main() {
//     let y = {
//         let x = 3;
//         x + 1
//     };

//     println!("The value of y is: {y}");
//     // The value of y is: 4
// }

fn main()
{
    let x = some_one(6);
    let y = some_one2(6);

    println!("The value of x is: {x}");
    println!("The value of y is: {y}");
}

// functions with return value in rust (is like functional languages)
// If I using a semicolon in the final, i need add return, else I can do like (fn some_one') 
fn some_one(x: i32) -> i32 {
    return x + 1;
}

fn some_one2(x: i32) -> i32 {
    x + 1
}