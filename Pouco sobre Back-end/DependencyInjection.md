## Depois de ter um DataContext criado, é necessario informar para o programa, como ela vai encontra, abaixo mostro como utiliza-lo

- Na seção Startup (pelomenos em .NET CORE, ASP.NET CORE (que eu conheço))

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    Coloca o data context  ||OPT = opção||| Tipo de banco utilizado

    services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); 
                                                                 informando que existe um DbContext


    services.AddScoped<DataContext, DataContext> ();

    (AddScoped garante que eu so vou ter um DataContext por requisição).
}

## Como fazer o Data context chegar para o *Controller*

- 