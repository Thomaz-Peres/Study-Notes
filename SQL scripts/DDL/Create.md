# Create
O create pode ser usado para criar, banco de dados, tabelas, views, procedures, etc. Sempre que for criar algo, utiliza o comando ***CREATE***

Tambem sempre a um "esquema" para utilizar o create, exemplo:

create <"oq deseja criar"> <"nome do que de quer criar">

```SQL
create table cliente(
    -- Aqui entra as informações da tabela (colunas que compoem a tabela)
    -- Alem de informarmos a coluna, o tipo, e as restrições dessa coluna

    ClientID INT PRIMARY KEY
    
);
```