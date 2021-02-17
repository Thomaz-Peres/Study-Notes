# Delete

O delete é usado para deletar registros de tabela

## Obs = ao utilizar *dalete* é bom lembrar de usar o **WHERE**, para referir onde e o que você quer deletar, se não utiliza-lo, estara deletando TODOS OS DADOS

Exemplo de utilização do *delete*

```SQL
delete from cliente where ClientID = 2;

-- Tambem é possivel utilizar igual no update, utilizando o where para excluir tudo
delete from cliente where ClientID>0;
```