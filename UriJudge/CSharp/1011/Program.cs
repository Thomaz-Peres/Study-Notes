using System;
using System.Globalization;

class _1011
{
    static void Main(string[] args)
    {
        double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double pi = 3.14159d;
        double volume = ((4/3.0) * pi * Math.Pow(raio, 3));
        
        Console.WriteLine($"VOLUME = {volume.ToString("f3")}", CultureInfo.InvariantCulture);
    }
}