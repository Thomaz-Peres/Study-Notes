// fn main() {
//     let mut x: i32 = 10;
//     let ref_x: &mut i32 = &mut x;
//     *ref_x = 20;
//     let z = ref_x.count_ones();
//     println!("ref_x: {ref_x}");
//     println!("z: {z}");
//     println!("x: {x}");
// }

// fn main() {
//     let ref_x: &i32;
//     {
//         let x: i32 = 10;
//         ref_x = &x;
//     }
//     println!("ref_x: {ref_x}");
// }

// fn main() {
//     let mut a: [i32; 6] = [10, 20, 30, 40, 50, 60];
//     println!("a: {a:?}");

//     let s: &[i32] = &a[2..4];
//     a[3] = 32;


//     println!("s: {s:?}");
// }

// fn pick_one<T>(a: T, b: T) -> T {
//     if std::process::id() % 2 == 0 { a } else { b }
// }

// fn main() {
//     println!("coin toss: {}", pick_one("heads", "tails"));
//     println!("cash prize: {}", pick_one(500, 1000));
// }

// fn multiply(x: i16, y: i16) -> i16 {
//     x * y
// }

// fn main() {
//     let x: i8 = 15;
//     let y: i16 = 1000;

//     // Can use x.into() or i16::from(x)
//     println!("{x} * {y} = {}", multiply(x.into(), y));
// }

// fn takes_u32(x: u32) {
//     println!("u32: {x}");
// }

// fn takes_i8(y: i8) {
//     println!("i8: {y}");
// }

// fn main() {
//     let x = 10;
//     let y = 20;

//     takes_u32(x);
//     takes_i8(y);
//     // takes_u32(y);
// }

// const DIGEST_SIZE: usize = 3;
// const ZERO: Option<u8> = Some(42);

// fn compute_digest(text: &str) -> [u8; DIGEST_SIZE] {
//     let mut digest = [ZERO.unwrap_or(0); DIGEST_SIZE];
//     for (idx, &b) in text.as_bytes().iter().enumerate() {
//         digest[idx % DIGEST_SIZE] = digest[idx % DIGEST_SIZE].wrapping_add(b);
//     }
//     digest
// }

// fn main() {
//     let digest = compute_digest("Hello");
//     println!("Digest: {digest:?}");
// }

// use std::any::type_name;
// use std::mem::{align_of, size_of};

// fn dbg_size<T>() {
//     println!("{}: size {} bytes, align: {} bytes",
//         type_name::<T>(), size_of::<T>(), align_of::<T>());
// }

// enum Foo {
//     A,
//     B,
// }

// fn main() {
//     dbg_size::<Foo>();
// }

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
    let n = 75;
    match divide_in_two(n) {
        Result::Ok(half) => println!("{n} divided in two is {half}"),
        Result::Err(msg) => println!("sorry, an error happened: {msg}"),
    }
}