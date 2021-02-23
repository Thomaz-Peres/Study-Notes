# Top VS Limit

Usado para limitar o numero de registros da cosulta

## A diferença para o Top Vs o Limit

**TOP** = O top normalmente é utilizado no SQL Server, no exemplo abaixo quero receber os 5 primeiros registros da consulta no SQL Server:

```SQL
select TOP 5 * from cliente;
```

**Limit** = O Limit normalmente é utilizado no MYSql, e no exemplo abaixo tambem quero receber os 5 primeiros registros da consulta no MYSQL

```SQL
select * from cliente limit 5;
```