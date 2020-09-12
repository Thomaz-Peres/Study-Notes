# DataBase Context

- O **Database Context** é a classe principal que coordena a funcionalidade do Entity Framework para um modelo de dados. Essa classe é criada derivando-a da classe **Microsoft.EntityFrameworkCore.DbContext.**

## Adicionando um DataBase Context

- Para utilizar o DataBase Context é necessario criar um novo Arquivo com o nome do arquivo que quero puxar dos dados, no caso *TodoContext* em uma pagina de dados, e usar um exemplo do codigo abaixo

```Csharp
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
```

-No ASP.NET Core, serviços como o DB(DataBase) context precisam ser registrados no contêiner de DI(injeção de dependência). O contêiner fornece o serviço aos controladores

- Depois disso é preciso registrar o DataBase Context(normalmente na classe startup da seguinte forma).
![image](https://user-images.githubusercontent.com/58439854/92996935-c94a4f80-f4e5-11ea-8d45-30da73261de9.png)

- O codigo acima adiciona o contexto de banco de dados ao contêiner de DI.
- Especifica que o contexto de banco de dados usará um banco de dados em memória.
