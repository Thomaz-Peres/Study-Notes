# DDL

DDL = Data Definition Language = Linguagem de definição de dados

Na categoria de DDL, temos os comandos, *Create, alter, drop*, são comandos para a criação e manipulação do banco de dados, onde criamos e definimos opções do banco de dados

## Create
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

## Drop

Drop é usado para deletar, funciona igual criar a tabela

```SQL
drop table cliente;
```

## Alter

Serve para atualizar algo, e pode utilizar para atualizar a tabela com uma nova coluna.
Pode ser utilizado com o drop, para deletar uma coluna

```SQL
alter table cliente MODIFY COLUMN Nome VARCHAR(30);
alter table cliente add TipoCliente BOOL NOT NULL default 1;

alter table cliente drop column TipoCliente;
```