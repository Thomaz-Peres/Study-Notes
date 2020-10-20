# Aprendendo RabbitMQ

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
- ![](https://static.imasters.com.br/wp-content/uploads/2019/05/27144455/0_-p64meEqGDPMSlz0.png)