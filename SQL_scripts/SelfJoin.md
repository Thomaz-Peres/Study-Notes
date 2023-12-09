# Self Join

O *Self Join* é quando uma tabela se junta com ela mesmo 🤯, e faz uma correlação entre seus proprios registros

O *Self Join* nao possui um comando especial para ele, basta eu passar as duas mesmas tabelas no from, exemplo:

```SQL
select * from cliente c1, cliente c2;
```

Agora um exemplo de utilizando o self join, para trazer correlações por TipoCliente

```SQL
select * from cliente c1, cliente c2 where c1.TipoCliente = c2.TipoCliente
order by c1.TipoCliente;
```