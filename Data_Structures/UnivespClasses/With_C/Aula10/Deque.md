# Deque

É uma estrutura de dados na qual os elementos podem ser inseridos ou excluídos de qualquer uma de suas extremidades (do inicio ou do fim). 

Permitindo termos 2 pontos de inserção e exclusão

## Como funciona a implementação do deque

É feita uma implementação dinamica, com uma lista duplamente ligada (cada elemento conhece o seu antecessor e seu sucessor)

Utilizaremos um nó cabeça

## Representação da estrutura

![image](https://user-images.githubusercontent.com/58439854/118568079-70eee000-b74d-11eb-9128-7f882e86d667.png)

Temos um ponteiro para o nó cabeça

Cada elemento indica seu antecessor e seu sucessor (o último número tem o nó cabeça como sucessor, e o nó cabeça tem o último número como seu antecessor)

### Como excluimos um elemento do inicio?

![image](https://user-images.githubusercontent.com/58439854/118572373-acda7300-b756-11eb-9705-da31e43854fd.png)


### Como inserimos um elemento no fim

dizemos que o ultimo elemento que adicionamos, vai receber o seu antecessor como o ultimo número antes de ser adicionado agora, e o nó cabeça como seu sucessor


### [Modelagem](Deque.c)

Diferente das estruturas dinamicas, cada registro tem um ponteiro nao apenas para o sucessor, mas também para o antecessor

![image](https://user-images.githubusercontent.com/58439854/118573691-6e928300-b759-11eb-9954-e1184136cf8c.png)


## Funções de gerenciamento

São iguais as antigas, a diferença é que na inserção e exclusão dos elementos na estrutura, vao ser duas funções, uma para inserir no inicio, e outra para inserir no final e o mesmo para a exclusão