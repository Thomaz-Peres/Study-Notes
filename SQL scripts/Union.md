# Union

*Union* é utilizado para juntar resultados de duas consultas

- O *Union* detem algumas regras, segue algumas
    - Numero de colunas utilizado nos select, deve ser o mesmo
    - Os tipos de colunas tambem precisam ser as mesmas
    - A ordem se as colunas forem iguais, tambem deve ter a mesma ordem

Para o exemplo do *Union*, criei outra tabela, com os mesmos dados, mesma sequencia, etc.

E no caso o *union* fica assim

```SQL
select ClienteID, Nome from cliente
union
select ClienteID, Nome from cliente2
```

Porem como no script acima, voce nao consegue diferenciar de qual tabela vem e etc, e para conseguir separar posso fazer como abaixo e colocar um nome para a tabela

```SQL
select 'Cliente' as Tabela, ClienteID, Nome from cliente
union
select 'Cliente 2', ClienteID, Nome from cliente2
```