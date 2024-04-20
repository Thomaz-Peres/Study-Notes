struct SinglyListNode<T> {
    pub data: T,
    pub next: Option<Box<SinglyListNode<T>>>,
}

impl<T> SinglyListNode<T> {
    fn new(data: T) -> SinglyListNode<T> {
        Self { data, next: None }
    }
}

pub struct Head<T> {
    head: Option<Box<SinglyListNode<T>>>,
}

impl<T> Head<T> {
    pub fn new() -> Self {
        Self { head: None }
    }

    // pub fn start_list(data: T) -> SinglyListNode<T> {
    //     SinglyListNode::new(data)
    // }

    pub fn add_last(&mut self, data: T) {
        let new_element = Box::new(SinglyListNode::new(data));

        match self.head.take() {
            None => {
                self.head = Some(new_element);
                // Some(self.head)
            },
            Some(mut temp_element) => {
                while let Some(next_node) = temp_element.next {
                    temp_element = next_node
                }

                temp_element.next = Some(new_element);
                // Some(new_element)
            }
        }
    }

    pub fn get_index(&mut self, index: i32) -> Option<&T> {
        if index < 0 {
            return None;
        }

        match self.head.as_mut() {
            None => None,
            Some(mut temp_element) => {
                let mut i: i32 = 0;
                while i < index {
                    temp_element = temp_element.next.as_mut().unwrap();
                    i += 1;
                }
                Some(&temp_element.data)
            }
        }
    }
}

// impl<T> Default for Head<T> {
//     fn default() -> Self {
//         Self::new()
//     }
// }


#[cfg(test)]
mod test_singly_list {
    use super::*;

    #[test]
    fn basics() {
        let mut list: Head<i32> = Head::new();
        // list.add_last(5);
        assert_eq!(list.get_index(1), None);
    }
}