// mod front_of_house {
//     pub mod hosting {
//         pub fn add_to_waitlist() {}

//         pub fn seat_at_table() {}
//     }

//     mod serving {
//         pub fn take_order() {}

//         pub fn serve_order() {}

//         pub fn take_payment() {}
//     }
// }

// fn deliver_order() {}

// mod back_of_house {
//     fn fix_incorrect_order() {
//         cook_order();
//         super::deliver_order();
//     }

//     fn cook_order() {}
// }

mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist() {}
    }
}

use crate::front_of_house::hosting;

mod customer {
    pub fn eat_at_restaurant() {
        super::hosting::add_to_waitlist();
    }
}