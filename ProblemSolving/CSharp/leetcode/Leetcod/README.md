For exercise 3, I started thinking about memory usage on LeetCode. When I tried using GC.Collect() in C#, the memory usage dropped from 43MB to 40MB. However, the runtime increased from 5ms to around 69-80ms. Crazy! Is this trade-off worth making in companies ?

Is there another way to improve it ? Maybe by using static variables, `using` statements, or implementing `IDisposible` ?

![alt text](image-1.png)
