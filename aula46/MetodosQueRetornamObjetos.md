## metodos podem retornar objetos.

public Ovo botar()
    {
        numOvo++;
        return new Ovo(numOvo, nomeGalinha);
    }


class Ovo
{
    private int numOvo;
    private string minhaGalinha;
    public Ovo(int numOvo, string minhaGalinha)
    {
        this.numOvo = numOvo;
        this.minhaGalinha = minhaGalinha;
        Console.WriteLine("Ovo criado: {0} - {1}", this.numOvo, this.minhaGalinha);
    }
}