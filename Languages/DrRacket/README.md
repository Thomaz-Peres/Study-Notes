Some notes about free course = https://learning.edx.org/course/course-v1:UBCx+HtC1x+2T2017/home


![image](https://user-images.githubusercontent.com/58439854/209225116-82db7f68-fca8-4e98-8c68-85eac1fbc841.png)

Number -> Number


![image](https://user-images.githubusercontent.com/58439854/209234125-3204165d-5f0f-4344-9a00-8d67e291d1f6.png)

***Signature*** is to tell whaht type of data a function consumes and what type of data it produces, Exemple:

    - Number -> Number

in this case I consume a Number and produce a Number


***Purpose*** is to give me a succinct description of what the function produces given waht it consumes (uma descrição sucinta do que a função produz dado o que ela consome.)


***Stub*** is like a piece of scalffolding that we're going to put in place for a short period of time. (implementado por um curto período de tempo.)

- Stub has to be is a function definition that has the correct function name ```double``` and has the correct number of parameters, in this case ```one```.
- And the **stub** it produces a dummy result of the correct type.
Since this function produces number, I'll make the stub produce zero,
because zero is certainly a number. *Example*:

        (define (double n) 0)



The next step of the recipe is the template or the ***inventory***

The **investory or template** is a function with the right function name and the right parameter

    (define (double n)
        (... n))

![image](https://user-images.githubusercontent.com/58439854/209255869-9905cec3-e301-4529-86aa-aa468a2ddb44.png)

my way: 

```rkt
(define (double v)
    ((if (string? v) string-append +) v "s"))

(double "test")
```

![image](https://user-images.githubusercontent.com/58439854/209364233-b85be396-6508-4f0e-9ce7-98a77fababaa.png)

Teacher way:

![image](https://user-images.githubusercontent.com/58439854/209364434-04707427-f985-4f03-8cfd-cc70739972cc.png)



### Poorly Formed Problems

n this case the problem statement isn't very specific about the function we need to design.

![image](https://user-images.githubusercontent.com/58439854/209599470-6f188dc7-6506-4bc4-8c09-cea4c65a0fd6.png)