using System;
using System.Collections.Generic;

class Aula59
{
    static void Main(string[] args)
    {
        Queue<string> veiculos = new Queue<string>();

        veiculos.Enqueue("Carro");
        veiculos.Enqueue("Moto");
        veiculos.Enqueue("Navio");
        veiculos.Enqueue("Aviao");

        string v = "Aviao";
        if(veiculos.Contains(v))
        {
            System.Console.WriteLine("Veiculo " + v + " Encontrado");
        } else
        {
            System.Console.WriteLine("Veiculo " + v + "nao esta na fila");
        }

        // System.Console.WriteLine("Primeiro Veiculo " + veiculos.Dequeue());
        // System.Console.WriteLine("Primeiro Veiculo " + veiculos.Peek());
        // foreach (var i in veiculos)
        // {
        //     System.Console.WriteLine("Veiculo: " + i);
        // }

        while(veiculos.Count > 0)
        {
            System.Console.WriteLine(veiculos.Dequeue());
        }
        System.Console.WriteLine("Fila: " + veiculos.Count);


        System.Console.WriteLine("tamanho da fila:" + veiculos.Count);
    }
}