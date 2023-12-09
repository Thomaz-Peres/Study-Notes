# Tipos de dados mais comuns que podem ser utilizados nas tabelas

No tutorial que eu vi, ele separou em 3 tipos de dados.

Dados de texto, dados numericos, e dados temporais


## Dados de texto

Tipo de Texto | Máximo de bytes
------------- | -------------
TinyText | 255
Text | 65.535
MediumText | 16.777.215
LongText | 4.294.967.295
char (caracteres) | 255
varchar (caracteres) | 65.535

A diferença do tipo **char** e **varchar**

- Char = tem um tamanho fixo, se eu passar um char com tamanho 5 *(char(5))*, independente do tamanho que eu especificar, ele tera um tamanho de 255.
- Varchar = o *varchar* tem um tamanho variavel, ou seja, se eu especificar que ele tem um tamanho de 15 *(varchar(15))*, ele tera um tamanho de 15, ou do eu especificar.

## Dados numericos
![image](https://user-images.githubusercontent.com/58439854/107786498-c1106d80-6d2c-11eb-900b-0485b5cfddb6.png)

## Dados temporais
![image](https://user-images.githubusercontent.com/58439854/107787717-3cbeea00-6d2e-11eb-9128-177cbfe4dce3.png)