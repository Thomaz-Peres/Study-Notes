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