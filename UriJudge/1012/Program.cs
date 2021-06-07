using System;
using System.Globalization;

class _1012
{
    static void Main(string[] args)
    {
        string[] linha = Console.ReadLine().Split(' ');

        double A = double.Parse(linha[0], CultureInfo.InvariantCulture);
        double B = double.Parse(linha[1], CultureInfo.InvariantCulture);
        double C = double.Parse(linha[2], CultureInfo.InvariantCulture);

        double pi = 3.14159;

        double triangulo = (A * C) / 2;
        double circulo = pi * Math.Pow(C, 2);
        double trapezio = ((C * (A + B)) / 2);
        double quadrado = Math.Pow(B, 2);
        double retangulo = A * B;

        Console.WriteLine($"TRIANGULO: {triangulo.ToString("f3")}", CultureInfo.InvariantCulture);
        Console.WriteLine($"CIRCULO: {circulo.ToString("f3")}", CultureInfo.InvariantCulture);
        Console.WriteLine($"TRAPEZIO: {trapezio.ToString("f3")}", CultureInfo.InvariantCulture);
        Console.WriteLine($"QUADRADO: {quadrado.ToString("f3")}", CultureInfo.InvariantCulture);
        Console.WriteLine($"RETANGULO: {retangulo.ToString("f3")}", CultureInfo.InvariantCulture);
    }
}