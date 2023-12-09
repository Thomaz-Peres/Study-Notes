using System;

class Teste2
{
    static void Main()
    {

        int[] numeros = new int [6];
        char escolha;

        inicio:

        Console.Clear();

        Console.WriteLine("Passe 6(seis) numeros, te darei a ordem do menor para o maior, e vice-versa");
        numeros[0] = Convert.ToInt32(Console.ReadLine());
        numeros[1] = Convert.ToInt32(Console.ReadLine());
        numeros[2] = Convert.ToInt32(Console.ReadLine());
        numeros[3] = Convert.ToInt32(Console.ReadLine());
        numeros[4] = Convert.ToInt32(Console.ReadLine());
        numeros[5] = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("--------------------------------------\n");
        Console.WriteLine("Do maior para o menor: ");
        Array.Sort(numeros);
        foreach (int n in numeros)
        {
            Console.WriteLine(n);
        }
        Console.WriteLine("--------------------------------------\n");
        
        Console.WriteLine("Do menor para o maior");
        Array.Reverse(numeros);
        foreach (int n in numeros)
        {
            Console.WriteLine(n);
        }
        Console.Write("Quer tentar denovo ? [s/n]");
        escolha = char.Parse(Console.ReadLine());
        if(escolha == 's')
        {
            goto inicio;
        }
        else if(escolha == 'n')
        {
            Console.Clear();
            Console.WriteLine("Fim do programa");
        }
    }

}