# Views

A *view* pode ser chamada de tabela virtual, ja que ela nao "existe". Os dados que estão dentro da view, NÃO EXISTEM DENTRO DELA.

### ***OBS: Os dados da tabela cliente que não ficam salvos, porém as CONSULTAS feitas, ficam salvas***

A *view* retorna uma tabela com o resultado de um consulta que esta programada para ela fazer, ou seja, quando eu chamo a *view* em questão, automaticamente ela executa a consulta e retorna os dados especificos que foi programado na view.

### Entao para que serve a *view* se ela não tem os dados ?

Ela serve para facilitar suas consultas, ja que algumas bases de dados tem tabelas muito grandes e com muitas colunas, e se você quer usar so um pouco dessa pesquisa, e nao precisar ficar criando o select toda vez na mão, você cria essa view com os dados especificos que você deseja, e quando você for utiliza-los, basta chamar a view desejada na consulta

## Criando um view

Abaixo vou passar um exemplo para criar uma view que desejo guardar os *nomes e CPFs na tabela de clientes*

```SQL
create view NomeCPF as select Nome, Cpf from cliente;

-- Selecionando a view
select * from NomeCPF;
```

## Criando uma view mais complicada, salvando os aniversariantes do mes:

```SQL
-- Month = recebe o mes que foi passado na data
-- Day = mesma coisa q o month, porém recebe apenas o dia
-- Curdate = currentDate, é o mes corrente, mes atual que estamos

create view NiverMesAtual as
select ClientID, Nome, day(Nascimento) as 'Dia Aniversario' from cliente where month(Nascimento) = month(curdate());
```


## Useful Scenarios

- Needing to quickly create query-able objects over source data without explicitly stating schema
- When source data is partitioned and is large enough that partition pruning is required
- When only a specific set of columns are required to be exposed from the data source
