#[derive(Debug, Clone)]
pub struct Token {
    token_id: TokenEnum,
    text: String,
}

#[derive(Debug, Clone)]
pub enum TokenEnum {
    Tk_identifier,
    Tk_number,
    Tk_operator,
    Tk_ponctuation,
    Tk_assign
}