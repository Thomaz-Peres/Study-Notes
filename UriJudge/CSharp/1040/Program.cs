using System;
using System.Globalization;

class Uri
{
    public static void Main(string[] args)
    {
        string[] linha = Console.ReadLine().Split(' ');

        double n1 = Convert.ToDouble(linha[0], CultureInfo.InvariantCulture);
        double n2 = Convert.ToDouble(linha[1], CultureInfo.InvariantCulture);
        double n3 = Convert.ToDouble(linha[2], CultureInfo.InvariantCulture);
        double n4 = Convert.ToDouble(linha[3], CultureInfo.InvariantCulture);
        
        double media = Math.Round(((n1 * 2) + (n2 * 3) + (n3 * 4) + n4) / 10, 1);
        Console.WriteLine($"Media: {media.ToString("F1")}", CultureInfo.InvariantCulture);

        if(media >= 7.0)
            Console.WriteLine("Aluno aprovado.");
        else if (media < 5.0)
            Console.WriteLine("Aluno reprovado.");
        else if (media >= 5.0 && media <= 6.9)
        {
            Console.WriteLine("Aluno em exame.");
            
            var nExame = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Nota do exame: {nExame.ToString("F1")}", CultureInfo.InvariantCulture);

            media += nExame;
            media /= 2;

            if(media >= 5)
                Console.WriteLine("Aluno aprovado.");   
            else
                Console.WriteLine("Aluno reprovado.");

            Console.WriteLine($"Media final: {media.ToString("F1")}", CultureInfo.InvariantCulture);
        }
    }
}