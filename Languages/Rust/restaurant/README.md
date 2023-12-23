# Grouping Related Code in Modules

To create a lib:
`cargo new restaurant --lib`

We'll define the signatures of functions but leave their bodies empty
to concentrate on the organization of the code, rather than the implementation of a restaurant.

In the restaurant industry, some parts of a restaurant are referred to as *front of house*
and other as *back of house*.

- **Front of house:** Is where customers are, tis encompasses where the hosts seat customers,
servers take orders and payments, and bartenders make drinks.
- **Back of house:** Is where the chefs and cooks work in the kitchen, dishwasers clean up,
and managers do administrative work.

We define a module with the mod keyword followrd by the name of the module (in this case, `front_of_house`).

Inside modules, we can place other modules, as in this case with the modules `hosting` and `serving`.
Modules can also hold definitions for other uitems, such as structs, enums, constants, traits, and functions.

Why `str/main.rs` and `src/lib.rs` are called crate roots ? The reason for this,
because these two files form a module named `crate`.

