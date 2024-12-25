// true = λa. λy a
// false = λa. λy y

type Bool = <A>(x: A) => (y: A) => A;

const true_: Bool = (x) => (y) => x;
const false_: Bool = (x) => (y) => y;

const And = (a: Bool, b: Bool): Bool => <A>(x: A) => (y: A) => a(b(x)(y))(y);
const ifElse = <A>(cond: Bool, ifTrue: A, ifFalse: A): A => cond(ifTrue)(ifFalse);

console.log(And(true_, false_));
console.log(And(true_, true_));


type Nat = <A>(x: A) => (b: (acc: A) => A) => A;
const zero: Nat = (z) => (b) => z;
const succ: (n: Nat) => Nat =
    (n) =>
    <A>(z: A) =>
    (s: (acc: A) => A) =>
        s(n<A>(z)(s));

const one = succ(zero);
console.log(one);