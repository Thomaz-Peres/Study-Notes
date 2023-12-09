# Group By

O *group by* agrupar linhas por meio de valores comuns das colunas, exemplo:

Se eu tenho um tipo de cliente, com ID 1 e 2, tenho 2 clientes do tipo 2, eles agrupam esses 2 clientes em uma unica linha.

O codigo abaixo vai agrupar todos os clientes do tipo 1 e 2, e mostrar em apenas uma linha, porém vai mostrar apenas 2 linhas, sem mostrar a quantidade.

```SQL
select * from cliente group by TipoCliente
```

Agora mostrando a quantidade de tipos de cliente 1 e 2.

No exemplo abaixo, a consulta ira me mostrar, duas colunas, uma com o numero do TipoCliente, e a segunda coluna, uma conta(soma) dos Ids dos clientes q entao ali, ou seja, quantos clientes do tipo 1 e do tipo 2, segue uma foto de exemplo, e depois o codigo:

![image](https://user-images.githubusercontent.com/58439854/108525629-0e518980-72af-11eb-8699-8da1c301de50.png)

```SQL
select 
    TipoCliente,
    count(ClientID) as quantidade
from cliente
    group by TipoCliente;
```