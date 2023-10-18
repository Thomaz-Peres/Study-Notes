use crate::{scanner::Scanner, token::{Token, TokenEnum}};

pub struct Parser {
    scanner: Option<Scanner>,
    current_token: Token
}

impl Parser {

    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: Option<Scanner>, token: Token) -> Self {
        Parser { scanner: scanner, current_token: token }
    }

    pub fn E(mut self) {
        self.T();
        // self.EL();
    }

    pub fn EL(mut self) {}

    pub fn T(mut self) {
        // if let Some(scanner) = &self.scanner.take() {
        //     let token = scanner.next_token().unwrap();
        //     // Use token here
        // }

        let mut token = self.scanner.unwrap().next_token();

        if token.as_ref().unwrap().get_type() != &TokenEnum::TkIdentifier || token.as_ref().unwrap().get_type() != &TokenEnum::TkIdentifier {
            
        }
    }

    pub fn OP(&self) {}
}