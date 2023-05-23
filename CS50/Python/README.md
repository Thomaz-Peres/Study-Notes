for loop in `Python`

```py
for i in [0, 1, 2]:
    print("hello, world")

# or


# range it is good because That's not going to give you a list of 1,000 values all at once.
# It's going to give you 1,000 value one at a time, reducing memory significantly in the computer itself.
for i in range(3):
    print("hello, world")
```



### Swap in python

```python
x = 1
y = 2

print(f"x is {x}, y is {y}")
# we can do this
x, y = y, x
print(f"x is {x}, y is {y}")
```