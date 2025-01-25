
#### Usage

Data structures save as a basis the basis for **Abstract Data Types** (ADT). The ADT defines the logical form of the data type. The data structure implements the physical form of the data type.

Relational databases commonly use B-tree indexes for data retrieval, while compiler implementations usually use hash tables to look up identifiers.

---------------------------------------------------------------
#### Implementation

Data structures are generally based on the ability of a computer to fetch and store data at any place in its memory, specified by a pointer (person->age).

Thus, the array and record data structures are based on computing the addresses of data items with arithmetic operations, while the linked data structures are based on storing addresses of data items within the structure itself.

This approach to data structuring has profound implication for the efficiency and scalability of algorithms. For instance, the contiguous memory allocation in arrays facilitates rapid access and modification operation, leading to optimized performance in sequential data processing scenarios.

The implementation of a data structure usually requires writing a set of procedures. The efficiency of a data structure cannot be analyzed separately from those operations. This observation motivates the theoretical of an **abstract data type**, a data structure that is defined indirectly by the operations that may be performed on it, and the mathematical properties of those operations (including their space and time cost).


## Exponential Search

Exponential search can even out-perform more tradition searches for bounded lists,such as binary search, when the element being searched for is near the beginning of the array. This is because exponential search will run in `O(log i)` time, where `i` is the index of the element being searched for in the list, wherea binary search would run in `O(log n)` time, where `n` is the number of elements in the list.
