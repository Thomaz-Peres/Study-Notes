# passagem por valor

- a passagem por valor é passada como um argumento
    - o argumento vai para uma posição diferente da variavel do metodo
        - embora eu esteja passando a variavel, ele é armazenado em um novo local, logo a operação dentro do metodo nao é realizada com o valor passado no metodo principal. 

## exemplo
static void Main()
{
    ( o valor 10 nao vai passar pelo DOBRAR,)
    int num = 10;   (por que ele foi criado em um novo local).
    Dobrar(num);
    Console.WriteLine(num);
}

static void Dobrar(int valor)
{
    valor *= 2;
}

# Passagem por referencia
- a passagem por referencia utiliza a mesma posicao da variavel.
## na passagem de referencia, é necessario utilizar o operador REF
## é necessariousar o REF tanto no argumento da função, qunato no momento da chamada da funçao
### exemplo

- Abaixo o valor NUM, vai ser realmente alterada pelo metodo

static void Main()
{
    int num = 10;
    Dobrar(ref num);
    Console.WriteLine(num);
}

static void Dobrar(ref int valor)
{
    valor *= 2;
}