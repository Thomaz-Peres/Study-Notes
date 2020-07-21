## o array de estrutura, é quando voce quer fazer um ARRAY de STRUCTS. logo vc usa iguais variaveis normais (int[] string[]), porém você utiliza no STRUCT

struct Carro{}

tatic void Main()
    {
        Carro[] carros = new Carro[5];
    }

## passando informaçoes 

public void info()
    {
        Console.WriteLine("Modelo: {0}", this.modelo);
        Console.WriteLine("Cor: {0}", this.cor);
        Console.WriteLine("-------------------------");
    }

static void Main()
    {
        Carro[] carros = new Carro[4];

        carros[0].modelo = "HRV";
        carros[0].cor = "Prata";

        carros[1].modelo = "Golf";
        carros[1].cor = "Azul";

        carros[2].modelo = "Honda";
        carros[2].cor = "Preto";

        carros[3].modelo = "Jetta";
        carros[3].cor = "Vermelho";

        // imprimindo as informações
        carros[0].info();
        carros[1].info();
        carros[2].info();
        carros[3].info();
    }

## pode ser feito com FOR tambem
// imprimindo as informações

    for (int i = 0 < carros.Length ; i++)
    {
        carros[i].info();
    }