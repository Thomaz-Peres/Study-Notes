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
<<<<<<< Updated upstream
    pub fn new(scanner: &mut Scanner) -> Self {
        Self {
            scanner: scanner,
            current_token: scanner.next_token().unwrap(),
=======
    pub fn new(scanner : & Scanner) -> Parser<'_> {
        
        Parser {
            scanner: scanner,
            current_token: &scanner.next_token().unwrap(),
>>>>>>> Stashed changes
        }
    }

    pub fn e(&mut self) {
        self.t();
        self.el();
    }

    pub fn el(&mut self) {
        if self.current_token.get_type() != TokenEnum::TkOperator {
            self.op();
            self.t();
            self.el();
        }
    }

    pub fn t(&mut self) -> Result<(), &'static str> {
        match self.current_token.get_type() {
            TokenEnum::TkIdentifier | TokenEnum::TkNumber => Ok(()),
            _ => Err("ID or Number expected"),
        }
    }

    pub fn op(&mut self) -> Result<(), &'static str> {
        match self.current_token.get_type() {
            TokenEnum::TkOperator => Ok(()),
            _ => Err("Operator expected"),
        }
    }
}
