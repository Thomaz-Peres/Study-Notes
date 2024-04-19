struct SinglyListNode<T> {
    pub data: T,
    pub next: Option<Box<SinglyListNode<T>>>,
}

impl<T> SinglyListNode<T> {
    fn new(data: T) -> SinglyListNode<T> {
        SinglyListNode { data, next: None }
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

    pub fn add_last(&mut self, data: T)  {
        let new_element = Box::new(SinglyListNode::new(data));

        if let Some(ref mut head) = self.head {
            let mut temp_element = head;
            while let Some(ref mut next_node) = temp_element.next {
                temp_element = next_node;
            }

            temp_element.next = Some(new_element);
        } else {
            self.head = Some(new_element);
        }
    }

    pub fn get_index(&self, index: i32) -> () {
        if index < 0 {
            ()
        }

        if let Some(ref head) = self.head {
            let mut temp_element = head;
            let mut i = 0;
            while let Some(ref mut current) = temp_element {
                if i >= index {
                    break;
                }

                temp_element = &mut current.next();
            }

        }


    }
}

fn main() {
    print!("Hello World!");
}
