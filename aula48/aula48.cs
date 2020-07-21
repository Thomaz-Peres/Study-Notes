using System;

class Calc
{
    public int fator(int n) // 5! = 5*4*3*2*1
    {
        int resultado;
        if (n <= 1)
        {
            resultado = 1;
        }
        else
        {
            resultado = n * fator(n - 1);   // entra a recursivdade de numero -1 vezes o anterior.
        }
        return resultado;
    }
}

class Aula48
{
    static void Main()
    {
        Calc calc = new Calc();

        var resultado = calc.fator(5);

        Console.WriteLine(resultado);
    }
}