class BinaryTree<T> {
    constructor(
        value: T,
        left: BinaryTree<T>,
        right: BinaryTree<T>) {
    }
}

const b = new BinaryTree<number>(2, 1, 3);
console.log("B" + b)

type BinaryTree2<T> = 
    | null
    | { value : T, left: null | BinaryTree<T>, right: null | BinaryTree<T> };


const left: BinaryTree2<number> = { value: 1, left: null, right: null };
const right: BinaryTree2<number> = { value: 2, left: null, right: null };
const a: BinaryTree2<number> = { value: 3, left: left, right: right };



console.log(left);
console.log(right);
console.log(a);


class Tupla2<T> {
    constructor(
        public x: T,
        public y: T
    ) {}
}

type Tupla<T> = 
    | { a: T, b: T };

const tupla2: Tupla2<boolean> = new Tupla2<boolean>(true, false);
const tupla3: Tupla<boolean> = { a: true, b: false };


console.log(tupla2)
console.log(tupla3)