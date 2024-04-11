use crate::{
    lexycal::token::{Token, TokenEnum},
    Scanner,
};

pub struct Parser<'a> {
    scanner: &'a Scanner,
    current_token: &'a Token,
}

impl<'a> Parser<'a> {
    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: &'a Scanner, current_token: &'a Token) -> Parser<'a> {
        Parser {
            scanner: scanner,
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
