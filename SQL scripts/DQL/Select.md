# Select

O select é o principal comando para obter resultados do banco de dados

### O Select possui algumas clausulas, e elas sao:

**from** = inidica a tabela que eu quero utilizar para fazer a consulta
**where** = é a clausula de filtro da consulta, onde aplica restrições para a consulta (por exemplo: quero filtar a seleção por todos IDs maiores que 10)
**group by** = agrupar linhas por meio de valores comuns das colunas
**having** = filtro para itens indesejados
**order by** = faz uma ordenação de registro


Abaixo veremos de uma maneira simples, para consultar os dados de uma tabela

```SQL
-- Retorna todas as colunas e todos os dados na tabela de cliente
select * from cliente;

-- Caso queira pegar uma coluna especifica
select Nome from cliente;
```

### Também é possivel "mudar" os resultados que o select traz, como exemplo abaixo, trazemos o nome todo em MAIUSCULO,

```SQL
select upper(Nome) from cliente;
```