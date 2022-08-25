using System;

class _1013
{
    static void Main(string[] args)
    {
        string[] linha = Console.ReadLine().Split(' ');
        int a = int.Parse(linha[0]);
        int b = int.Parse(linha[1]);
        int c = int.Parse(linha[2]);

        int maiorAB = (a + b + Math.Abs(a - b)) / 2;

        if (maiorAB > c)
            Console.WriteLine($"{maiorAB} eh o maior");
        else
            Console.WriteLine($"{c} eh o maior");

    }
}