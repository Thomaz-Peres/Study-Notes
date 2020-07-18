## Metodos sao conjuntos de instruçoes, um bloco de instrução que pode ser chamado  a qualquer problema do nosso programa

- corpo de um metodo.
static void ola()


### quando se faz um metodo do tipo VOID, ele nao retorna nada.

#### metodo simples e sem retorno de dados e sem entrada de parametros.

- lembrando que para utilziar o metodo, voce precisa CHAMALO 

static void Ola()
{
    Console.Write("salve");
}

# é possivel entrar dentro do metodo e alterar valores dentro do metodo.
static void Soma(int a, int b)
{
    int resultado = a + b;
    Console.Write("A soma de " + a + " + " + b + " é igual a : " + resultado);
}

## no exemplo acima eu digo q tenho um METODO de SOMA, onde ele tem dois elementos (A , B)
## e dentro do metodo eu SOMO esses elementos e escrevo o resultado.
### e dentro do metodo principal eu passo os valores, como no exemplo abaixo

static void Main()
{
    Soma(10, 5);
}

# se eu quiser escrever os VALORES do METODO, eu crio as variaveis no metodo q inicia, e digo q elas sao (CONSOLE.READLINE) e coloca dentro dos parametros pedidos pelo metodo SOMA
## exemplo abaixo

static void Main()
{
    int v1, v2;
    v1 = Convert.ToInt32(Console.ReadLine());
    v2 = Convert.ToInt32(Console.ReadLine());
    Soma(v1, v2);
}

# EXISTEM METODOS que retornam VALORES, eu faço a soma e retornar o resultado para que chamou o resultado
## por exemplo um metodo que retorna a soma dos valores entrados como argumentos
### - no lugar do VOID vc utiliza um TIPO de VARIAVEL
#### -- exemplo abaixo

-- Estou dizendo que eu quero que o metodo retorne o RESULTADO, 
--- Entao quem fizer a chamada do metodo soma, ele recebe como retorno a soma do A + B

static int Soma(int a, int b)
{
    int resultado = a + b;
    return resultado;
}

- E quando um metodo retorna um valor, 
.é necessario usar o metodo para quem faz a chamada
    . Entao voce coloca o METODO para quem esta fazendo a chamada 
        . entao precisa colocar ela em uma variavel, ou em um Console.Write (exemplo abaixo);

static void Main()
{
int v1, v2;
var r;
v1 = Convert.ToInt32(Console.ReadLine());
v2 = Convert.ToInt32(Console.ReadLine());
r = Soma(v1, v2);
Console.WriteLine("A soma de {0} e {1} é: {2}",v1 ,v2,r);
}

## acima, a variavel R chama o metodo soma, que retorna o valor da soma, e utilizou o R para fazer a impressao do resultado.

