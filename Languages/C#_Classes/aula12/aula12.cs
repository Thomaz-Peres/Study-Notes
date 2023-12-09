using System;

class Aula12
{
    static void Main()
    {
        int n1, n2, n3, n4, res;
        string resultado = "Reprovado";
        //  inicializa todas variaveis como 0
        n1 = n2 = n3 = n4 = res = 0;

        Console.Write("Digite a sua nota 1: ");
        n1 = int.Parse(Console.ReadLine());

        Console.Write("Digite a sua nota 2: ");
        n2 = int.Parse(Console.ReadLine());

        Console.Write("Digite a sua nota 3: ");
        n3 = int.Parse(Console.ReadLine());

        Console.Write("Digite a sua nota 4: ");
        n4 = int.Parse(Console.ReadLine());

        res = n1 + n2 + n3 + n4;

        if (res >= 60)
        {
            resultado = "Aprovado";
        }

        Console.WriteLine("Notas: {0} - Resultado: {1}", res, resultado);

    }
}