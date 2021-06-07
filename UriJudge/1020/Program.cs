using System;
using System.Globalization;

class URI
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine());
        int ano, mes, dia;

        ano = x / 365;
        mes = (x % 365) / 30;
        dia = (x % 365) % 30;

        Console.WriteLine("{0} ano(s)\n{1} mes(es)\n{2} dia(s)", ano, mes, dia);
    }
}