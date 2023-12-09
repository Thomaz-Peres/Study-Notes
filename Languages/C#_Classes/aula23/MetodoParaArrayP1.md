# 1. Preenchendo o vetor 1 com 5 numeros aleatorios de 0 a 49.

Random random = new Random();
for (int i = 0; i < vetor1.Length; i++)
{
    vetor1[i] = random.Next(50);
}

## a cada intenração ele roda o vetor1 com o next para sortear um valor de 0 a 49 e colocar na posição que esta indicada no indice do vetor, no caso no 1
    - lendo as informações do vetor1.
Console.WriteLine("Elementos do vetor1");
foreach (int n in vetor1)
{
    Console.WriteLine(n);
}

## Metodo  -- public static int BinarySearch(array, valor);
1. tem um retorno inteiro e retorna a posicao do elemento procurado.
    - o (array) ele chama direto da classe array, ele passa o array da pesquisa, e no (valor) ele procura o valor que estou pesquisando
        - se o elemento nao estiver no array ele retorna -1


Console.WriteLine("BinarySearch");
int pos = Array.BinarySearch(o vetor que quero procurar, numero que quero pesquisar);


## metodo copy -- faz copias dos elementos de um elemento para outros

- Ar = array
- qtde = quantidade elementos que quero copiar
public static void Copy(Ar_origem, Ar_destino, qtde_elementos);
Console.WriteLine("Copy");
- vetor2 recebe os elementos do vetor1, e a quantidade de elementos que quero copiar (no caso todos os elementos do vetor1) 
Array.Copy(vetor1, vetor2, vetor1.Length);
foreach (int n in vetor2)
{
    Console.WriteLine(n);
}

- foreach imprimi os elementos copiados


## metodo copy to -- Metodo que é chamado a partir do vetor de origem

- todos os elemetos do Array destino (array1), e todos os elementos do (vetor3) vao ser copiados a partir do (elemento 0)

public void CopyTo(Ar_destino, a_partir_desta_pos)
Console.WriteLine("Copy");
vetor1.CopyTo(vetor3, 0);
foreach(int n in vetor3)
{
    Console.WriteLine(n);
}


## metodo GetLowerBound -- Retorna o menor indice do array/matriz
### como array so tem uma dimensão, so preciso de uma
####                                            qual dimensao eu quero receber o menor indice

public int GetLowerBound(dimensão);
Console.WriteLine("GetLowerBound");

### quero receber o menor valor do array do indice 0 (no caso sera o valor 0)
int MenorIndiceVetor = vetor1.GetLowerBound(0);     

### quero receber o menor valor da matriz do indice 1
int MenorIndiceMatriz_D1 = matriz.GetLowerBound(1);
Console.WriteLine("Menor índice do vetor1 {0}", MenorIndiceVetor);
Console.WriteLine("--


## metodo GetUpperBound -- Retorna o maior indice do array/matriz


public int GetUpperBound(dimensão)
Console.WriteLine("GetUpperBound");

### quero receber o maior valor do array do indice 0 (no caso sera o valor 4)
int MaiorIndiceVetor = vetor1.GetUpperBound(0);

### quero receber o maior valor da matriz do indice 1 
int int MenorIndiceMatriz_D1 = matriz.GetUpperBound(1);
Console.WriteLine("Maior índice do vetor1 {0}", MaiorIndiceVetor);
Console.WriteLine("--------------------------------------");


## metodo GetValue -- retorna o valor a partir de um indice
# lembrando que é um object, entao se precisar do numeral, tera que fazer um TypeCast
### ja que nao é necessario/possivel tem uma matriz so de inteiro.

public object GetValue(long indice);
Console.WriteLine("GetValue");

## ja que é um object, é necessario converter o tipo do objeto que tem dentro do array 

### a partir do vetor, é chamado o GetValue, e ele retorna o valor que esta na posição do indice 3
int valor0 = Convert.ToInt32(vetor1.GetValue(3));

### por ser uma matriz, é necessario indicar 2 indices.
int valor1 = Convert.ToInt32(matriz.GetValue(1, 3));
Console.WriteLine("Valor da posição 3 do vetor1: {0}", valor0);


## metodo IndexOf -- retorna o indice do valor indicado no segundo parametro
### a partir da classe array, passo o array que quero pesquisar, e a posição que quero pesquisar.
### ele vai retornar a posicao do primeiro valor encontrado
# exemplo : int[] n = new int[5,5,5,5,5], se todos tiverem valor 5, o IndexOf ele retorna o o primeiro valor do numero q eu indiquei
public static int IndexOf(array, valor);
Console.WriteLine("IndexOf");
## ele vai pesquisar o primeiro valor 3 que tem na matriz
int indice1 = Array.IndexOf(vetor1, 3);
Console.WriteLine("Indice do primeiro valor 3: {0}", indice1);
Console.WriteLine("--------------------------------------");


## metodo LastIndexOf -- retorna o indice do valor indicado no segundo parametro
# mesma coisa, porem ao contrario do indexOf



## metodo Reverse --  ele inverte a ordem dos elementos
### é chamado a partir da classe Array, e é preciso indicar o array que deseja fazer a reversao.
public static void Reverse(array);
Array.Reverse(vetor1);
foreach (int n in vetor1);
{
    Console.WriteLine(n);
}


## metodo SetValue -- permite a gente Definir um valor em uma posicao do vetor


- ele é chamado a partr do vetor, e preciso indicar qual o valor que quero Definir, e a posicao que quero definir;

public void SetValue(object valor, long pos);

#### definindo(setando) o valor 99 na posicao 0
vetor2.SetValue(99, 0);

#### setando 0 para todas as posições, ja que o for RECORRE a TODO tamanho do vetor2
for(int i = 0; i < vetor2.Length; i++)
{
    vetor2.SetValue(0, i);
}
Console.WriteLine("Vetor 2");
foreach (int n in vetor2)
{
    Console.WriteLine(n);
}

## metodo Sort -- Ordena em forma crescente os elementos dentro do array
### é chamado a partir da classe Array, e ele recebe o array que quer ordenar como parametro.

#### no caso abaixo estou ordenando o vetor1, vetor2, e vetor3.
Array.Sort(vetor1);
Array.Sort(vetor2);
Array.Sort(vetor3);
Console.WriteLine("Vetor1");
foreach (int n in vetor1)
{
    Console.WriteLine(n);
}
Console.WriteLine("\nVetor2");
foreach (int n in vetor2)
{
    Console.WriteLine(n).
}
Console.WriteLine("\nVetor3");
foreach (int n in vetor3)
{
    Console.WriteLine(n).
}