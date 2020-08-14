# Get post put delete

*GET* = o **GET** le a categoria
*POST* = o **POST** cria a categoria
*PUT* = o **PUT** atualiza a categoria
*DELETE* =  o **DELETE** deleta a categoria

## Gerando o JSON para o POST dentro do codigo

- mapeando o que veio da tela para a entrada da aplicação e ja fazer um filto.

- no codigo abaixo, eu coloco que quero receber o ~~MODELS~~ do Produto, e o nome da variavel, que é model

- ele é um *public Product Post*, por que ele retorna um Product, ou seja, eu recebo o produto no *(Product model)*, e retorno um *public Product Post*.

- o [FromBody], que quer dizer que vai vir/receber um produto do CORPO da requisição.

[HttpPost]
[Route("")]
public Product Post([FromBody]Product model)
{
   return model;
}