# Operador BETWEEN

O between é utilizado para fazer uma consulta entre valores

Exemplo:

```SQL
-- Nessa primeira consulta quero selecionar os clientes, onde o TipoCliente esta entre 1 e 10
select * from cliente where TipoCliente between 1 and 10
```