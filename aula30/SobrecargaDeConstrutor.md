# a sobrecarga de construtores permite que define mais de 1 opçao de construtor da classe.
## para ter a sobrecarga, é necessario ter o mesmo nome, porem um conjunto de metodos diferentes.

- exemplo

## abaixo eu criei dois METODOS DE JOGADOR = Sobrecarga de construtores;

public class Jogador
{
    public int energia;
    public bool vivo;
    public string nome;
    public Jogador()
    {
        energia = 100;
        vivo = true;
        nome = "Jogador";
    }
    public Jogador(string n)
    {
        energia = 100;
        vivo = true;
        nome = n;
    }
}

