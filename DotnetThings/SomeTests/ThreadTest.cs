// for (int i = 0; i < 10; i++)
// {
//   int temp = i;
//   new Thread (() => Console.Write (temp)).Start();
// }

// // const int repeticoes = 100;
// // int z = 0;

// // object locker = new object();

// // new Thread(() =>
// // {
// //     for (int contador = 0; contador < repeticoes; contador++)
// //     {
// //         lock(locker)
// //         {
// //             Thread.Sleep(100);
// //             Console.WriteLine($"Thread 2: {z++}");
// //         }
// //     }
// // }).Start();

// // for (int contador = 0; contador < repeticoes; contador++)
// // {
// //     lock(locker)
// //     {
// //         Thread.Sleep(100);
// //         Console.WriteLine($"Thread 1: {z++}");
// //     }
// // }

// // new Task(() =>
// // {
// //     for (int contador = 0; contador < repeticoes; contador++)
// //     {
// //         Console.WriteLine("Task 1");
// //     }
// // }).Start();
// // for (int contador = 0; contador < repeticoes; contador++)
// // {
// //     Console.WriteLine("Task 2");
// // }

// // class ThreadTest
// // {
// //     static bool done;
// //     static object locker = new object();

// //     static void Main()
// //     {
// //         new Thread(Go).Start();
// //         Go();
// //     }

// //     static void Go()
// //     {
// //         lock (locker)
// //         {
// //         if (!done) { Console.WriteLine("Done"); done = true; }
// //         }
// //     }
// // }
