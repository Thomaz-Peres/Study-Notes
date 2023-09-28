#[derive(Debug, Clone, Deserialize)]
pub struct Token {
    tyype: i32,
    text: String,
}

#[derive(Debug, Clone, Deserialize)]
pub enum TokenEnum {
    Tk_identifier,
    Tk_number,
    Tk_operator,
    Tk_ponctuation,
    Tk_assign
}