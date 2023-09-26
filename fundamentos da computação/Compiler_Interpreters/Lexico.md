## Analisador Léxico

- Primeira etapa de um compilador;

- Função
    - Ler o arquivo com o programa-fonte;
    - identificar os tokens correspondentes;
    - Relatar erros.

- Exemplo de tokens:
    - Identificadores
    - palavras reservadas e simbolos especiais;
    - Numeros

Exemplo:

`x := y * 2;`

cadeia | Token 
------ | ------
x      | id
:=     | simb_atrib
y      | id
`*`    | simb_mult
2      | num
;      | simb_pv


**OBS:** Se esses simbolos formam um comando, já não é mais função do analisador lexico, é uma função do analisador sintatico

______________________

Podemos também criar números para um token:

cadeia      | Token 
------      | ------
id          |  1    
simb_atrib  |  2    
simb_mult   |  3    
num         |  4    
simb_pv     |  5    

Resultando nesta leitura:

cadeia | Token 
------ | ------
x      | 1
:=     | 2
y      | 1
`*`    | 3
2      | 4
;      | 5

______________________

### Exemplo de um programa completo em Pascal

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/cce703c5-eb32-44b8-8e5d-f31b34509100)

______________________

### Definições Léxicas

- Como vou limitar um token ?
- Diferenciação de letra maiúsculas/minúsculas (case sensitive) ?
- Qual o conjunto de palavras reservadas ?
- Qual a regra para a formação de identificadores ?
- etc.

______________________


![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/39e5461b-a871-4cea-95af-62948e5f79e7)