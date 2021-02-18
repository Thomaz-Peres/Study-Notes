# Sub Select

O sub select é usado para automatizar campos de auto incremento

Como no exemplo abaixo, onde faço o ID ser auto incrementado, assim mudando apenas o nome, cpf, etc:

```SQL
inset into cliente values(
    (select max(ClienteID) + 1 from cliente), 'Nome', 'CPF', 'Data', TipoCliente
);
```