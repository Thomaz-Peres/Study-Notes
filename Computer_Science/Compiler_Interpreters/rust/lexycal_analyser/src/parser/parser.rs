use crate::{
    lexycal::token::{Token, TokenEnum},
    Scanner,
};

pub struct Parser {
    scanner: Scanner,
    current_token: Token,
}

impl Parser {
    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: &Scanner, current_token: Token) -> Parser {
        Parser {
            scanner: scanner.clone(),
            current_token: current_token
        }
    }

    pub fn e(&self) {
        self.t();
        self.el();
    }

    pub fn el(&self) {
        if self.current_token.get_type() != &TokenEnum::TkOperator {
            self.op();
            self.t();
            self.el();
        }
    }

    pub fn t(&self) -> Result<(), &'static str> {
        match self.current_token.get_type() {
            TokenEnum::TkIdentifier | TokenEnum::TkNumber => Ok(()),
            _ => Err("ID or Number expected"),
        }
    }

    pub fn op(&self) -> Result<(), &'static str> {
        match self.current_token.get_type() {
            TokenEnum::TkOperator => Ok(()),
            _ => Err("Operator expected"),
        }
    }
}
