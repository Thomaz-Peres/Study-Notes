using System;
using System.Globalization;

class _1009
{
    static void Main(string[] args)
    {

        string nome = Console.ReadLine();
        double salarioFixo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double totalVendas = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double comissao = (totalVendas * 15) / 100;
        double total = comissao + salarioFixo;

        Console.WriteLine($"TOTAL = R$ {total.ToString("f2")}", CultureInfo.InvariantCulture);

    }

}