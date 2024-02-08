use crate::{
    lexycal::token::{Token, TokenEnum},
    Scanner,
};

pub struct Parser {
    pub scanner: Scanner,
    current_token: Token,
}

impl Parser {
    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new<'c>(scanner: Scanner, token: &'c Token) -> Self {
        Parser {
            scanner: scanner,
            current_token: *token,
        }
    }

    pub fn e(&mut self) {
        self.t();
        self.el();
    }

    pub fn el(&mut self) {
        self.current_token = self.scanner.next_token().unwrap();
        if self.current_token.get_type() != TokenEnum::TkOperator {
            self.op();
            self.t();
            self.el();
        }
    }

    pub fn t(&mut self) -> Result<(), &'static str> {
        self.current_token = self.scanner.next_token().unwrap();

        match self.current_token.get_type() {
            TokenEnum::TkIdentifier | TokenEnum::TkNumber => Ok(()),
            _ => Err("ID or Number expected"),
        }
    }

    pub fn op(&mut self) -> Result<(), &'static str> {
        self.current_token = self.scanner.next_token().unwrap();

        match self.current_token.get_type() {
            TokenEnum::TkOperator => Ok(()),
            _ => Err("Operator expected"),
        }
    }
}
