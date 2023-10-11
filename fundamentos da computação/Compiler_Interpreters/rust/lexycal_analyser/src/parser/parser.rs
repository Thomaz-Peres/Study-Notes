use crate::{scanner::Scanner, token::{Token, TokenEnum}};

pub struct Parser {
    scanner: Scanner,
    current_token: Token
}

impl Parser {

    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: Scanner, token: Token) -> Self {
        Parser { scanner: scanner, current_token: token }
    }

    pub fn E(&self) {
        self.T();
        self.EL();
    }

    pub fn EL(&self) {}

    pub fn T(&self) {
        let token = self.scanner.next_token().unwrap();

        if token.get_type() != &TokenEnum::TkIdentifier || token.get_type() != &TokenEnum::TkIdentifier {
            
        }
    }

    pub fn OP(&self) {}
}