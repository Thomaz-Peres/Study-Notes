# Começando a trabalhar no projeto do SignalR

Criamos uma pasta **HUBS** ja que são o "coração" da aplicação, nele teremos um método *SendMessage* que tem o objetivo de realizar o envio da rotação em tempo real para as conexões ativas.

![image](https://user-images.githubusercontent.com/58439854/103913109-f222d000-50e6-11eb-82a7-4f3f4262bbb9.png)

![image](https://user-images.githubusercontent.com/58439854/103913136-fea72880-50e6-11eb-9db0-274153fbd702.png)

No método acima recebemos alguns parametros, e dentro do método enviamos para todos clientes de forma Assincrona as informações que recebemos nos parametros.