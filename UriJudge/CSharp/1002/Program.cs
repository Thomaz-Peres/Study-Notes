using System;
using System.Globalization;

namespace _1002
{
    class Program
    {
        static void Main(string[] args)
        {
            double raio = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double n = 3.14159d;
            double area = n * Math.Pow(raio, 2);

            System.Console.WriteLine($"A={area.ToString("f4")}",CultureInfo.InvariantCulture);
        }
    }
}
