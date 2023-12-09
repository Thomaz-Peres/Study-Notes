# Case When

O *Case When* é utilizado para fazer tratamentos para uma coluna retornar um resultado ou outro.

A sintaxe do *Case When* é diferente, abaixo segue uma explicação rapida sobre.

```SQL
-- O when faz o teste da condição, se ela for verdadeira, me retorna um resultado, e dentro do "case" e "end", posso fazer varias condições.
-- e no final utilizo um "else", que retorna um resultado quando nenhunma condição é verdadeira.
case
    when {condição} then resultado
end
```

Outro exemplo de usando o *Case when* no script

```SQL
select 
    ClientID, 
    Nome,
    case 
        when DataNascimento is null then now() -- Se a data for nulla, recebo a data de agora
        else DataNascimento -- Se nao for nula, ela vai continuar como esta
    end,
    TipoCliente        
from cliente;

```