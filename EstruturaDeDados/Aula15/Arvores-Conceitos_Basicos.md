# Conceitos básicos sobre ***Árvores***

Uma árvore é um conjunto de nós consistindo de um nó chamado 'raiz' 

Abaixo do qual estão as subárvores que compõem essa árvore

- Imagem de exemplo abaixo

- ![image](https://user-images.githubusercontent.com/58439854/119182958-ce36aa00-ba49-11eb-8d96-a48ca9d44cce.png)

Os *nós* abaixo de um determinado *nó* são chamados de seus decendentes

- Exemplo como na imagem acima ***(os decendentes do 8 = 2 e 12)*** ***(os decendentes do 15 = todos os demais abaixo dele)***


- A árvore pode ser separada por niveis, sendo o *nó raiz* o nivel 0, assim por diante, como na imagem abaixo:

- ![image](https://user-images.githubusercontent.com/58439854/119186145-0e982700-ba4e-11eb-86f0-c8918a42c294.png)

### Altura

- A altura(h) de um *nó* é o comprimento do caminho ***MAIS LONGO*** entre ele e uma folha (ultimo nivel de uma árvore)

- ***Vale notar que a árvore sempre é percorrida da raiz ate às folhas.***

Segue exemplo na imagem abaixo:

- ![image](https://user-images.githubusercontent.com/58439854/119186436-7cdce980-ba4e-11eb-9e5b-fba34ec4eef6.png)


- O endereço de uma árvore na memoria, será o endereço de seu nó raiz


### Profundidade

A profundidade é de um nó ate a raiz, exemplo abaixo:

![image](https://user-images.githubusercontent.com/58439854/119187835-3d170180-ba50-11eb-94b6-be90bf7e750b.png)


## Árvore Binária

Uma *Árvore Binária* é uma árvore em que abaixo de cada nó, existem no maximo duas subárvores.

### Como representamos computacionalmente uma árvore binaria? 

Com 2 ponteiros: um para a subárvores da esquerda e um para a subárvores da direita.
Além de um campo para a chave e dados