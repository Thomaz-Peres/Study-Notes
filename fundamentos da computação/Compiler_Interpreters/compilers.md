# Compilers

### General struct of a compiler

Compilador pode ser fracionado/decomposto em 6 grandes etapas:

    - Codigo fonte
    - Analisador Léxico
    - Analisador Sintático
    - Analisador Semântico
    - Gerador de código intermediário
    - Otimizador de código
    - Gerador de código

### Estruturas da Compilação

Como diferenciar palavras e símbolos reservados de identificadores definidos pelo usuário.
- Tabela de palavras e simbolos reservados
- ![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/54af3b76-184a-4cd3-8350-1f8afce20a36)

Como saber durante a compilação de um programa o `tipo` e o `valor dos identificadores, escopos das variaveis, número` e `tipo dos parâmetros` de um procedimento, etc:
- Tabela de simbolos
- ![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/a1b2f89f-83d5-4e78-9054-e7bedd3794f5)

________________________________________________


![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/e0de582a-72e0-4fd1-8aea-5f811ad81386)

________________________________________________

### Fases da compilação.

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/153e6395-0695-4d70-a762-daad6ed54a90)

- Sintática:
    - Faltou `;`
    - nao fechei o `()`

- Semanticos e contextuais:
    - Tipos incompativeis
    - Acumular em um valor não inicializado
    - Atribuir tipos diferentes
    - Usar uma variavel nao declarada

- Geração de código
    - Especificos da arquitetura que pretende utilizar
    - Depende do alvo

### Análise Léxica

Reconhecimento de classificação dos tokens:

A ideia é que o analisador lexico possa quebrar a linha inteira em tokens/termos.

Apenas quebramos e identificamos cada um dos componentes. Não sabemos tipo, não sabemos se a variavel ja foi declarada.

Na imagem abaixo:

- `x`: Identificador de variavel
- `:=`: simbolo de atribuição
- `x`: outro indentificador, ele não sabe se é o mesmo `x` utilizado anteriormente ou não
- `+`: operador aritmetico
- `y`: outro identificador
- `*`: outro operador aritmetico
- `2`: um número

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/c841c583-f9ba-4d9e-8c91-741b4fbc8d8c)

________________________________________________

### Análise Sintática

Verificação da formação do programa:

Depois da análise Léxica, fazemos a verificação para sabermos se `x := x + y * 2` forma efetivamente um comando.

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/f1428d1d-38b4-4677-a514-0f3b068d86da)

________________________________________________

### Análise Sintática

Verificação do uso adequado:

Exemplo:
- A variavel `x` foi previamente declarada/existe na tabela de simbolos ?
- a variavel `y` foi previamente declarada/existe na tabela de simbolos ?

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/0c5107b2-b704-4b80-b228-df19b2831008)

________________________________________________

### Geração de código intermediário (p-code)

Geração de código intermediário/preliminar.

Decompomos a expressão para uma linguagem de montagem. É uma parte mais dificil pois envolve entender as expressões e começar a decompolas

Exemplo `x := x + y * 2`:

- Passo 1: `temp1 := y * 2`
- Passo 2: `temp2 := x + temp1`
- Passo 3: `x := temp2`

________________________________________________

### Otimização do código

Otimização do código intemediário:

Por exemplo, no passo anterior, quebramos a expressão `x := x + y * 2` em 3 partes, podemos otimizar dessa maneira:

`OBS: Reduzir ciclos em compilers "sempre" tende a ser melhor` 

- Passo 1: `temp1 := y * 2`
- Passo 2: `x := x + temp1`

________________________________________________

### Geração de código

Geração de código para a máquina-alvo (geramos o assembly):

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/c448ca3d-ed6f-4266-bb37-034966799b6f)

________________________________________________

### Alguns programas relacionas a compiladores

São ferramentas auxiliares

- Interpretadores: Executam instrução por instrução do código-fonte;
- Montadores (assemblers): Traduzem linguagem de `montagem` em linguagem de `máquina`;
- Editores: os compiladores aceitam programas-fonte escritos com qualquer editor que gere um arquivo padrão, por exemplo um arquivo `ASCII`. Utilização de um programa interativo para desenvolvimento (`IDE`);
- Depuradores: utilizado para determinar `erros de execução` em um programa compilado.