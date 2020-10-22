# Entendendo alguns *comandos* bastantes utilizados no basico do RabbitMQ

```Csharp
var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "task_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Mensagem recebida: {message} ");

                        //  simulando tempo de execução
                        int dots = message.Split(' ').Length - 1;
                        Thread.Sleep(dots * 1000);
                        //  simulando tempo de execução

                        Console.WriteLine("Pronto");
                    };
                    channel.BasicConsume(queue: "task_queue",
                    autoAck: true,
                    consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
```

- **queue** = nome da fila a ser criada.

- **durable** = A fila sobreviverá a uma reinicialização do corretor.

- **exclusive** = usado por apenas uma conexão, a fila sera excluida quando a conexão for fechada.

- **autoDelete** = a fila que teve pelo menos um consumidor é excluída quando o último consumidor cancela a inscrição.

- **arguments** = opcional; usado por plug-ins e recursos específicos do corretor, como TTL de mensagem, limite de comprimento da fila, etc.

- **autoAck** = modo de reconhecimento automatico