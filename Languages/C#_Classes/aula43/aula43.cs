using System;

public interface IVeiculo
{
    void ligar();
    void desligar();
    void info();
}

public interface ICombate
{
    void disparar();
}

class Carro : IVeiculo, ICombate
{
    public bool ligado;
    private int municao;
    public Carro()
    {
        SetMunicao(100);
    }

    public void SetMunicao(int qtde)
    {
        this.municao = qtde;
    }
    public void ligar()
    {
        this.ligado = true;
    }

    public void desligar()
    {
        this.ligado = false ;
    }

    public void disparar(){}

    public void info(){}
}

class Aula43
{
    static void Main()
    {
        Carro c1 = new Carro();
    }
}

