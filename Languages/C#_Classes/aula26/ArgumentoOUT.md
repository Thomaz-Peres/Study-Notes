# Argumento OUT
## o argumento out funciona de forma semelhante na UTILIZAÇÃO, nao sua FUNCIONALIDADE.
------------------------------------------------------------------
## Ele permite que tenha posibilidade que o metodo retorne mais de 1 VALOR de SAIDA.


- ele ta dividindo o quociente da divisao
    - e retornando o quociente
----------------------------------------------------
static int Divide(int dividendo, int divisor)
{
    int quociente;
    quociente = dividendo/divisor;
    return quociente;
}

# vale lembrar que nao se pode RETURN  dois valores diferetes.
## abaixo eu quero retornar o restante da divisao, entao preciso do OUT

- abaixo eu consigo ter duas saidas no metodo.

static int Divide(int dividendo, int divisor, out int resto)
{
    int quociente;
    quociente = dividendo/divisor;
    resto = dividendo % divisor;
    return quociente;
}

# eu poso ter varios elementos OUT