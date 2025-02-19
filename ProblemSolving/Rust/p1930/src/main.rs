use std::io::Error;

fn main() -> std::io::Result<()> {
    let mut line = String::new();
    std::io::stdin()
        .read_line(&mut line)
        .expect("Failed to readline");

    let mut v: Vec<i32> = Vec::new();

    let mut x = line.split_whitespace();
    v.push(x.next().unwrap().parse().unwrap());
    v.push(x.next().unwrap().parse().unwrap());
    v.push(x.next().unwrap().parse().unwrap());
    v.push(x.next().unwrap().parse().unwrap());

    if v.len() != 4 {
        return Err(Error::new(
            std::io::ErrorKind::InvalidData,
            "Input too long",
        ));
    }

    let mut plus: i32 = 0;
    for i in &v {
        if *i < 2 || *i > 6 {
            return Err(Error::new(
                std::io::ErrorKind::InvalidData,
                "Input too long",
            ));
        }

        plus += i;
    }

    print!("{}\n", plus - 3);
    Ok(())
}
