mod token;

pub fn scanner(filename: String) {
    let mut content: char;

    let mut txtContent = filename.as_bytes();

    // content = txtContent.to_string();
}

impl scanner {
    pub fn next_token(content: String) -> Option<token::Token> {
        let mut estado: i32 = 0;
        let mut pos = 0;

        if is_end(&content, pos) {
            return None;
        }

        let current_char = next_char(content, pos);

        let mut in_while: bool = true;
        while in_while == true {
            match estado {
                0 => {
                    if is_char(current_char) {
                        estado = 1;
                    } else if is_digit(current_char) {
                        estado = 3;
                    } else if is_space(current_char) {
                        estado = 0;
                    } else if is_operator(current_char) {
                        estado = 5;
                    } else {
                        return None;
                    }
                }
                1 => {
                    if is_char(current_char) || is_digit(current_char) {
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

    pub fn is_digit(c: char) -> bool {
        c >= '0' && c <= '9'
    }

    pub fn is_char(c: char) -> bool {
        (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
    }

    pub fn is_operator(c: char) -> bool {
        c == '>' || c == '<' || c == '=' || c == '!'
    }

    pub fn is_space(c: char) -> bool {
        c == ' ' || c == '\t' || c == '\n' || c == '\r'
    }

    pub fn next_char(content: String, mut pos: i32) -> char {
        pos -= 1;
        content.chars().nth(pos as usize).unwrap()
    }

    pub fn is_end(content: &String, pos: i32) -> bool {
        pos == (content.len() as i32)
    }

    pub fn back(mut pos: i32) {
        pos -= 1;
    }
}
