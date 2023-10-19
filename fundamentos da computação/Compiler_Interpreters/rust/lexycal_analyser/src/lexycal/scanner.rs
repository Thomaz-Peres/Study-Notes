use std::fs;

use crate::token;

pub struct Scanner {
    content: Vec<char>,
    estado: i32,
    pos: usize,
}

impl Scanner {
    pub fn new(filename: String) -> Self {
        println!("{filename}");
        let binding = &fs::read("input.isi").expect("Unable to read the file");
        let txt_content = String::from_utf8_lossy(&binding);
        let content: Vec<char> = txt_content.chars().collect();
        println!("{:?}", content);

        Scanner { content: content, estado: 0, pos: 0 }
    }
    
    pub fn next_token(&mut self) -> Option<token::Token> {
        if self.is_end() {
            return None;
        }

        let mut token = token::Token::new_token(token::TokenEnum::TkAssign, "".to_string());
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
                        return None;
                    }
                }
                1 => {
                    if self.is_char(current_char) || self.is_digit(current_char) {
                        term.push(current_char);
                        self.estado = 1;
                    } else if self.is_space(current_char) || self.is_operator(current_char) {
                        self.estado = 2;
                    } else {
                        return None;
                    }
                }
                2 => {
                    self.back();
                    token = token::Token::new_token(token::TokenEnum::TkIdentifier, term);
                    return Some(token);
                }
                3 => {
                    if self.is_digit(current_char) {
                        term.push(current_char);
                        self.estado = 3;
                    } else if !self.is_char(current_char) {
                        self.estado = 4;
                    } else {
                        return None;
                    }
                }
                4 => {
                    self.back();
                    token = token::Token::new_token(token::TokenEnum::TkNumber, term);
                    return Some(token);
                }
                5 => {
                    term.push(current_char);
                    token = token::Token::new_token(token::TokenEnum::TkOperator, term);
                    return Some(token);
                }
                _ => {
                    return None;
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

    pub fn next_char(&mut self) -> char {
        *self.content.get(self.pos).unwrap()
    }

    pub fn is_end(&self) -> bool {
        self.pos == self.content.len()
    }

    pub fn back(&mut self) {
        self.estado = 0;
        self.pos -= 1;
    }
}
