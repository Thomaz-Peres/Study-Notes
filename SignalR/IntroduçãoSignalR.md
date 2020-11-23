# Introdução ao Asp.Net Core SignalR

## o que é *SignalR*

É uma biblioteca de software livre que simplifica a adição de funcionalidades da Web em tempo real a aplicativos. A funcionalidade da web em tempo real permite que o codigo do lado do servidor envie conteúdo aos clientes instantaneamente.

### Bons candidatos para o uso de SignalR

- Aplicativos que exigem atualizações frequentes do servidor. Por exemplo, jogos, redes sociais, votação, leilão, mapas e aplicativos de GPS.

- Painéis e aplicativos de monitoramento. Por exemplo, painéis de empresa, atualizações de vendas instantâneas ou alertas de viagem.

- Aplicativos de colaboração. Aplicativos de quadro de comunicação e software de reunião de equipe são exemplos de aplicativos de colaboração.

- Aplicativos que exigem notificações. Redes sociais, email, chat, jogos, alertas de viagem e muitos outros aplicativos usam notificações.

O *SignalR* fornece uma API para criar RPCs de servidor para cliente. As RPCs chamam funções JavaScript em clientes do código .NET Core do lado do servidor.

## Transportes

SignalR dá suporte às seguintes técnicas para lidar com a comunicação em tempo real (em ordem de fallback normal):

- WebSockets
- Eventos de Server-Sent
- Sondagem longa

## HUBS

SignalR usa *HUBS* para se comunicar entre clientes e servidores.

Um hub é um pipeline de alto nivel que permite que um cliente e um servidor chamem métodos entre si. SignalR manipula a expedição entre limites de máquina automaticamente, permitindo que os clientes chamem métodos no servidor e vice-versa. Você pode passar parâmetros fortemente tipados para métodos, o que habilita a associação de modelo.

SignalR fornece dois protocolos de HUB internos: 

- Um protocolo de texto baseado em JSON
- Um protocolo binário com base em MessagePack.