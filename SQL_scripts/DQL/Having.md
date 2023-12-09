# Having

O having é utilizado para filtar dados agrupados, normalmente utilizado junto com o *group by*

Funciona quase da mesma forma que o *where*

Exemplo:

```SQL
select 
    Nascimento,
    count(ClientID) as 'Qtde Aniversario no mes'
from cliente
    group by Nascimento
    having Nascimento > '2021-05-01';
```