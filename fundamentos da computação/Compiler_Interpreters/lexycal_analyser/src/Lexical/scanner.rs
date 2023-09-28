fn scanner(filename: String) {
    let content: char;
    let estado: i32 = 0;
    let pos: i32 = 0;

    let txtContent: String;
    txtContent = filename.as_bytes;

    content = txtContent.to_string();
}

fn next_token(content: &String) -> token::Token {
    if (is_end(content)) {
        return null;
    } else {
        
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

fn next_char(content : &String, pos: &i32) -> char {
    content[pos++]
}

fn is_end(content : &String, pos: &i32) -> bool {
    pos == content.lenght
}

fn back(pos: &i32) {
    pos--
}