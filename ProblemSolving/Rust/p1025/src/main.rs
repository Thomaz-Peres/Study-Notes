fn main() {
    let mut count: i32 = 0;
    let mut mable: usize = 0;
    let mut search: usize = 0;

    while count < 65 {
        let mut line = String::new();
        std::io::stdin()
            .read_line(&mut line)
            .expect("Failed to readline");

        let mut line = line.split_whitespace();
        mable = line.next().unwrap().parse().unwrap();
        search = line.next().unwrap().parse().unwrap();

        if mable == 0 && search == 0 {
            break;
        }

        let mut mables = vec![0; mable];
        let mut search_meena = vec![0; search];

        let mut x: usize = 0;
        while x < mable + search {
            let mut input = String::new();
            std::io::stdin()
            .read_line(&mut input)
            .expect("Failed to readline");
        
            let number: i32 = input.trim().parse().expect("Ins't a number");
        
            if x < mable {
                mables[x] = number;
            } else {
                search_meena[x - mable] = number;
            }
            x += 1;
        }

        println!("CASE# {}:", count + 1);
        mables.sort();
        for item in &search_meena {
            match mables.iter().position(|&m| m == *item) {
                Some(find_pos) => println!("{} found at {}", item, find_pos + 1),
                None => println!("{} not found", item),
            }
        }
        count += 1;
    }
}
