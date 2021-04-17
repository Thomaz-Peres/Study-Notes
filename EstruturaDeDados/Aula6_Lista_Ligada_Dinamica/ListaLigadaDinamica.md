# Lista ligada dinamica

Para cada elemento novo criado, é alocado memoria para esse elemento, e quando excluido, essa memoria é liberada

## Ideia geral da estrutura

Ele tem um ponteiro para o primeiro elemento, cada elemento indica seu sucessor

![image](https://user-images.githubusercontent.com/58439854/115081511-c5970500-9eda-11eb-9be3-6648e039c4a3.png)

### Como excluiremos o numero 8 ?

A gente so adapta o ponteiro, e tira da memoria onde o numero 8 era guardado

![image](https://user-images.githubusercontent.com/58439854/115081549-d6477b00-9eda-11eb-8bd3-333f0cf98d12.png)


### Como inserimos o numero 1 ?

A gente insere o numero 1 normalmente, falamos o endereço dela para o inicio, e o numero 1 aponta para quem era o primeiro elemento anteriormente
