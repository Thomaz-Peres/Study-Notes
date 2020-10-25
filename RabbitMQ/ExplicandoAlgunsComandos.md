# Entendendo alguns *comandos* bastantes utilizados no basico do RabbitMQ

- **queue** = nome da fila a ser criada.

- **durable** = A fila sobreviverá a uma reinicialização do corretor.

- **exclusive** = usado por apenas uma conexão, a fila sera excluida quando a conexão for fechada, ou quando nao tiver conexao.

- **autoDelete** = morre quando não tem mais mensagens/a fila que teve pelo menos um consumidor é excluída quando o último consumidor cancela a inscrição.

- **arguments** = opcional; usado por plug-ins e recursos específicos do corretor, como TTL de mensagem, limite de comprimento da fila, etc.

- **autoAck** = modo de reconhecimento automatico


## Exchange Types

o papel do Exchange é a distribuição entre as filas, existem diversos tipos de exchanges e padroes. 

**Exchange Direct** = a mensagem é roteada para a fila com mesmo nome usado na Routing Key