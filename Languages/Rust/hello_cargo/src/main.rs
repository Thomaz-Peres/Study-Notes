use std::io;

fn main() {
    let apples = 10; // immutable
    let mut guess = String::new(); // mutable

    // Receiving User Input
    // The & indicates that this argument is a reference, which gives you a way to let multiple
    // parts of your code access one piece of data without needing to copy that data into memory multiple times.

    // references are immutable by default
    // Hence, you need to write &mut guess rather than &guess to make it mutable
    io::stdin()
        .read_line(&mut guess)
        .expect("Failed to read line");
    loop
    {
        let guess: u32 = match guess.trim().parse() {
            Ok(num) => num,
            Err(_) => continue,
        };
    }

    println!("You guessed: {guess}");
}
