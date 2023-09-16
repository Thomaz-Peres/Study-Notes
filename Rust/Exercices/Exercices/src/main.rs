// TODO: remove this when you're done with your implementation.
// #![allow(unused_variables, dead_code)]
pub fn luhn(cc_number: &str) -> bool {
    // unimplemented!();

    let without_spaces = cc_number.replace(" ", "");
    if without_spaces.len() <= 2 || cc_number.is_empty() {
        return false;
    }

    if !without_spaces.chars().all(|c| c.is_digit(10)) {
        return false;
    }

    let mut x = without_spaces.parse::<i64>().unwrap();

    let mut last_number: i64 = 0;
    let mut second_last_number: i64 = 0;
    let mut second_last_sum: i64 = 0;
    let sum;

    let mut i = 0;
    while i < without_spaces.len() {
        last_number += x % 10;
        second_last_number = ((x % 100) / 10) * 2;

        if second_last_number >= 10 {
            while second_last_number != 0 {
                second_last_sum += second_last_number % 10;
                second_last_number /= 10;
            }
        } else {
            second_last_sum += second_last_number;
        }
        x /= 100;
        i += 2;
    }
    
    sum = second_last_sum + last_number;
    
    if sum % 10 == 0 {
        true
    } else {
        false
    }
}

#[test]
fn test_non_digit_cc_number() {
    assert!(!luhn("foo"));
    assert!(!luhn("foo 0 0"));
}

#[test]
fn test_empty_cc_number() {
    assert!(!luhn(""));
    assert!(!luhn(" "));
    assert!(!luhn("  "));
    assert!(!luhn("    "));
}

#[test]
fn test_single_digit_cc_number() {
    assert!(!luhn("0"));
}

#[test]
fn test_two_digit_cc_number() {
    assert!(!luhn(" 0 0 "));
}

#[test]
fn test_valid_cc_number() {
    assert!(luhn("4263 9826 4026 9299"));
    assert!(luhn("4539 3195 0343 6467"));
    assert!(luhn("7992 7398 713"));
}

#[test]
fn test_invalid_cc_number() {
    assert!(!luhn("4223 9826 4026 9299"));
    assert!(!luhn("4539 3195 0343 6476"));
    assert!(!luhn("8273 1232 7352 0569"));
}

#[allow(dead_code)]
fn main() {
    println!("{}", luhn("4263 9826 4026 9299"));
    // test_invalid_cc_number();
}