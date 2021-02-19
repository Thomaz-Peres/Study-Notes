# Inner Join

O inner join é usado para vinculação de tabelas, mais de 1 tabela na consulta.

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

### É possivel utilizar mais de uma vez o inner join na mesma consulta