# Trabalhando com Migrações

dotnet ef migrations add initial = é uma criação de uma migração inicial 

E O QUE É MIGRAÇÃO INICIAL ??????

- ele pega o StoreDataContext, ler todos os itens que tem dentro, e ler suas propriedades, e gerar um script SQL para criar o banco de dados e aplicar automaticamente.