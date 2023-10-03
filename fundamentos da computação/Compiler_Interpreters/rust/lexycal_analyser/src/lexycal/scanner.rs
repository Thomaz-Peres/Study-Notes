mod token;
use std::fs;

pub struct Scanner {
    content: Vec<char>,
    estado: i32,
    pos: usize,
}

impl Scanner {
    pub fn new(filename: String) -> Self {
        println!("{filename}");
        let binding = &fs::read("input.isi").expect("Unable to read the file");
        println!("DEBUG--------------");
        let txt_content = String::from_utf8_lossy(&binding);
        println!("----------------------------");
        let content: Vec<char> = txt_content.chars().collect();
        println!("{:?}", content);

        Scanner { content: content, estado: 0, pos: 0 }
    }

    pub fn next_token(&mut self) -> Option<token::Token> {
        if self.is_end() {
            return None;
        }

        self.estado = 0;
        self.pos = 0;

        let in_while: bool = true;
        while in_while == true {
            let current_char = self.next_char();
            match self.estado {
                0 => {
                    if self.is_char(current_char) {
                        self.estado = 1;
                    } else if self.is_digit(current_char) {
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
                        self.estado = 1;
                    } else {
                        self.estado = 2;
                    }
                }
                2 => {
                    self.back();
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

    pub fn next_char(&mut self) -> char {
        self.pos += 1;
        *self.content.get(self.pos).unwrap()
    }

    pub fn is_end(&self) -> bool {
        self.pos == self.content.len()
    }

    #[warn(dead_code)]
    pub fn back(&mut self) {
        self.pos -= 1;
    }
}
