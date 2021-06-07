using System;
using System.Globalization;

class URI
{

    static void Main(string[] args)
    {

        string[] linha = Console.ReadLine().Split(' ');

        double A = Convert.ToDouble(linha[0], CultureInfo.InvariantCulture);
        double B = Convert.ToDouble(linha[1], CultureInfo.InvariantCulture);
        double C = Convert.ToDouble(linha[2], CultureInfo.InvariantCulture);

        if (A < B + C && C < B + A && B < A + C)
        {
            Double perimetro = A + B + C;
            Console.WriteLine($"Perimetro = {perimetro.ToString("F1")}", CultureInfo.InvariantCulture);
        }
        else
        {
            double area = ((A + B) * C) / 2;
            System.Console.WriteLine($"Area = {area.ToString("F1")}", CultureInfo.InvariantCulture);
        }

    }

}