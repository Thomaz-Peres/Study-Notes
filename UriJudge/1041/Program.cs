using System;

class URI
{

    static void Main(string[] args)
    {

        string[] linha = Console.ReadLine().Split(' ');

        double x = double.Parse(linha[0]);
        double y = double.Parse(linha[1]);

        if (x > 0 && y > 0)
            Console.WriteLine("Q1");

        if (x < 0 && y > 0)
            Console.WriteLine("Q2");

        if (x < 0 && y < 0)
            Console.WriteLine("Q3");

        if (x > 0 && y < 0)
            Console.WriteLine("Q4");

        if (x == 0 && y == 0)
            Console.WriteLine("Origem");

        if (x == 0 && y != 0)
            Console.WriteLine("Eixo Y");

        if (x != 0 && y == 0)
            Console.WriteLine("Eixo X");

    }

}