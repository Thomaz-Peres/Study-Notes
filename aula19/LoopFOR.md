## loop for é mais utilizado quando sei a quantidade que vou repetir os comandos.

### base do FOR
using System;

class Aula19
{
    static void Main()
    {
        int[] num = new int[10];
        
        for (int num = 0; num < 10; num++)
        {
            Console.WriteLine("Valor do num: {0}",num);
        }
    }
}