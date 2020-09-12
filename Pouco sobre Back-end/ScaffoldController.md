# Fazendo o **scaffold** de um *Controller*

![image](https://user-images.githubusercontent.com/58439854/92997369-298ec080-f4e9-11ea-88d2-a0268b1039e0.png)
![image](https://user-images.githubusercontent.com/58439854/92997379-40351780-f4e9-11ea-8419-327bb99f2a5e.png)

## Os comandos acima

- Adicionam os pacotes do NuGet para scaffolding.
- Instalam o mecanismo de scaffolding (dotnet-aspnet-codegenerator).
- Fazem scaffold de TodoItemsController.

### O código gerado:
- Marca a classe com o [ApiController] atributo. Esse atributo indica se o controlador responde às solicitações da API Web. Para saber mais sobre comportamentos específicos habilitados pelo atributo, consulte Criar APIs Web com o ASP.NET Core.

- Usa a DI para injetar o contexto de banco de dados (TodoContext) no controlador. O contexto de banco de dados é usado em cada um dos métodos CRUD no controlador.

### Os modelos de ASP.NET Core para:

- Os controladores com exibições incluem [action] no modelo de rota.

- Os controladores de API não incluem [action] no modelo de rota.

#### Quando o [action] token não está no modelo de rota, o nome da ação é excluído da rota. Ou seja, o nome do método associado da ação não é usado na rota correspondente.