struct SinglyListNode<T> {
    pub data: T,
    pub next: Option<Box<SinglyListNode<T>>>,
}

impl<T> SinglyListNode<T> {
    fn new(data: T) -> SinglyListNode<T> {
        Self { data, next: None }
    }
}

struct SinglyList<T> {
    head: Option<Box<SinglyListNode<T>>>,
}

impl<T> SinglyList<T> {
    fn new() -> Self {
        Self { head: None }
    }

    pub fn start_list(data: T) -> SinglyListNode<T> {
        SinglyListNode::new(data)
    }

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
            ()
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
