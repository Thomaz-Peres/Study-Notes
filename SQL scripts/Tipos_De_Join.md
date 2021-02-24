# Tipos de join no SQL

**Inner Join**, **Left Join**, **Right Join** e **Full outer Join**


# **Inner Join**

O *inner join* é usado para vinculação de tabelas, mais de 1 tabela na consulta.

No exemplo abaixo, estou puxando a tabela *cliente*, e no *TipoCliente*, quero receber a descrição do tipo de cliente, e nao apenas o *ID*:

```SQL
select
    ClientID,
    Nome,
    Cpf,
    Nascimento,
    TipoCliente
from cliente
    inner join tipocliente on TipoCliente = Descricao

```
#### *É possivel utilizar mais de uma vez o inner join na mesma consulta*


# **Left Join**

O *left join* ele retorna o que é comum entre as duas tabelas, e todo o conteudo da *primeira tabela/tabela principal*

# **Right Join**

O *right join* funciona quase igual ao *left join*, porém ao contrario, ele vai retornar o que é comum entre as duas tabelas, e todo o conteudo da *segunda tabel*;

# **Full outer Join**

O *full outer join* vai retornar todo o conjunto das duas tabelas, independente das tabelas terem relação ou não.