using System;
using System.Collections.Generic;

class Aula56
{
    static void Main(string[] args)
    {
       LinkedList<string> transporte = new LinkedList<string>();

       transporte.AddFirst("Carro");
       transporte.AddFirst("Aviao");
       transporte.AddFirst("Navio");
       transporte.AddFirst("Motocicleta");

        LinkedListNode<string> nó;
        nó = transporte.FindLast("Navio");

       transporte.AddAfter(nó, "busao");

       transporte.RemoveFirst();

       foreach (var transportes in transporte)
       {
           Console.WriteLine("Transporte: {0}", transportes);
       }
    }
}