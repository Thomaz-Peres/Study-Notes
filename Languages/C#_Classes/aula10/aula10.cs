using System;

class Aula10
{
    enum DiasSemana
    {
        Domingo,
        Segunda,
        Terça,
        Quarta,
        Quinta,
        Sexta,
        Sábado
    };
    static void Main()
    {
        DiasSemana Domingo = DiasSemana.Domingo;
        DiasSemana Segunda = DiasSemana.Segunda;

        Console.WriteLine(Domingo + " é antes de " + Segunda);

        //  Usando em formas de indice
        DiasSemana ds = (DiasSemana)0;
        Console.WriteLine(ds);

        //  Pegando o valor do Enum
        int ps = (int)DiasSemana.Sexta;
        Console.WriteLine(ps);
    }

}