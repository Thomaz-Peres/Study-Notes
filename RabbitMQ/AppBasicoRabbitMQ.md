# Fazendo um app basico para introdução do RabbitMQ

### **Conceitos**
**Mensagem:**

Uma mensagem é dividida em duas partes:

- Payload – é o corpo com os dados que serão transmitidos. Suporta vários tipos de dados como um array json até um filme mpeg.
- abel – é responsável pela descrição do payload e também como o RabbitMQ saberá quem irá receber a mensagem.

- Fila: onde as mensagens ficam e são retiradas pelos consumers.
- Publisher: é o responsavel por incluir cada nova mensagem na fila, ou seja enviar a mensagem.
- Consumer: Como diz o proprio nome é o agente responsavel por consumir, retirar a informação da fila.



## Antes de tudo, instale o [RabbitMQ](https://www.rabbitmq.com/download.html) e o [Erlang](https://www.erlang.org/downloads)

## É necessario adicionar o pacote nuget RabbitMQ.
.

.

.

## Criando o publisher

1. Criar um console application para o publisher

2. Montando uma conexão.

```Csharp
var factory =  new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {

    }
}
//Aqui nos conectamos a uma máquina local, daí o localhost. Se quisermos nos conectar uma máquina diferente, simplesmente especificaremos seu nome ou endereço IP.
```

3. Agora iremos declarar a fila e criar a mensagem.

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
        
        string message = Console.ReadLine();
        var body = Encoding.UTF8.GetBytes(message);
    }
}
// A fila só será criada se já não existir. O conteúdo da mensagem é uma matriz de bytes, para que você possa codificar o que quiser.
```

4. Iremos adicionar o metodo para publicas a mensagem.

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
        
        string message = Console.ReadLine();
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                            routingKey: "Nome_Da_Queue",
                            basicProperties: null,
                            body: body);
                            Console.WriteLine("Mensagem Enviada");
    }
    Console.ReadLine();
}
// E está pronto nosso publisher: ele irá enviar para a fila CedroBlog a mensagem que está no body.
```

## Criando o consumer

1. Para o consumer, iremos criar outro console application, criar a conexão e declarar fila da mesma maneira que no publisher:

```Csharp
var factory =  new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {

    }
}
```

2. Agora adicionamos a parte do consumidor, que irá pegar as mensagens da fila:

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
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.body;
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
        };
        channel.BasicConsume(queue: "Nome_Da_Queue",
                            autoAck: true,
                            consumer: consumer);

        Console.WriteLine("Consumer funcionando");
        Console.ReadLine();
    }
}
// Usamos um console ReadLine, para manter a aplicação rodando. Nosso consumer vai estar pegando toda mensagem que chega na fila CedroBlog e nos mostrando o que ela contém.
```

### Para ver os resultado,s execute primeiramente o consumer e logo em seguida o publisher. O resultado deverá ser o seguinte:

![](https://blog.cedrotech.com/wp-content/uploads/2018/02/rabbit9.jpg)