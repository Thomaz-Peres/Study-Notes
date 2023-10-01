// use Scanner;
// use std::env;
use std::fs;
use scanner::Scanner;
use token::Token;

#[path = "lexycal/scanner.rs"] mod scanner;
#[path = "lexycal/token.rs"] mod token;


fn main() {
    let filename = fs::read_to_string("../input.isi").expect("Fail to read the file");
    println!("{:?}", filename);
    let scanner = Scanner::new(&filename);

    let mut token: Option<token::Token> = None;

    while token.is_none() {
        token = scanner.next_token();
        if !token.is_none() {
            println!("{:?}" ,token);
        }
    }
}
