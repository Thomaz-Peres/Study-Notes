# Funções Round, Count, sum e AVG

[SUM = soma](#Sum)
AVG/average = media
COUNT = contagem
ROUND = arredondar

## <a name="Sum"></a> Sum / Soma

A funçao *Sum*, é a função utilizada para fazer a soma de valores determinadas colunas informadas.

Exemplo de utilização;

```SQL
-- Esse script soma TODOS os valores da coluna de ValorVenda na tabela vendas

select sum(ValorVenda) from venda;
```

## <a name="Round"></a> Round / Arredondamento

A função de *Round* é utilizado para arredondar valores.

A função *Round* funciona assim = round(valor a ser arredondado, numero de casas decimais desejadas)

Exemplo:

```SQL
-- Nesse script eu arredondo todos os valores somados da coluna de ValorVenda

select round(sum(ValorVenda), 2) from venda;
```

## <a name="Avg"></a> AVG / Media / Average

A função *AVG* é usado para calcular a media de determinado valor

Exemplo:

```SQL
-- Esse script tira a media de TODOS os valores da coluna de ValorVenda na tabela vendas

select avg(ValorVenda) from venda;
```

## <a name="Count"></a> Count / Contagem

A função count é utilizada para fazer contagem, ou contar quantos valores foram retornados

No exemplo abaixo, eu estou contando quantas vendas esta sendo tirado a media:

```SQL
-- Nesse script estou tirando a quantidade de vendas que foram tirada as medias, tipo ''Resultado da media tirado de 15 vendas''

select count(ValorVenda) as 'Qtde Vendas', round(avg(ValorVenda), 2) as 'Valor medio das vendas' from venda;
```