using System;
using System.Globalization;

class _1017
{
    static void Main(string[] args)
    {
        int tempoGasto = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        float velMedia = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        float resultado = (tempoGasto * velMedia) / 12;

        Console.WriteLine(resultado.ToString("f3"), CultureInfo.InvariantCulture);

    }
}