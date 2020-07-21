using System;
using System.Collections.Generic;

class Aula55
{
    static void Main(string[] args)
    {
        Dictionary <int, string> veiculos = new Dictionary<int, string>();

        veiculos.Add(10, "Carro");
        veiculos.Add(5, "Aviao");
        veiculos.Add(0, "Navio");
        veiculos.Add(20, "Moto");
        veiculos.Add(15, "Patinente");

        veiculos.Remove(20);

        int chave = 20;
        if (veiculos.ContainsKey(chave))
        {
            Console.WriteLine("A chave {0} esta na coleção", chave);
        }
        else
        {
            Console.WriteLine("A chave {0} nao esta na coleção", chave);
        }
        Console.WriteLine("--------------------------------------------");

        veiculos[15] = "Bicicleta";

        // veiculos.Clear();
        Console.WriteLine("Tamanho do Dictionary: {0}", veiculos.Count);
        Console.WriteLine("--------------------------------------------");
        string valor = "Bicicleta";
        if(veiculos.ContainsValue(valor))
        {
            Console.WriteLine("O valor {0} esta na coleção", valor);
        }else {
            Console.WriteLine("O valor {0} nao esta na coleção", valor);
        }
        Console.WriteLine("--------------------------------------------");

        foreach (var carro in veiculos)
        {
            Console.WriteLine(carro.Value);
        }





    }
}