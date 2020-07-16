using System;

class Aula09
{
    static void Main()
    {
        int num = 2;

        // << significa os bitwise para a ESQUERDA(logo eu dobro os valores)
        // >> significa os bitwise para a DIREITA(logo eu divido os valores)
        num = num << 2;

        Console.WriteLine(num);
    }
}