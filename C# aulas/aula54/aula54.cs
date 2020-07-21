using System;

namespace Calc1
{
    class Area
    {
        public static float Quadrado(float bas, float altura)
        {
            if (bas == 0 || altura == 0)
            {
                throw new Exception("Base ou altura nao podem ser 0");
            }
            return bas * altura;
        }
    }
}

class Aula54
{
    static void Main(string[] args)
    {
        float area = 0;

        try
        {
            area = Calc1.Area.Quadrado(10f, 5f);
            System.Console.WriteLine("Area do quadrado: {0}", area);
        }
        catch (Exception e)
        {
            System.Console.WriteLine("ERRO: {0}", e.Message);
        }
        finally
        {
            System.Console.WriteLine("Fim do processo.");
        }
    }
}