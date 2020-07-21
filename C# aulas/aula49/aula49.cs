using System;

class Mat
{
    public static double pi = 3.14;

    public static int dobro(int n)
    {
        return n * 2;
    }
}

class Aula49
{
    static void Main()
    {
        double vpi = Mat.pi;
        int num = 10;
        num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("O valor de PI é : {0}", vpi);
        Console.WriteLine("O dobro do valor escolhido é : {0}", Mat.dobro(num));
    }
}