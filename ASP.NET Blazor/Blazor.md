# Blazor

- [O que é o **Blazor**](#Blazor)
- [Blazor Web Assembly]()
- [Blazor Server]()
- [Iniciando um projeto e principais comandos e o que significam](#Project)
- [Quais arquivos foram criados para que servem e o que fazem](#Files)
- [Componentes](#Components)
- [Interoperabilidade do JavaScript](#JavaScript)
- [Compartilhamento de código e o .NET Standard.](#CompartilhamentodeCodigo)

## <a name="Blazor"></a> Blazor é uma estrutura para a criação de interface do usuário da Web interativa do lado do cliente com o .NET:

- Crie interfaces do usuário interativas avançadas usando C# em vez de JavaScript
- Compartilhe a lógica de aplicativo do lado do cliente e do servidor gravada no .NET.
- Renderize a interface do usuário, como HTML e CSS para suporte amplo de navegadores, incluindo navegadores móveis.
- Integre-se com plataformas de hospedagem modernas, como o Docker.
- Usar o .NET para desenvolvimento web do lado do cliente oferece as seguintes vantagens:
- Escreva o código em C# em vez de JavaScript.
- Aproveite o ecossistema .NET existente das bibliotecas .NET.
- Compartilhe a lógica de aplicativo entre o servidor e o cliente.
- Beneficie-se com o desempenho, confiabilidade e segurança do .NET.
- Mantenha-se produtivo com o Visual Studio no Windows, Linux e macOS.
- Crie um conjunto comum de linguagens, estruturas e ferramentas que são estáveis, com recursos avançados e fáceis de usar.

## <a name="Project"></a> Iniciando um projeto e principais comandos e o que significam.

- O comando **dotnet new blazorserver** cria um novo *Blazor Server app* para você.
- O paarametro *-o* cria um diretorio chamado BlazorApp onde o app armazena e coloca os arquivos necessarios.
- O sinalizador **--no-https** especifica que o *HTTPS* não sera habilitado.
- O comando **cd BlazorApp** muda seu diretório para o que você acabou de criar.

## <a name="Files"></a> Quais arquivos foram criados para que servem e o que fazem.

Vários arquivos foram criados no diretório *BlazorApp*, para fornecer um aplicativo Blazor simples que está pronto para ser executado.

- **Program.cs** é o ponto de entrada para o aplicativo que inicia o servidor.
- **Startup.cs** é onde você configura os serviços de aplicativo e middleware.
- **App.razor** é o componente raiz do aplicativo.
- O diretório **BlazorApp/Pages** contém alguns exemplos de páginas da web para o aplicativo
- **BlazorApp.csproj** define o projeto do aplicativo e suas dependências.

## <a name="Components"></a> Componentes.

Aplicativos Blazors são baseados em *componentes*. Um componente no Blazor é um elemento da interface do usuário, como um formulário de página, caixa de diálogo ou entrada de dados.

### os componentes do Blazor também são formalmente chamados de Razor Componentes.

1. Os componentes são classes do .NET incorporadas em Assembly .NET que:

- Definem a lógica de renderização da interface de usuário flexível.
- Tratam eventos do usuário.
- Podem ser aninhados e reutilizados.
- Pode ser compartilhado e distribuído como classes de bibliotecas Razor ou pacotes NuGet.

form of a Razor markup page with a .razor file extension

A classe de componente geralmente é escrita na forma de uma página de marcação Razor com uma extensão de arquivo *.razor*. Os componentes no Blazor são formalmente chamados de *Razor componentes*. 

Razor é uma sintaxe para combinar marcação HTML com código C# projetado para a produtividade do desenvolvedor. Razor permite que você alterne entre marcação HTML e C# no mesmo arquivo com suporte **IntelliSense**. As páginas Razor e MVC também usam o Razor.

Ao contrário de páginas Razor e MVC, que são criadas em um modelo de solicitação/resposta, os componentes são usados especificamente para a lógica e a composição da interface do usuário(UI) do lado do cliente.

#### A marcação Razor a seguir demonstra um componente (Dialog.razor), que pode ser aninhado dentro de outro componente:

```razor
<div>
    <h1>@Title</h1>

    @ChildContent

    <button @onclick="OnYes">Yes!</button>
</div>

@code {
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private void OnYes()
    {
        Console.WriteLine("Write to the console in C#! 'Yes' button was selected.");
    }
}
```

O conteúdo do corpo da caixa de diálogo (ChildContent) e o título (Title) são fornecidos pelo componente que usa esse componente em sua interface do usuário. OnYes é um método C# disparado pelo evento onclick do botão.

Blazor usa marcas HTML naturais para composição da interface do usuário. Os elementos HTML especificam componentes e os atributos da marcação transmitem valores para as propriedades de um componente.

### No exemplo a seguir, o componente Index usa o componente Dialog. ChildContent e Title são definidos pelos atributos e pelo conteúdo do elemento <Dialog>. **Pages/Index.razor:**

```razor
@page "/"

<h1>Hello, world!</h1>

Welcome to your new app.

<Dialog Title="Blazor">
    Do you want to <i>learn more</i> about Blazor?
</Dialog>
```

A caixa de diálogo é renderizada quando o pai **(Pages/Index.razor )** é acessado em um navegador:
Componente da caixa de diálogo renderizada no navegador

Quando esse componente é usado no aplicativo, o IntelliSense no Visual Studio e no Visual Studio Code acelera o desenvolvimento com o preenchimento de sintaxe e de parâmetro.
Os componentes são renderizados em uma representação na memória do Modelo de Objeto do Documento (DOM) do navegador chamada árvore de renderização, que é usada para atualizar a interface do usuário de maneira flexível e eficiente.

## <a name="JavaScript"></a> Interoperabilidade do JavaScript.

Para aplicativos que exigem bibliotecas JavaScript e acesso a APIs do navegador de terceiros, os componentes interoperam com o JavaScript. Os componentes são capazes de usar qualquer biblioteca ou API que o JavaScript possa usar. O código C# pode chamar o código JavaScript, e o código JavaScript pode chamar o código C#. Para obter mais informações, consulte os seguintes artigos:

- [Chamar funções JavaScript de métodos .NET no ASP.NET Core Blazor](https://docs.microsoft.com/pt-br/aspnet/core/blazor/call-javascript-from-dotnet?view=aspnetcore-3.1)
- [Chamar métodos .NET de funções JavaScript no ASP.NET Core Blazor](https://docs.microsoft.com/pt-br/aspnet/core/blazor/call-dotnet-from-javascript?view=aspnetcore-3.1)

## <a name="CompartilhamentodeCodigo"></a> Compartilhamento de código e o .NET Standard.

Blazor implementa .NET Standard 2,1, que permite que os Blazor projetos referenciem bibliotecas que estão em conformidade com as especificações .net Standard 2,1 ou anteriores. O .NET Standard é uma especificação formal das APIs do .NET que são comuns entre as implementações do .NET.

As bibliotecas de classe do .NET Standard podem ser compartilhadas entre diferentes plataformas .NET: **como Blazor, .NET Framework, .NET Core, Xamarin, mono e Unity**.

As APIs que não são aplicáveis em um navegador da Web (por exemplo, para acessar o sistema de arquivos, abrir um soquete e threading) geram a [PlatformNotSupportedException](https://docs.microsoft.com/pt-br/dotnet/api/system.platformnotsupportedexception?view=netcore-3.1).