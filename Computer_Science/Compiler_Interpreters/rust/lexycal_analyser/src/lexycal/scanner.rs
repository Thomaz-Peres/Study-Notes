use std::fs;
use super::token::{Token, TokenEnum};

#[derive(Debug, Clone)]
pub struct Scanner {
    content: Vec<char>,
    estado: i32,
    pos: usize,
}

impl Scanner {
    pub fn new() -> Scanner {
        let binding = &fs::read("input.isi").expect("Unable to read the file");
        let txt_content = String::from_utf8_lossy(&binding);
        let content: Vec<char> = txt_content.chars().collect();

        Scanner { content: content, estado: 0, pos: 0 }
    }

    pub fn next_token(&mut self) -> Result<Token, &'static str> {
        if self.is_end() {
            return Err("Token not found");
        }

        // let token;
        let mut term = String::from("");

        loop {
            let current_char = self.next_char();
            self.pos += 1;
            match self.estado {
                0 => {
                    if self.is_char(current_char) {
                        term.push(current_char);
                        self.estado = 1;
                    } else if self.is_digit(current_char) {
                        term.push(current_char);
                        self.estado = 3;
                    } else if self.is_space(current_char) {
                        self.estado = 0;
                    } else if self.is_operator(current_char) {
                        self.estado = 5;
                    } else {
                        continue;
                        // return Err("Token state not found");
                    }
                }
                1 => {
                    if self.is_char(current_char) || self.is_digit(current_char) || self.is_char_end(current_char) {
                        term.push(current_char);
                        self.estado = 1;
                    } else if self.is_space(current_char) || self.is_operator(current_char) {
                        self.estado = 2;
                    } else {
                        continue;
                        // return Err("Token state not found");
                    }
                }
                2 => {
                    self.back();
                    let token = Token::new_token(TokenEnum::TkIdentifier, term);
                    return Ok(token);
                }
                3 => {
                    if self.is_digit(current_char) {
                        term.push(current_char);
                        self.estado = 3;
                    } else if !self.is_char(current_char) {
                        self.estado = 4;
                    } else {
                        continue;
                        // return Err("Token state not found");
                    }
                }
                4 => {
                    self.back();
                    let token = Token::new_token(TokenEnum::TkNumber, term);
                    return Ok(token);
                }
                5 => {
                    term.push(current_char);
                    let token = Token::new_token(TokenEnum::TkOperator, term);
                    return Ok(token);
                }
                _ => {
                    continue;
                    // return Err("Token state not found");
                }
            }
        }
    }

    fn is_digit(&self, c: char) -> bool {
        c >= '0' && c <= '9'
    }

    fn is_char(&self, c: char) -> bool {
        (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
    }

    fn is_operator(&self, c: char) -> bool {
        c == '>' || c == '<' || c == '=' || c == '!'
    }
    
    fn is_space(&self, c: char) -> bool {
        c == ' ' || c == '\t' || c == '\n' || c == '\r'
    }

    pub fn next_char(&self) -> char {
        if self.is_end() {
            return '\0';
        }
        *self.content.get(self.pos).unwrap()
    }

    fn is_end(&self) -> bool {
        self.pos == self.content.len()
    }

    fn is_char_end(&self, c: char) -> bool {
        c == '\0'
    }

    pub fn back(&mut self) {
        self.estado = 0;
        self.pos -= 1;
    }
}
