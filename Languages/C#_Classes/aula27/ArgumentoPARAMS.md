# o argumento PARAMS permite a entrade de 0 ou mais argumentos para dentro de um METODO

## o PARAMS nao precisa especificar quantos parametros eu quero, e apartir do PARAMS ele sabe que posso entrar com 0 ou nenhum valor do tipo tipo que informei
### exemlpo
-----------------------------------

- tem q ter cuidado para ver se o PARAM entrou com 0 ou 1 ou MAIS de 1 valor
   - se for 0 nao tem como somar,
        - se for 1 mostro o valor que foi informado
            - se for mais de 1, eu percorro o array e somar o valor q esta em cada posicao do array. 


static void soma(params int[] n)
{
    int resultado = n1 + n2;
    Console.WriteLine("A soma de {0} com {1} é {2}", n1, n2, res);
}

## adicionando valores nos params

static void Main()
{
    soma(10, 5, 2, 4, 7);
}