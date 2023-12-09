# Update

O update é utilizado para modificar/alterar o registro de uma tabela (exemplo: alterar o nome do cliente)

## Obs = ao utilizar *update* é bom lembrar de usar o **WHERE**, para referir onde e o que você quer modificar, se não utiliza-lo, estara modificando TODOS OS DADOS

Exemplos:

```SQL
-- Abaixo estou alterando o nome do cliente com o ID 1, para "Thomaz 2"
update cliente set Nome = 'Thomaz 2' where ClientID=1;

-- Posso alterara também mais de uma informação
-- Abaixo estou alterando o nome e o cpf, e vou alterar apenas o client com o ID 1
update cliente set Nome = 'Alice', Cpf='12345678911' where ClientID=1;
```

Caso eu nao utilize o **where** nos exemplos acima, estaria alterando TODOS os clientes, abaixo vou mostrar exemplos caso eu queira alterar todos os clientes, utilizando o where

```SQL
update cliente set TipoCliente=1 where ClientID>0;
```