using System;

class URI
{

    static void Main(string[] args)
    {

        string[] linha = Console.ReadLine().Split(' ');

        int a = int.Parse(linha[0]);
        int b = int.Parse(linha[1]);

        if (a > b)
        {
            Console.WriteLine($"O JOGO DUROU {(b + 24) - a} HORA(S)");
        }
        else if (b == a || a == b)
        {
            Console.WriteLine($"O JOGO DUROU {24} HORA(S)");
        }
        else if (b > a)
        {
            Console.WriteLine($"O JOGO DUROU {b - a} HORA(S)");
        }

    }

}