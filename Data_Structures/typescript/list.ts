type List<T> = null | {
    element: T,
    next: List<T>
}

let empty = null;
const isEmpty = <A>(list: List<A>): list is null => list === null;
const append = <T>(list: List<T>, element: T) : List<T> => ({
    element: element,
    next: list
});

const map = <A,B>(f: (el: A) => B, l: List<A>): List<B> => {
    if (isEmpty(l))
        return null;
    else {
        const elemment = f(l.element);
        const next = map(f, l.next);
        return append(next, elemment)
    }
}

const list_one: List<string> = append(empty, "a");
const list_two = { element: 2, next: list_one };

console.log(list_one);
console.log(list_two);
