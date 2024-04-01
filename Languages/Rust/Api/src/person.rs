use std::str::FromStr;

#[derive(Serialize, Deserialize)]
pub struct Person {
    id: Option<i32>,
    name: String,
    age: i32,
    email: String,
}

// #[derive(Debug)]
// pub enum PersonType {
//     Legal,
//     Natural,
// }

// impl FromStr for PersonType {
//     type Err = &'static str;
    
//     fn from_str(input: &str) -> Result<PersonType, Self::Err> {
//         match input {
//             "Legal" => Ok(PersonType::Legal),
//             "legal" => Ok(PersonType::Legal),
//             "Natural" => Ok(PersonType::Natural),
//             "natural" => Ok(PersonType::Natural),
//             _ => Err("not accepted"),
//         }
//     }
// }

impl Person {
    pub fn new(name: String, age: u32, email: String) -> Self {
        Person { name: name, age: age, email }
    }
}