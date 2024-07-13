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

###