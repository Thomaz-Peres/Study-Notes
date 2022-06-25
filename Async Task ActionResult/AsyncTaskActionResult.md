# Task junto do async, é uma programação paralela, no C# utiliza-se da seguinte forma
``` CSharp
public async Task<ActionResult> Get()
{}
```

- **ActionResult**
    - Tras um resultado no formato que a tela espera(resumidamente,é um estilo de tratamento de erros (202, 404, 403, 400, 500))
    - Action result pode ser tipado, entao é possivl colocar duas Categorias nele.

- Async = metodo assincrono.

#### o (async e await), cria telas paralelas na aplicação. assim a aplicação nao fica travando a execução principal.