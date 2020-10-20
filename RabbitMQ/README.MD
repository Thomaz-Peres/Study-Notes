# Aprendendo RabbitMQ [ARTIGO](https://imasters.com.br/back-end/rabbitmq-introducao-ao-mundo-das-filas)

O RabbitMQ utiliza sistema de FILAS, para funcionar (primeira mensagem a entrar, é a primeira a sair).

## O que é RabbitMQ

- o RabbitMQ é um programa de mensageria

1. Caracteristicas do RabbitMQ
    - Utiliza o AMQP (Advanced Message Queuing Protocol), que é um protocolo de comunicação em rede para rotear e distribuir as mensagens de aplicações.
    - Tem suporte em várias clouds, e nas principais aqui no Brasil, como GCP, AWS e Microsoft Azure, entre tantas outras.
    - Conteúdo vasto no [site oficial](https://www.rabbitmq.com) (*em inglês*).

## Composição basica de filas.

Apesar de existirem diversos padrões de filas, você pode escolher qual é o melhor para sua solução, Em todos os tipos de cenários possuímos ao menos os três elementos a seguir: **Producing**, **Queue**, **Consuming**.

## **Producing** - Produtor da mensagem

É a aplicação que produz a mensagem e a insere na fila.

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27144455/0_-p64meEqGDPMSlz0.png)

## **Queue** - A fila

É a caixa postal - a fila - que fica dentro do RabbitMQ e aloca as mensagens enviadas pela sua aplicação. A única limitação para uma fila é a memoria de um servidor ou o limite do seu disco. Uma fila pode ser abastecida e consumida por mais de uma aplicação.


- *Representação de uma fila na documentação do RabbitMQ*

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27144530/0_S3BlrWTqsKWrD1aI.png)

## **Consuming** - O receptor da mensagem

É o destinatário da mensagem. Geralmente é uma aplicação em que a principal função é receber e processar a mensagem alocada na fila.

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27152537/0_UgBYosvhFXGcGUZK.png)

Geralmente, cada um desses elementos estão em um servidor diferente.

- *Explicação basica de uma fila* 

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27152741/1_Hf4e8ZffdzeAng5q4dntyw.png)

## **Os cinco padrões de implementação de filas no RabbitMQ**

Como um bom mensageiro, o nosso coelho(mascote do RabbitMQ) tem diversas formas de implementar sua utilização de acordo com a necessidade da solução.

São elas: **Work Queues, Publish/Subscribe, Routing, Topics, RPC.**

## **Work Queues** - Distribuindo tarefas entre serviços.

Utilizada em processos que vão demorar algum tempo para finalizar a execução. Nesses casos, as tarefas são colocadas em uma fila (que para serem executadas posteriormente, liberando o usuário do sistema para outras tarefas. *Exemplos de uso: Geração de relatórios, processamento de cadastros de mídias (auto índice de I/O*):

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27152812/0_DOyIY8iAbbyZBR1p.png)

## **Publish/Subscribe** - Enviando mensagens para muitos destinatários.

A diferença entre desse padrão e o anterior, é que no anterior trabalhamos apenas com uma queue (fila), e aqui trabalhamos com diversas queues.

Ao disparar a mensagem, o usuário não sabe qual queue ela vai ser enviada. Esse padrão se ramifica para quatro tipos: **direct, topic, headers e fonout.**

Exemplos de uso: **chats, push, notifications, logs.**

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27152903/0_ARsXkr6xG8RNLs_5.png)

## **Routing** - Seleção de qual(is) fila(s) sua mensagem vai perctencer usando uma característica chave.

Nesse padrão, trabalha-se como no anterior, com o bônus de que o *sender* pode classificar as mensagem e direciona-las a uma fila especifica.

Soluções que usam teoria de grafos como base são boas candidatas a esse padrão (olha a matemática aí de novo). Exemplos de uso: **pushs direcionados, paralelismo de tarefas para mesma 'mensagem', logs classificados.**

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27152934/0_SiFdyPRqp_rmBtKm.png)

## **Topics** - Classificação de uma mensagem por uma combinação de chaves

Aqui as coisas ficam interessantes. Nesse momento, o protagonista não são as filas, mas a mensagem, então a mensagem enviada pode sen incluída em mais de uma fila e processada de formas diferentes, simultaneamente.

Isso é possivel através de uma lista de palavras chaves, que classificam nossa mensagem em filas diferentes!
Vejo esse padrão muito ligado a deep learning e IA. Exemplos de uso: **'tageamento', classificação e distribuição de conteúdo e chats.**

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27153013/0_W-BWd1qHb02-PozT.png)

## **RPC(Remote Procedure Call)** - Chamada de procedimento remoto: *comunicação entre apps, services ou APIS usando filas*

Esse padrão é usada para comunicação entre aplicações diferentes. Parece um pouco com o padrão Work queues, mas no caso do RPC, quem enviou a mensagem espera uma resposta de quem recebeu a mensagem. (*lembra um pouco HTTP*).

A diferença é que o usando o RabbitMQ teremos uma camada a mais, que são as filas, para garantir que a nossa mensagem não se perca no meio do caminho.

As mensagem são alocadas nas filas, e lidas pelo server quando ele estiver disponível. Quando usamos HTTP, caso a aplicação no server tenha algum problema de comunicação, o cliente recebe um erro de timeout, por exemplo.

Exemplos de uso: **persistência de aplicação.**

![](https://static.imasters.com.br/wp-content/uploads/2019/05/27153112/0_zdrX1PGhbm1D-TvB.png)