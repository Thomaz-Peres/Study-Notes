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
    pub fn new_token(token_id: TokenEnum, string: String) -> Self {
        Token { token_id: token_id, string: string}
    }

    pub fn teste_new_token() -> Self {
        Token { token_id: TokenEnum::TkAssign, string: String::from("") }
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

    pub fn set_text(&mut self, string : String) {
        self.string = string;
    }
}