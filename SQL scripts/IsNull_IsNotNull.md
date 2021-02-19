# Is Null e Is Not Null

Trabalhando com registros null, que são colunas que tem registros vazios

Uma forma simples para tratar dentro da coluna com a filtragem é com ```IS NULL / IS NOT NULL```

Exemplo abaixo, quero receber todos clientes que tem a data de aniversario Nulla/Null (vazia):

```SQL
select * from cliente where Nascimento IS NULL;
```

E neste exemplo abaixo, eu quero receber todos clientes que nao tem a Data de nascimento Nulla, ou seja, ele nao pode ser vazio

```SQL
select * from cliente where Nascimento IS NOT NULL;
```

