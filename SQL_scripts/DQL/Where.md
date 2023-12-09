# Where

Where é utilizado para filtragem de consulta, nos especificamos registros que serão mostrados ou não pelo *select*.
É possivel utilizar varios filtros.

Exemplo de uma utilização simples de *where*:

```SQL
select * from cliente where Nome = 'Thomaz';
select * from cliente where ClientID < 10;
```

Tambem posso utilizar alguns operadores, segue exemplo:

```SQL
select * from cliente where Nome = 'Thomaz' Or Nome = 'Dale';

-- Abaixo estou procurando os clientes que possuem o tipo de cliente 1 e o mês de nascimento é maior que maio

select * from cliente where TipoCliente = 1 And month(nascimento) > 5;
```