# Patterns utilizados ou que podem ser utilizados no RabbitMQ

## Pipeline

- Utilizar diversar filas para processar partes de uma macro-tarefa, de forma linear.

- É feita por varias etapas.
    - Primeira etapa, extração de metadados
    - Segunda é downlaod

O legal do modelo, é que permite escalar individualmente o processamento de uma fila.

## Anonymous Queue (filas anonimas)

Permite criar uma fila anonima na medidca que esta criando uma fila e nao da um nome, exemplo:

O rabbit vai gerar uma fila com um nome aleatorio, parecido com o geo id, com isso voce pode associar uma fila a um exchange qualquer, e permite que um certo worker tenha uma fila exclusiva

![image](https://user-images.githubusercontent.com/58439854/97094980-67c2e800-1630-11eb-8d39-652fd66fb49a.png)

## RPC

O "cliente" cria uma fila anonima e o nome é armazenado em memoria
para quando ele for enviar a mensagem, ela ser colocada no correlation, o ID e o nome da fila de resposta.

a mensagem chega na fila original de processamento quando o client que ta processando identifica que a mensagem tem a informação a mais, que é o ID de resposta. Voce programa algo que faz o envio para outra fila.

## Shared Queue (filas compartilhadas)

É quando tem mais de um client consumindo uma mesma fila.