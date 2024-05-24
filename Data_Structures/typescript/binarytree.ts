type List<T> = null | {
    element: T,
    next: List<T>
}
let empty = null;

const append = <T>(list: List<T>, element: T) : List<T> => ({
    element: element,
    next: list
});

const list_one: List<string> = append(empty, "a");
const list_two = { element: 2, next: list_one };

console.log(list_one);
console.log(list_two);