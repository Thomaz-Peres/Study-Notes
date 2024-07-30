// // Exemplo para function1
// Func<Func<int, int>, int> function1 = (Func<int, int> f) =>
// {
//   return f(0); // Supondo que 'f' é uma função que aceita um int e retorna um int
// };

// // Definindo uma função de exemplo que será passada como argumento para function1
// Func<int, int> exampleFunction = (int x) =>
// {
//   return x * 2; // Uma função simples que dobra o valor recebido
// };

// // Chamando function1 e passando exampleFunction como argumento
// int result1 = function1(exampleFunction);
// Console.WriteLine("Resultado de function1: " + result1);

// // Exemplo para function2
// Func<int, Func<int, int>> function2 = (int n) =>
// {
//   return new Func<int, int>((int x) =>
//   {
//     return n + x; // Uma função que soma 'n' e 'x'
//   });
// };

// // or

// // Exemplo para function2
// Func<int, Func<int, int>> add = x => y => x + y;
// var b = add(5);
// int result2_2 = b(10);
// Console.WriteLine("Resultado da function 2 do estilo 2: " + result2_2);

// int x = 5;

// // Chamando function2 e passando um número como argumento
// var resultFunction = function2(x);
// // Agora, chamando a função resultante com outro número
// int result2 = resultFunction(x);
// Console.WriteLine("Resultado de function2: " + result2);

// // Exemplo para function2
// Func<string, Func<string, string>> f3 = (string n) => new Func<string, string>((string x) => n + x); // Uma função que soma 'n' e 'x');

// // Chamando function2 e passando um número como argumento
// var resultFunction2 = f3("5");
// // Agora, chamando a função resultante com outro número
// string result3 = resultFunction2("teste");
// Console.WriteLine("Resultado de f3: " + result3);


// // the lambda something like this: (λx.add x x) nat -> nat
// Func<int, int> addTwice = x => x + x;


// // (λv.t)s -> t[v:= s]
// // t é uma expressão ou método que usa 'v'
// // s é o valor que você está passando para a função
// Func<int, int> lambdaTerm = v => v * 2; // 't' deve ser substituído pela expressão correspondente
// int result = lambdaTerm(5); // 's' é o valor que você está aplicando
// Console.WriteLine(result);

// // (λv.t v) -> t
// Func<int, int> lambdaTerm2 = v => v;
// int result4 = lambdaTerm2(5);
// Console.WriteLine(result4);

// // (λv x.t v) -> t

// // the lambda something like this: (λx y.mult x y) nat -> nat

// var teste = () =>
// {
//   var teste = () =>
//   {
//     var teste = () =>
//     {
//       var teste = () =>
//       {
//         return "teste4";
//       };
//       Console.WriteLine(teste.Invoke());
//       return "teste3";
//     };
//     Console.WriteLine(teste.Invoke());
//     return "teste2";
//   };
//   Console.WriteLine(teste.Invoke());
//   return "teste";
// };

// Console.WriteLine(teste.Invoke());