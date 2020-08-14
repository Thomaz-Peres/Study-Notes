# trabalhando com rotas

Abaixo minha rota seria como https://localhost:5001/products

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