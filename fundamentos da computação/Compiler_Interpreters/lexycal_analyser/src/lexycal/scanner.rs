mod token;

pub fn scanner(filename: String) {
    let mut content: char;

    let mut txtContent = filename.as_bytes();

    // content = txtContent.to_string();
}

pub fn next_token(content: &String) -> Option<token::Token> {
    let mut estado: i32 = 0;
    let mut pos = 0;

    let mut current_char = next_char(content, &pos);

    if is_end(content) {
        return None;
    }

    let mut in_while: bool = true;
    while in_while == true {
        match estado {
            0 => if is_char(current_char) {
                    estado = 1;
                } else if is_digit(current_char) {
                    estado = 3;
                } else if is_space(current_char) {
                    estado = 0;
                }
            1 => if is_char(current_char) || is_digit(current_char) {
                    estado = 1;
                } else {
                    estado = 2;
                }
        }
    }
}


fn is_digit(c: char) -> bool {
    c >= '0'&& c <= '9'
}

fn is_char(c: char) -> bool {
    (c >= 'a'&& c <= 'z') || (c >= 'A' && c <= 'Z')
}

fn is_operator(c: char) -> bool {
    c == '>' || c == '<' || c == '=' || c == '!'
}

fn is_space(c: char) -> bool {
    c == ' ' || c == '\t' || c == '\n' || c == '\r'
}

fn next_char(content: String, pos: &i32) -> char {
    *pos -= 1;
    &content[pos]
}

fn is_end(content : &String, pos: &i32) -> bool {
    *pos == (content.len() as i32)
}

fn back(mut pos: &i32) {
    *pos -= 1
}