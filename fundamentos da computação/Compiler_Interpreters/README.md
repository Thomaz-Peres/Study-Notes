compilers: convert code in a language A to the computer language (translate a source program into machine language)

interpretadores: translator processes and executes the source program without translating it into machine language first

In a image representation: ![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/aee1ae2c-bce7-4270-87bf-8d19a389e74f)

## Interpretadores x Compiladores

- Interpretadores
    - Executa um programa-fonte de imediato
    - Menores que os compiladores
    - Mais adaptáveis a ambientes computacionais diversos
    - Tempo de execução maior
        - Intruções de um loop são analisadas e executadas N vezes!
    - Javascript, python, pearl, shell, bash, PHP, go

- Compiladores
    - Gera um código-objeto que seja executado após o término da tradução
    - Compila-se uma unica vez, executando-se quantas vezes se queira
        (cada vez que o codigo fonte é alterado, é necessário refazer o processo de compilação)
        - Em termo de compilação leva um tempo maior, por que é necessário
            submeter o programa para esse processo de compilação, porém conseguimos
            identificar erros mais previamente, seja sintatico ou semantico.
    - Tempo de execucao menor
    - C, pascal

- Linguagens híbridas:
    - Java: Compilada para um código intermediario/virtual (bytecodes), que, por sua vez, é interpretado (virtual machine)


## Gramáticas

Hierarquia de Chomsky:
    - Classificação de gramáticas formais descritas e 1959 pelo linguista Noam Chomsky;
    - Possui 4 niveis;
    - Começa pelo tipo 0 com maior nivel de liberdade em suas regras e aumentam as restrições até o tipo 3;
    - Niveis 2 e 3 são utilizados na descrição de linguagem de programação e na implementação de interpretadores e compiladores.
    - Nivel 2
        - Análise sintática
    - Nivel 3
        - Analise lexica