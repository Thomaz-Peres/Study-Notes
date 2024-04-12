mod parser;
mod lexycal;

use parser::parser::Parser;
use lexycal::scanner::Scanner;

fn main() {
    // let filename = fs::read_to_string("./input.isi")
    //                 .expect("Fail to read the file");

    // print!("{filename}");
    let mut scan = Scanner::new();
    // print!("{:?}", scan.);
    let x = scan.next_token().unwrap();
    // print!("{:?}", x);
    let _parser = Parser::new(&scan.clone(), &scan.clone().next_token().unwrap());

    _parser.e();
    loop {
        let token = scan.next_token().expect("teste");
        println!("{:?}" ,token);
        // if let Err(e) = token {
        //     println!("Application error: {e}");
        // };
    }

    // let mut some_while: bool = false;

    // while some_while == false {
    //     let token = scan.next_token();
    //     if !token.is_none() {
    //         println!("{:?}" ,token);
    //     } else if token.is_none() {
    //         some_while = true;
    //     }
    // }
}
