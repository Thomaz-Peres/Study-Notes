using System;
using System.Globalization;

class URI
{

    static void Main(string[] args)
    {

        string[] linha = Console.ReadLine().Split(' ');

        int codigo = int.Parse(linha[0], CultureInfo.InvariantCulture);
        int quantidade = int.Parse(linha[1], CultureInfo.InvariantCulture);

        switch (codigo)
        {
            case 1:
                Console.WriteLine($"Total: R$ {(quantidade * 4).ToString("f2")}", CultureInfo.InvariantCulture);
                break;

            case 2:
                Console.WriteLine($"Total: R$ {(quantidade * 4.5).ToString("f2")}", CultureInfo.InvariantCulture);
                break;

            case 3:
                Console.WriteLine($"Total: R$ {(quantidade * 5).ToString("f2")}", CultureInfo.InvariantCulture);
                break;

            case 4:
                Console.WriteLine($"Total: R$ {(quantidade * 2).ToString("f2")}", CultureInfo.InvariantCulture);
                break;

            case 5:
                Console.WriteLine($"Total: R$ {(quantidade * 1.5).ToString("f2")}", CultureInfo.InvariantCulture);
                break;
        }

    }
}