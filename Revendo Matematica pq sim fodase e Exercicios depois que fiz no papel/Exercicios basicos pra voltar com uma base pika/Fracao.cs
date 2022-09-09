using System;

public class Fracao
{
    static void Main(string[] args)
    {
        int vencerdor1, vencerdor2, vencerdor3, arrecadado, participantes = 20, quantiaPorParticipante = 30;

        arrecadado = participantes * quantiaPorParticipante;
        
        vencerdor1 = arrecadado / 2;
        vencerdor2 = arrecadado / 3;
        vencerdor3 = arrecadado - vencerdor1 - vencerdor2;

        Console.WriteLine($"Primeiro colocado recebeu: {vencerdor1}\n Segundo colocado recebeu: {vencerdor2}\n Terceiro colocado recebeu: {vencerdor3}");
    }
}