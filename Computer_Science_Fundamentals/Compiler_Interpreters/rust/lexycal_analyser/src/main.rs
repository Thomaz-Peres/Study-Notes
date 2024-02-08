mod parser;
mod lexycal;

use parser::parser::Parser;
use lexycal::scanner::Scanner;
use std::fs;

fn main() {
    let filename = fs::read_to_string("input.isi")
                    .expect("Fail to read the file");

    let mut scan = Scanner::new(&filename);
    let parser = Parser::new(scan, &scan.next_token().unwrap());

    loop {
        let token = scan.next_token();
        
        if let Err(e) = token {
            println!("Application error: {e}");
        }
    }
}
