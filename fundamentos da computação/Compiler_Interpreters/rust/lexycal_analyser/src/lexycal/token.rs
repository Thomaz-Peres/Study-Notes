#[derive(Debug)]
pub struct Token {
    token_id: TokenEnum,
    string: String,
}

#[derive(Debug)]
pub enum TokenEnum {
    TkIdentifier,
    TkNumber,
    TkOperator,
    TkPonctuation,
    TkAssign
}

impl Token {

    pub fn set_type(token_id: TokenEnum) -> Self {
        Token {
            token_id,
            string: String::from(""),
        }
    }

    pub fn set_token(token_id: TokenEnum, string: String) -> Self {
        Token {
            token_id,
            string
        }
    }
}