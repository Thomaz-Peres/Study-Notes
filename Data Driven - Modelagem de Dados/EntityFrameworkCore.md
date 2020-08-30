# Entity Framework Core

- É uma solução ORM da microsoft.
ORM(Object Relation Maping, mapeamento de objeto relacional).

- faz o Dê-para das classes para as tabelas, facilitando a vida dos desenvolvedores(mais expecificadamente, como q roda o Banco de dados, como que armazena os dados.)

- Ele se conecta com o banco de dados, depois le as informações e converte para a linguagem C#

- Ele é uma transição, do objeto que é retornado do Banco de Dados.

- Permite escrever QUERIES em cima dos objetos, e outras vantagens.

## Trabalhando com Data Context (contexto de Dados)

- No entity Framework, é possivel criar uma representação do banco de dados em memoria(Famoso **UseInMemory**), conhecido como o **Data Context**

- o **Data Context** é um arquivo q o **Entity Framework** precisa para funcionar, é onde é criado e definido todas as entidades dentro do *Models*, é definido quais vão para o banco e como sera mapeado.

- é a partir da pasta Data => arquivo StoreDataContext => que herdamos o DbContext, e que chegamos: [Banco de dados, Entity framework e DB SETs]()