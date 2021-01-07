# VOU ORGANIZAR TUDO CARAIIIIIIII  // brinks, mas vou organizar.

## data notation são anotações colocadas acima da classe

### é possivel criar DATA NOTATIONS customizados
### além dele projetar na forma correta no banco de dados, ele aplica as validações. 


```Csharp
# Rotas = [Route]
- com as rotas voce diz, o que vai aparecer na URL, por exemplo, 
[Route("Banana")]
- no https://localhost:5001/banana
## se utilizar a Route vazia ex ([Route("")]), ela continua a mesma
## exemplo abaixo

[Route("categories")]
public class CategoryController : ControllerBase
{
    https://localhost:5001/categories
    [Route("")]
    public string MeuMetodo()
    {
        return "Olá mundo!";
    }
}
```

## Os padroes de API Rest tem sempre a mesma rota, so muda o verbo e q é utilizada como CRUD (Create, Read, Update, Delete)

## passando parametros para as rotas
- sempre que tiver algo entre CHAVES {}, em qualquer nome de rota, ele vai encarar como parametro

## passando o parametros para os metodos
- basta colocar o parametro como parametro Do Metodo

## restringindo as rotas
- Coloque : depois do nome do id, ex = [Route("{id:int}")]

# POST

## toda vez que é feito um POST, ele cai na rota e a requisição vem em duas partes, cabeçalho e o corpo da requisição


# PUT

## para o metodo PUT, é mesclado os dois jeitos, do GET  e do POST, ex
- GET
[Route("{id:int}")]
public string GetById(int id)
{
    return "Get" + id.ToString();
}

- POST
public Category Post([FromBody]Category model)
{
    return model;
}

- Mesclando os dois ficaria 
[Route("{id:int}")]
public Category Post([FromBody]Category model)
{
    return model;
}

### no PUT é muito comum a URL o ID do item que quer alterar, seguindo o pedido do corpo da requisição