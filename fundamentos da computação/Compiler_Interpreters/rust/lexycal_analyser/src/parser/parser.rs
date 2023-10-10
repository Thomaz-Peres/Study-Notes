pub struct Parser {
    scanner: Scanner,
    current_token: Token
}

impl Parser {

    // O parser recebe o scanner (analisador lexico) como parametro pois a cada procedimento,
    // invoca-o sob demanda.
    pub fn new(scanner: Scanner) -> Self {
        Parser { scanner: scanner }
    }

    pub fn E() {
    }

    pub fn EL() {}

    pub fn T() {}

    pub fn OP() {}
}