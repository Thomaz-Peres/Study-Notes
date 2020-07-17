## Loop while é mais utilizado quando nao sabemos a quantidade de vezes que queremos repetir algum comando

- diferença de sintaxe

    diferente do loop, precisa criar a variavel fora da sintaxe


# sintaxe do While
using System;

class Aula20
{
    static void Main()
    {
        int[] num = new int[10];

        int i = num.Length-1;
        while (i > 0)
        {
            num[i] = 0;
            Console.WriteLine(num[i]);
            i--;
        }
        Console.WriteLine("Fim do loop");
    }
}