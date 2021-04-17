#  A lista ligada é utilizada para evitar o deslocamento dos elementos durante a inserção e exclusão.

- Ela é uma estrutura linear (cada elemento so pode ter no maximo 1 predecessor  e um sucessor)
- A ordem logica dos elementos (a ordem "vista" pelos usuarios) é diferente da ordem física (a em memoria) dos elementos.
- Também utilizado com arranjos, cada elementos precisa indicar a posição dentro do arranjo, do seu sucessor

## **Alguns cuidados para se tomar com a lista ligada**

- Precisamos saber onde está o primeiro elemento;
- Precisamos saber os elementos disponiveis na lista, e onde eles estão

### No exemplo abaixo, a lista tem os campos que são mostrados ao usuario (5 - 9 - 8 - 7), ele possui também o indice do proximo elemento (segunda linha)

5|9|8|7 
-|-|-|-
3|-1|1|2

- Como funciona acima, o numero *3* indica que o proximo elemento da lista, em ordem de chaves, é o *7*, ja que se encontra na chave *3*, e o proximo depois do *7* é a chave *2*, no caso o numero *8*, e depois o *9* que encerra com *-1*, informando que não possui mais chaves dentro do arranjo


## Como funciona a exclusão de um item na lista ligada

Para excluirmos um elemento da lista, o *7* precisa falar que o sucessor dele é o *9*.

5|9||7 
-|-|-|-
3|-1||1

## Como funciona a inserção de um item na lista ligada

É pego uma posição disponivel no arranjo qualque, e o numero apontar para o proximo elemento

5|9|1|7 
-|-|-|-
3|-1|0|1