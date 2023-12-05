using System;

class URI
{

    static void Main(string[] args)
    {

        int hi, hf, mi, mf, AUX1, AUX2;

        String[] vet = Console.ReadLine().Split(' ');

        hi = int.Parse(vet[0]);
        mi = int.Parse(vet[1]);
        hf = int.Parse(vet[2]);
        mf = int.Parse(vet[3]);

        if ((hi == hf) && (mi == mf))
        {
            AUX1 = 24;
            AUX2 = 0;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if ((hi == hf) && (mi > mf))
        {
            AUX1 = 23;
            AUX2 = 60 - mi + mf;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if (hi == hf)
        {
            AUX1 = 0;
            AUX2 = mf - mi;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if ((hf > hi) && (mf < mi))
        {
            AUX1 = hf - hi - 1;
            AUX2 = 60 - mi + mf;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if ((hi <= hf) && (mi <= mf))
        {
            AUX1 = hf - hi;
            AUX2 = mf - mi;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if ((hi > hf) && (mi > mf))
        {
            AUX1 = 23 - hi + hf;
            AUX2 = 60 - mi + mf;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
        else if ((hi > hf) && (mi <= mf))
        {
            AUX1 = 24 - hi + hf;
            AUX2 = mf - mi;
            Console.WriteLine("O JOGO DUROU {0} HORA(S) E {1} MINUTO(S)", AUX1, AUX2);
        }
    }

}