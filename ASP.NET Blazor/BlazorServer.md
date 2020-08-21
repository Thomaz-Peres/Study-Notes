# Blazor Server

[O que é o **Blazor server**](#BlazorServer)


## <a name="BlazorServer"></a> O que é o Blazor Server

Blazor dissocia a lógica de renderização do componente de como as atualizações da interface do usuario são aplicadas. Blazor Server fornece suporte para hospedar componentes Razor no servidor em um aplicativo ASP.NET Core. As atualizações da interface do usuário são manipuladas em uma conexão [**SignalR**](https://docs.microsoft.com/pt-br/aspnet/core/signalr/introduction?view=aspnetcore-3.1).

O runtime realiza o envio de eventos da interface do usuário do navegador para o servidor executar os componentes, aplica as atualizações na interface do usuário retornadas pelo servidor ao navegador

A conexão usada pelo **Blazor Server** para se comunicar com o navegador também é usada para lidar com as chamadas de interoperabilidade do JavaScript.

![](https://docs.microsoft.com/pt-br/aspnet/core/blazor/index/_static/blazor-server.png?vie)