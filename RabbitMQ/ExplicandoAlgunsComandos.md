# Entendendo alguns *comandos* bastantes utilizados no basico do RabbitMQ

```Csharp
var factory =  new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "Nome_Da_Queue",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
```

- **queue** = nome da fila a ser criada.

- **durable** = A fila sobreviverá a uma reinicialização do corretor.

- **exclusive** = usado por apenas uma conexão, a fila sera excluida quando a conexão for fechada.

- **autoDelete** = a fila que teve pelo menos um consumidor é excluída quando o último consumidor cancela a inscrição.

- **arguments** = opcional; usado por plug-ins e recursos específicos do corretor, como TTL de mensagem, limite de comprimento da fila, etc.