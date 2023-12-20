// use Scanner;
// use std::env;
use std::fs::{self};
use scanner::Scanner;
use parser::Parser;

use crate::scanner;

// #[path = "lexycal/scanner.rs"] mod scanner;
// #[path = "lexycal/token.rs"] mod token;
#[path = "parser/parser.rs"] mod parser;
#[path = "error/error.rs"] mod error;


fn main() {
    let filename = fs::read_to_string("input.isi").expect("Fail to read the file");
    let mut scan = Scanner::new(filename);
    let parser = Parser::new(&mut Option<scan>, scan.next_token());

    loop {
        let token = scan.next_token();
        if !token.is_none() {
            println!("{:?}" ,token);
        }
    }
}
