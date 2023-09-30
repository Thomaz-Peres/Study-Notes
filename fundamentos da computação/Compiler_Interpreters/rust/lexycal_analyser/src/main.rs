// use Scanner;
// use std::env;
use std::fs;
use scanner::Scanner;
use token::Token;

#[path = "lexycal/scanner.rs"] mod scanner;
#[path = "lexycal/token.rs"] mod token;


fn main() {
    let filename = fs::read_to_string("../input.isi").expect("Fail to read the file");
    let scanner = Scanner::new(&filename);

    let token: Option<Token> = None;

    // while token.is_none() {
    //     token = scanner.next_token(content)
    // }
}
