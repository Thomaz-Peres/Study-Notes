mod parser;
mod lexycal;

use parser::parser::Parser;
use lexycal::scanner::Scanner;
use std::{fs, os::unix::process};

fn main() {
    let filename = fs::read_to_string("input.isi")
                    .expect("Fail to read the file");

    let mut scan = Scanner::new(&filename);
    let _parser = Parser::new(&scan, &scan.next_token().unwrap());

    let token = scan.next_token();
    loop {
        if let Err(e) = token {
            println!("Application error: {e}");
        };
    }
}
