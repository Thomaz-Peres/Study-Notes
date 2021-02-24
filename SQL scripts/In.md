# Operador IN

Usado para criar conjunto de valores para especificar um pouco melhor os filtros.

O *in* é bom para especificar valores em conjuntos pare ele realizar a filtragem

Exemplo:

```SQL
-- Nessa primeira consulta, quero receber todos CPFs que o ultimo digito possam ser com '0,1 ou 2'

select * from cliente where right(CPF, 1) in (0,1,2);

-- Nessa segunda consulta, quero receber todos CPFs que os 3 ultimos digitos possam ser com '000,001 ou 002'
select * from cliente where right(CPF, 3) inf (000, 001, 002);
```

Tambem é possivel utilizar um *sub-select* dentro do *IN*

