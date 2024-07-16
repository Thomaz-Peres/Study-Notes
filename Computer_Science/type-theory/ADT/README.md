# Algebraic Data Type

Are basically types that's formed by composing other types.

We have two common classes of *ADT*, **product types** and **sum types**.


[Reference](https://en.m.wikipedia.org/wiki/Algebraic_data_type)

### Product Type

Are types which normally contain multiple values, and all values of that type has the same combination of field types.

Example of product type:

```ts
type Tupla<T> = 
    | { a: T, b: T };

const tupla: Tupla<boolean> = { a: true, b: false };
console.log(tupla)

// Or can use like a class too

class Tupla2<T> {
    constructor(
        public x: T,
        public y: T
    ) {}
}

const tupla2: Tupla2<boolean> = new Tupla2<boolean>(true, false);
console.log(tupla2)
```

We called that as a Product Types because we calculated the number of possibilities using multiplication. (2 x 2 = 4)

### Sum types

Are types which can store multiple values, but not at same time.

Example of Sum Types:

```ts
class NumberOrStringOrBoolean {
    constructor(
        public x: number | string | boolean
    ) { };
}

type NumberOrStringOrBoolean2 =
    | { x: number | string | boolean }

console.log("-----------------------------------------\n\n")
const numberOrStringOrBoolean1 = new NumberOrStringOrBoolean(5);
console.log(numberOrStringOrBoolean1)
const numberOrStringOrBoolean22 = new NumberOrStringOrBoolean("Teste");
console.log(numberOrStringOrBoolean22)
const numberOrStringOrBoolean23 = new NumberOrStringOrBoolean(true);
console.log(numberOrStringOrBoolean23)
console.log("-----------------------------------------\n\n")



const numberOrStringOrBoolean2: NumberOrStringOrBoolean2 = { x: "teste" };
console.log(numberOrStringOrBoolean2);
const numberOrStringOrBoolean24: NumberOrStringOrBoolean2 = { x: 5 };
console.log(numberOrStringOrBoolean24);
const numberOrStringOrBoolean25: NumberOrStringOrBoolean2 = { x: false };
console.log(numberOrStringOrBoolean25);
```

We calculate number of possibilities using summing the types a constructor has

`x = number + string + boolean`

X = Number of possibilities in the type.
Number = Number of possibilities in a number.
String = Number of possibilities in a string.
Boolean = Number of possibilities in a boolean.