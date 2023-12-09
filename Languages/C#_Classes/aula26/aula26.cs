using System;

class Aula26
{
    static void Main()
    {
        int dividend, divis, quoc, rest;

        dividend = Convert.ToInt32(Console.ReadLine());
        divis = Convert.ToInt32(Console.ReadLine());


        quoc = Divide(dividend, divis, out rest);

        Console.WriteLine("{0}/{1}: quociente = {2} e resto = {3}", dividend, divis, quoc, rest);

    }

    static int Divide(int dividendo, int divisor, out int resto)
    {
        int quociente;
        quociente = dividendo/divisor;
        resto = dividendo % divisor;
        return quociente;
    }
}