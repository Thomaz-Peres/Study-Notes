# entity framework, pode ser considerado um banco de dados

## Data context, é a representação do banco de dados em memoria.

## ele permite a orientação em relação ao banco de dados

### se o DBContext é a representação do banco de dados em memoria, o DbSet, é a representação das tabelas em memoria

- Sempre que tiver um (DbSet<Products> Products), ele busca no banco essa tabela chamada (Products)

## recomendavel sempre começar primiero por Models

### DbSet são os responsaveis por permitir a utilizar o CRUD, e responsaveis pelas ações que tomamos no banco


# Depois de ter um DataContext criado, é necessario informar para o programa, como ela vai encontra, abaixo mostro como utilizalo

- Na seção Startup (pelomenos em .NET CORE, ASP.NET CORE (que eu conheço))

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

                          Coloca o data context  OPT = opção||| Tipo de banco utilizado
    services.AddDbContext<DataContext>          (opt => opt.   UseInMemoryDatabase("Database")
    );  informando que existe um DbContext


    services.AddScoped<DataContext, DataContext> ();

    (AddScoped garante que eu so vou ter um DataContext por requisição).
}