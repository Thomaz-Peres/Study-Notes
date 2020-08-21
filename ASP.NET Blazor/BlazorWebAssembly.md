# Blazor Web Assembly

Blazor WebAssembly é uma estrutura de aplicativo de página única para criar aplicativos Web do lado do cliente interativos com o .NET.

Blazor WebAssembly usa padrões abertos da Web sem plug-ins ou [transpilação](https://pt.stackoverflow.com/questions/189894/o-que-é-transpilação) de código e funciona em todos os navegadores da Web modernos, incluindo navegadores móveis.

A execução de código .NET dentro de navegadores da Web é possibilitada pelo *WebAssembly* (abreviado WASM ). O *WebAssembly* é um formato de código de bytes compacto, otimizado para download rápido e máxima velocidade de execução. O *WebAssembly* é um padrão aberto da Web compatível com navegadores da Web sem plug-ins.

O código WebAssembly pode acessar a funcionalidade completa do navegador por meio de JavaScript, chamado Interoperabilidade do JavaScript (ou JavaScript Interop).

![](https://docs.microsoft.com/pt-br/aspnet/core/blazor/index/_static/blazor-webassembly.png?view=aspnetcore-3.1)

O código .NET executado por meio da WebAssembly no navegador é executado na área restrita do JavaScript do navegador com as proteções que a área restrita oferece contra ações mal intencionadas no computador do cliente.

## Quando um aplicativo Blazor WebAssembly é compilado e executado em um navegador:

- Arquivos de código C# e Razor arquivos são compilados em Assembly .NET. 
- Os *Assemblyes* e o runtime do .NET são baixados no navegador.

- O Blazor WebAssembly inicializa o tempo de execução do .NET e configura o tempo de execução para carregar os *Assemblyes* do aplicativo. O tempo de execução do Blazor WebAssembly usa interoperabilidade JavaScript para lidar com a manipulação de DOM e chamadas de API do navegador.

### O tamanho do aplicativo publicado, seu tamanho de payload, é um fator de desempenho crítico para a utilidade do aplicativo. Um aplicativo grande leva um tempo relativamente longo para baixar para um navegador, o que afeta a experiência do usuário. Blazor WebAssembly otimiza o tamanho da carga para reduzir os tempos de download:

- [O código não utilizado é retirado do aplicativo quando publicado pelo Vinculador de linguagem intermediária (IL)](https://docs.microsoft.com/pt-br/aspnet/core/blazor/host-and-deploy/configure-linker?view=aspnetcore-3.1)
- As respostas HTTP são compactadas.
- O runtime do .NET e os *Assemblyes* são armazenados em cache no navegador.