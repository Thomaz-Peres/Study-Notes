#[derive(Debug, Clone)]
pub struct Token {
    token_id: TokenEnum,
    string: String,
}

#[derive(Debug, PartialEq, Eq, Clone)]
pub enum TokenEnum {
    TkIdentifier,
    TkNumber,
    TkOperator,
    TkPonctuation,
    TkAssign
}

impl Token {
    pub fn new_token(token_id: TokenEnum, string: String) -> Token {
        Token { token_id, string}
    }

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

    pub fn get_type(&self) -> &TokenEnum {
        &self.token_id
    }

    pub fn set_text(&mut self, string : String) {
        self.string = string;
    }
}
