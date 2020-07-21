using System;

class Calc
{
    public double Soma(params double[] n)
    {
        double somador = 0;
        for (int i = 0; i < n.Length; i++)
        {
            somador += n[i];
        }
        return somador;
    }

    public int Soma(params int[]n)
    {
        int somador = 0;
        for (int i = 0; i < n.Length; i++)
        {
            somador += n[i];
        }
        return somador;
    }
}

class Aula47
{
    static void Main()
    {
        Calc calc = new Calc();

        // var resultado = calc.Soma(10, 5);   // inteiros
        var resultado = calc.Soma(10.2, 5.4);   // doubles

        Console.WriteLine(resultado);
    }
}