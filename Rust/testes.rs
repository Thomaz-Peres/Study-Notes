fn main() {
    // let s = String::from("Hello");

    // takes_ownership(s);
    // println!("{s}"); // for this work, i need called a clone, because I send the variable to
    //                  // 'some_string', and 's' is free
    
    // let x = 5;
    
    // makes_copy(x);
    // println!("{x}");

    // let mut s = String::from("hello");

    // let r1 = &s; // no problem
    // let r2 = &s; // no problem
    // let r3 = &mut s; // BIG PROBLEM

    // println!("{}, {}, and {}", r1, r2, r3);

    let mut s = String::from("hello");

    let r1 = &s; // no problem
    let r2 = &s; // no problem
    println!("{} and {}", r1, r2);
    // variables r1 and r2 will not be used after this point

    let r3 = &mut s; // no problem
    println!("{}", r3);
    // println!("{}", r1); // this give me a error
}

// fn takes_ownership(some_string: String) {
//     println!("{some_string}");
// }

// fn makes_copy(some_interger: i32) {
//     println!("{some_interger}");
// }

// Here I can called s1 again, because I passed a reference to the value,
// not the value to a neww variabel
// fn main() {
//     let s1 = String::from("hello");

//     let (s2, len) = calculate_length(&s1);
//     println!("{s1}");


//     println!("The length of '{}' is {}.", s2, len);
// }

// fn calculate_length(s: &String) -> (&String, usize) {
//     let length = s.len(); // len() returns the length of a String

//     (&s, length)
// }

// Here I can~t called s1 again, because I passed the value,
// not a reference
// fn main() {
//     let s1 = String::from("hello");

//     let (s2, len) = calculate_length(s1);
//     println!("{s1}");


//     println!("The length of '{}' is {}.", s2, len);
// }

// fn calculate_length(s: String) -> (String, usize) {
//     let length = s.len(); // len() returns the length of a String

//     (&s, length)
// }