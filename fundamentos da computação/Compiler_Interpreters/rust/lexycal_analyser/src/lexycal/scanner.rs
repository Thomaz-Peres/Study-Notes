mod token;
use std::fs;

// pub fn scanner(filename: String) {
//     let mut content: char;

//     let mut txtContent = filename.as_bytes();

//     // content = txtContent.to_string();
// }

pub struct Scanner {
    content: Vec<char>,
    estado: i32,
}

impl Scanner {
    pub fn new(filename: &String) -> Self {
        let binding = &fs::read(&filename).expect("Unable to read the file");
        let mut txt_content = String::from_utf8_lossy(&binding);
        let content: Vec<char> = txt_content.chars().collect();

        Scanner { content: content, estado: 0 }
    }

    pub fn next_token(&self, content: String) -> Option<token::Token> {
        let mut estado: i32 = 0;
        let mut pos = 0;

        if self.is_end(&content, pos) {
            return None;
        }

        let current_char = self.next_char(content, pos);

        let mut in_while: bool = true;
        while in_while == true {
            match estado {
                0 => {
                    if self.is_char(current_char) {
                        estado = 1;
                    } else if self.is_digit(current_char) {
                        estado = 3;
                    } else if self.is_space(current_char) {
                        estado = 0;
                    } else if self.is_operator(current_char) {
                        estado = 5;
                    } else {
                        return None;
                    }
                }
                1 => {
                    if self.is_char(current_char) || self.is_digit(current_char) {
                        estado = 1;
                    } else {
                        estado = 2;
                    }
                }
                2 => {
                    let token = token::Token::set_type(token::TokenEnum::TkIdentifier);
                    return Some(token);
                }
                _ => {
                    break;
                }
            }
        }

        None
    }

    pub fn is_digit(&self, c: char) -> bool {
        c >= '0' && c <= '9'
    }

    pub fn is_char(&self, c: char) -> bool {
        (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
    }

    pub fn is_operator(&self, c: char) -> bool {
        c == '>' || c == '<' || c == '=' || c == '!'
    }

    pub fn is_space(&self, c: char) -> bool {
        c == ' ' || c == '\t' || c == '\n' || c == '\r'
    }

    pub fn next_char(&self, content: String, mut pos: i32) -> char {
        pos -= 1;
        content.chars().nth(pos as usize).unwrap()
    }

    pub fn is_end(&self, content: &String, pos: i32) -> bool {
        pos == (content.len() as i32)
    }

    pub fn back(&self, mut pos: i32) {
        pos -= 1;
    }
}
