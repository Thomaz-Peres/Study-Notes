fn main() {
    let s = String::from("Hello World");
    let x = first_word(&s);
    println!("{x}");
}

fn first_word(s: &String) -> &str {
    let bytes = s.as_bytes();

    for (i, &item) in bytes.iter().enumerate() {
        if item == b' ' {
            return &s[..i];
        }
    }

    &s[..]
}

// fn main() {
//     let s = String::from("hello");

//     let len = s.len();

//     let slice = &s[0..2];
//     println!("{slice}");
//     let slice = &s[..2];
//     println!("{slice}");

//     let slice = &s[3..len];
//     println!("{slice}");
//     let slice = &s[3..];
//     println!("{slice}");
    
//     let len = s.len();
    
//     let slice = &s[0..len];
//     println!("{slice}");
//     let slice = &s[..];
//     println!("{slice}");
// }