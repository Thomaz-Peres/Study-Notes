# Order By

O *OrderBy* tem a função de ordenação do resultado, podendo ordernar numeros, alfabeto, caracteres, etc.

O *OrderBy*, por padrao sempre ordena por ordem crescente/ascendente, [neste exemplo](#CrescenteDecrescente), mostro como ordenar por decrescente/descendente,

No exemplo abaixo criei uma ordenação simples, fazendo a ordenação por ordem alfabetica, mas poderia passaro por Tipocliente, aniversario, ou qualquer coisa que tenho na minha tabela.

```SQL
select * from cliente
    order by Nome;
```
Também posso ordernar por dois tipos, abaixo eu perdi a ordenação pelo tipo do cliente, e depois ele ordena por nome, mantendo todos clientes 1 em ordem alfabetica e os clientes de numero dois também em ordem alfabetica.

```SQL
select * from cliente
    order by TipoCliente, Nome;
```

<a name="CrescenteDecrescente"></a> Crescente/ascendente - Decrescente/descendente

```SQL
select * from cliente
    order by Nome DESC;

-- Desc para descendente
-- Asc para ascendente
```

Também é possivel ordenar pela "direita e esquerda", segue exemplo para ficar mais facil:

```SQL
-- Quero ordernar meu CPF pelos 3 numeros finais da direita
select * from cliente order by right(Cpf, 3);
```