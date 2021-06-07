using System;
using System.Glozalization;

class _1014
{
    static void Main(string[] args)
    {
        int distanciaTotal = int.Parse(Console.ReadLine());
        double combustivelGasto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        var gastei = distanciaTotal / combustivelGasto;

        Console.WriteLine($"{gastei.ToString("f3")} km/l", CultureInfo.InvariantCulture);
    }
}