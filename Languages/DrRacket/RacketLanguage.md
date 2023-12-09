### Function in Racket


```rkt
(require 2htdp/image)

(define (bulb c)
  (+ 1 c))

  (bulb 5)
```
- Another function

```rkt
(require 2htdp/image)

(+ (* 3 2) 1)

(define (max-dim img)
  (if (> (image-width img) (image-height img))
      (image-width img)
      (image-height img)))

(max-dim (rectangle 30 20 "solid" "blue"))

```