#[derive(Debug)]
pub struct DoublyListNode<T> {
    pub data: Option<T>,
    pub next: Option<Box<DoublyListNode<T>>>,
    pub prev: Option<Box<DoublyListNode<T>>>,
}

impl<T: PartialEq> DoublyListNode<T> {
    fn new(data: Option<T>) -> DoublyListNode<T> {
        Self {
            data: data,
            next: None,
            prev: None
        }
    }

    pub fn insert_after(&mut self, after: Option<T>, new_data: Option<T>) -> Result<T, &'static str> {
        if new_data.is_none() {
            return Err("New data not found");
        }

        let mut new_element = DoublyListNode::new(new_data);

        while let Some(mut temp_element) = self.next.as_ref() {
            if temp_element.data.unwrap() == after.unwrap() {
                new_element.prev = Some(temp_element);
                new_element.next = temp_element.next;
            }

            return Ok(new_element.data.unwrap());
        }

        return Ok(new_element.data.unwrap());
        // new_element.prev = Some();
    }
}

// #[derive(Debug)]
// pub struct Head<T> {
//     head: Option<Box<DoublyListNode<T>>>,
//     tail: Option<Box<DoublyListNode<T>>>,
// }

// impl<T: PartialEq> Head<T> {
//     pub fn new() -> Self {
//         Self{ head: None, tail: None }
//     }
// }