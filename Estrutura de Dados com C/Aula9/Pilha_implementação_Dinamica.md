# Pilha implementação Dinamica

Na dinamica, é alocado e desalocado sobre demanda a memoria para os elementos

- Vantagem: nao precisa desperdiçar memoria preparando de ante mão um arranjo.

Porém é necessario arrumar uma forma de indicar como um elemento de relaciona a outro

## Ideia
![image](https://user-images.githubusercontent.com/58439854/117069175-923dde00-ad02-11eb-9b92-64608f45db9c.png)

Como fariamos para adicionar um elemento ? 

    - R:Por ser uma pilha, adicionara sempre no topo, então o numero adicionado aponta para o antigo topo, no caso o 5(2010 na memoria), e o topo aponta para a memoria do novo numero

Como fariamos para excluir um elemento ? 

    - R:Por ser uma pilha, excluira sempre o topo da lista, então o topo aponta para o proximo do antigo topo, e limpa o antigo da memoria

