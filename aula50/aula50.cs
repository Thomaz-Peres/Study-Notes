using System;

delegate int Op(int n1, int n2);

class Mat
{
    public static int soma(int n1, int n2)
    {
        return n1 + n2;
    }

    public static int multi(int n1, int n2)
    {
        return n1 * n2;
    }
}

class Aula50
{
    static void Main(string[] args)
    {
        int resultado;

        Op d1 = new Op(Mat.soma);

        resultado = d1(10, 50);

        System.Console.WriteLine("Soma : {0}", resultado);

        d1 = new Op(Mat.multi);

        resultado = d1(10, 50);

        System.Console.WriteLine("Multiplicação : {0}", resultado);
    }
}