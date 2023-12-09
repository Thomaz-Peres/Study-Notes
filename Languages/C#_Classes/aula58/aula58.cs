using System;
using System.Collections.Generic;

class Aula58
{
    static void Main(string[] args)
    {
        List<string> carros = new List<string>();
        string[] carros2 = new string[10];

        carros.Add("Golf");
        carros.Add("HRV");
        carros.Add("Focus");
        carros.Add("Argo");
        carros.Add("HRV");

        // carros2.AddRange(carros);

        if (carros.Contains("Gol"))
        {
            System.Console.WriteLine("Está na lista");
        }
        else
        {
            System.Console.WriteLine("Não encontrado");
        }

        carros.CopyTo(carros2, 2);

        carros.Insert(1, "Cruze");

        int posicao = carros.LastIndexOf("HRV");
        

        foreach (var carro in carros)
        {
            System.Console.WriteLine("Carro {0}", carro);
        }

        string c = Console.ReadLine();
        int pos;
        pos = carros.IndexOf(c);
        Console.WriteLine("Carro {0} esta na posicão {1}", c, pos);
        System.Console.WriteLine("Ultimo HRV esta na posicao {0}",posicao);
    }
}