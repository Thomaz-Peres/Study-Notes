Some judments try myself

| Formal notation for juddments | Description                                                                            |
| ----------------------------- | -------------------------------------------------------------------------------------- |
| $\Gamma \vdash T$  Type       | $T$ is a type (under assumptions $\Gamma$).                                            |
| $\Gamma \vdash t : T$         | $t$ is a term of type $T$ (under assumptions $\Gamma$)                                 |
| $\Gamma \vdash T_1 = T_2$     | Type $T_1$ is equal to type $T_2$ (under assumptions $\Gamma$)                         |
| $\Gamma \vdash t_1 = t_2 : T$ | Terms $t_1$ and $t_2$ are both of type $T$ and are equal (under assumptions $\Gamma$). |

This will like something like this

```typescript
// Γ ⊢ T Type
type T = number;

// Γ ⊢ t : T
let t: T = 10;

// Γ ⊢ T1 = T2
type T1 = {a: number};
type T2 = {a: number, b?: string};
let x: T1 = {a: 1};
let y: T2 = x; // This should not give a compile error as T1 is assignable to T2
console.log(x == y); // This should print 'true'
console.log(y == x); // This should print 'true'


// Γ ⊢ t1 = t2 : T
let t1: T = 10;
let t2: T = 10;
console.log(typeof t1 === typeof t2 && t1 === t2); // This should print 'true'


```