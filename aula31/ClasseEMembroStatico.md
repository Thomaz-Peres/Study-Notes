# classe static, quer dizer que nao posso instanciar um objeto dentro da classe.
## cuma class static tambem nao podem ter construtores.
### o objeto static utiliza uma posição fixa na memoria
### posso acessar diretamente os membros de uma classe static sem ter q instaciar o objeto, entao eu uso o nome da clase "." o membro que quero acessar (personagem.vida)

- toda classe static, tem que tem membros statics.
    - uma classe nao static, pode CONTER membros statics.

# se eu deixo uma propriedade como static, todos os OBJETOS daquela classe vao ser iguais

- exemplo 

## abaixo, quando eu deixo o tipo NOME como static, eu mudo o nome de todos, e so posso acessar ela com o nome da class, como é mostrado na class AULA31. mais abaixo.

class Inimigo
{
    public bool alerta;
    static public string nome;
    public Inimigo(string n)
    {
        alerta = false;
        nome = n;
    }
    public void info()
    {
        Console.WriteLine(nome);
        Console.WriteLine(alerta);
        Console.WriteLine("-------------------------");
    }
}

# quanddo eu utilizei o (Inimigo.nome = ("Pelé)) eu mudei o nome dos 3 inimigos
## se não fosse static eu teria q usar (i1.nome) (i2.nome)
## (i3.nome)

class Aula31
{
    static void Main()
    {
        Jogador.Iniciar("Thomaz");
        Jogador.info();

        Inimigo i1 = new Inimigo("doido");
        Inimigo i2 = new Inimigo("Maluco");
        Inimigo i3 = new Inimigo("Pirado");

        Inimigo.nome("Pelé");

        i1.info();
        i2.info();
        i3.info();
    }
}