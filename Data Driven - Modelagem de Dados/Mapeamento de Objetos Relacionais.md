# ORM(MAPEAMENTO DE OBJETOS RELACIONAIS)

- Ele faz a relação entre o banco de dados, e os objetos.

**O QUE SIGNIFICA O CODE FIRST** = é focado no codigo primeiro, e depois gerado o banco.

Isso ocorre para garantir que as mudanças que estão nos codigos, vão para os bancos.

### Trabalhando com Migrações

dotnet ef migrations add initial = é uma criação de uma migração inicial 

E O QUE É MIGRAÇÃO INICIAL ??????

- ele pega o StoreDataContext, ler todos os itens que tem dentro, e ler suas propriedades, e gerar um script SQL para criar o banco de dados e aplicar automaticamente.