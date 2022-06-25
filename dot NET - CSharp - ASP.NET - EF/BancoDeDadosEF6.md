# Banco de Dados e Entity Framework

- Data context é uma representação do banco de dados em memoria.

- Ele permite fazer o mapeamento/orientação da aplicação em relação ao banco de dados.

## DataContext

- Nada mais é do que uma classe que herda de **DbContext**

## Db Set

- DbSet são os responsaveis por permitir a utilizar o CRUD, e responsaveis pelas ações que tomamos no banco

- DbSet é a representação das tabelas em memoria.

- Sempre que tiver um DbSet de produtos, ele vai buscar no Banco uma tabela chamada Product.

- E no final vai fazer um mapeamento dos models.

## AsNoTracking e algumas coisas especiais do *Entity Framework*
- AsNoTracking = desliga tudo, e faz uma leitura da forma mais rapida possivel, que ele consegue pegar no **Banco de Dados** e joga para a tela.

- ToListAsync = o *ToListAsync* é usado para executar a querie no banco. **SEMPRE UTILIZAR NO FINAL**