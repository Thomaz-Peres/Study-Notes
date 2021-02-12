# Foreign Key, ou chave estrangeira

Para criar a chave estrangeira, utilizamos da seguinte maneira, exemplo:

```SQL
alter table <tabela de origem> add constraint <nome restrição> foreign key(<campo_tabela_origem>) references <tabela de destino> (<campo da tabela de destino>)
```