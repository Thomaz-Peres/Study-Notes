# Alter

Serve para atualizar algo, e pode utilizar para atualizar a tabela com uma nova coluna.
Pode ser utilizado com o drop, para deletar uma coluna

```SQL
alter table cliente MODIFY COLUMN Nome VARCHAR(30);
alter table cliente add TipoCliente BOOL NOT NULL default 1;

alter table cliente drop column TipoCliente;
```