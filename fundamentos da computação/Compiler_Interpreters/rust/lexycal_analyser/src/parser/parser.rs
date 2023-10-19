use crate::{scanner::Scanner, token::{Token, TokenEnum}, error::{Result, self}};

pub struct Parser {
    pub scanner: Option<Scanner>,
    current_token: Option<Token>
}

impl Parser {

    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: Option<Scanner>, token: Option<Token>) -> Self {
        Parser { scanner: scanner, current_token: token }
    }

    pub fn e(&mut self) {
        self.t();
        self.el();
    }

    pub fn el(&mut self) {
        if let Some(scanner) = &mut self.scanner {
            self.current_token = scanner.next_token();
            if !self.current_token.is_none() {
                self.op();
                self.t();
                self.el();
            }
        }
    }

    pub fn t(&mut self) -> error::Result {

        // if let Some(scanner) = &mut self.scanner {
        //     if let Some(token) = scanner.next_token() {
        //         if token.get_type() != &TokenEnum::TkIdentifier || token.get_type() != &TokenEnum::TkNumber {
        //             return error::Result::Err(format!("error"));
        //         } else { return error::Result::Ok(1); }
        //     } else { return error::Result::Err(format!("error")); }
        // } else {
        //     return error::Result::Err(format!("error"));
        // }

        if let Some(scanner) = &mut self.scanner {
            self.current_token = scanner.next_token();
            match self.current_token.as_ref().unwrap().get_type() {
                TokenEnum::TkIdentifier | TokenEnum::TkNumber => error::Result::Ok(1),
                _ => error::Result::Err(String::from("ID or Number expected")),
            }
        } else {
            error::Result::Err(String::from("Operator expected"))
        }
    }

    pub fn op(&mut self) -> error::Result {
        if let Some(scanner) = &mut self.scanner {
            self.current_token = scanner.next_token();
            match self.current_token.as_ref().unwrap().get_type() {
                TokenEnum::TkOperator => error::Result::Ok(1),
                _ => error::Result::Err(String::from("Operator expected")),
            }
        } else {
            error::Result::Err(String::from("Token not found"))
        }
    }
}