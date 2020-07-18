# O metodo construtor ele inicializa o objeto quando instancio a classe, quando eu instanciar um objeto da classe, um metodo construtor é chamado, e o objetivo dele é inicializar as variaveis declaradas na classe.
## toda classe tem um construtor.

- Para definir que um metodo é o construtor da classe
    - basta eu ter um metodo com o mesmo nome da classe

- e por padrao ele é executado quando é instanciado um novo objeto da classe

## um construtor pode ter parametros.
- construtor
public class Jogador
{
public int energia;
public bool vivo;
public string nome;

    public Jogador(string n)
    {
        energia = 100;
        vivo = true;
        nome = n;
    }
}

## o metodo destrutor ele é executado antes da classe for destruida.

- destrutor
- depois de passar o codigo, ele exlui o metodo.

public class Jogador
{
    public int energia;
    public bool vivo;
    public string nome;

    ~Jogador()
    {
        
    }
}