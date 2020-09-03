# Rotas

- As rotas são importantes
- Podemos mesclar/utilizar as rotas com verbos(podemor ter rotas iguais, porém com verbos diferentes)**EXEMPLO:**
    - Pode ter um rota *Products*, e pode ter uma mesma rota *Products* para cadastrar um produto, alterar um produto, excluir.
- Podemos receber parâmetros pela URL ou Corpo da requisição.

# Roteamento

Veja abaixo, todos com uma mesma **rota**, é possivel fazer tudo abaixo.

- *GET* = http://localhost:5000/v1/products
    - Lista os produtos
- *POST* = http://localhost:5000/v1/products
    - Cria um produto
- *PUT* = http://localhost:5000/v1/products
    - Atualiza um produto
- *DELETE* = http://localhost:5000/v1/products
    - Exclui um produto

## Diferenças de rotas *Get*

- *Get* = http://localhost:5000/v1/products
    - Listando os produtos
- *Get* = http://localhost:5000/v1/products/255
    - Lista o produto 255
- *Get* = http://localhost:5000/v1/products/255/images
    - Lista as imagens do produto 255

# Verbos (principais)

- *GET* = o **GET** le a categoria
- *POST* = o **POST** cria a categoria
- *PUT* = o **PUT** atualiza a categoria
- *DELETE* =  o **DELETE** deleta a categoria























Abaixo minha rota seria como https://localhost:5001/products


```Csharp
[Route("products")]
public class ProductController : ControllerBase
{
    quando eu coloco que a *rota* é vazia, ele sera como a mesma, porem como get, ou post, delete etc
    [HttpGet]
    [Route("")]
    public string Get()
    {

    }

    abaixo quando eu coloco que a *rota* é ([Route("{genero:string}")]) eu estou dizendo que a rota **genero** so aceitará quando for uma string(restringe outros tipos, como *INT*, *CHAR*), e a rota ficaria **https://localhost:5001/products/(genero que vc pesquisou)**

    [HttpGet]
    [Route("{genero:string}")]
    public string GetByGenero(string genero)
    {
}
```