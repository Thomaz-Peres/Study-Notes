
// Exemplo para function1
Func<Func<int, int>, int> function1 = (Func<int, int> f) =>
{
  return f(0); // Supondo que 'f' é uma função que aceita um int e retorna um int
};

// Definindo uma função de exemplo que será passada como argumento para function1
Func<int, int> exampleFunction = (int x) =>
{
  return x * 2; // Uma função simples que dobra o valor recebido
};

// Chamando function1 e passando exampleFunction como argumento
int result1 = function1(exampleFunction);
Console.WriteLine("Resultado de function1: " + result1);

// Exemplo para function2
Func<int, Func<int, int>> function2 = (int n) =>
{
  return new Func<int, int>((int x) =>
  {
    return n + x; // Uma função que soma 'n' e 'x'
  });
};

// Chamando function2 e passando um número como argumento
var resultFunction = function2(5);
// Agora, chamando a função resultante com outro número
int result2 = resultFunction(3);
Console.WriteLine("Resultado de function2: " + resultFunction);
