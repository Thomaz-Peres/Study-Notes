# Testando repositorio de *Data* de DDD

Para fazer os testes do *Data* do DDD, é necessario criar um banco de dados "falso" para que seja possivel realizer o teste e se esta funcionando.

O banco de dados falso, vai fazer uma conexao no seu banco normal, e apos encerrar o teste ele vai fechar o banco de dados criado para o teste.

Exemplo:

![image](https://user-images.githubusercontent.com/58439854/102371630-29490a00-3f9d-11eb-9c3c-0205dd387041.png)

Como na imagem acima, eu crio uma connectionString, colocado como **dataBaseName**.

Dentro do método **DbTeste()**, faço a conexao com o banco de dados, e passo o banco de dados como  a connectionString criada anteriormente, no caso a *dataBaseName*.
- Colocado como Transiente no lifetime, para criar uma conexao a cada requisição (pode ser utilziado o Scoped ou o Singleton).

O *BuildServiceProvider* esta buildando o ServiceProvider para criar um provedor.

E o using, para sempre que eu instanciar o context, ele fechar a requisição ao sair do using, e dentro do using em **context.Database.EnsureCreated();** eu crio o banco de dados e faço a migração, quando eu sair do using, vai fechar o banco de dados ate chamalo novamente.

# Dispose

O metodo dispose garante que o banco de dados foi eliminado

![image](https://user-images.githubusercontent.com/58439854/102372664-3286a680-3f9e-11eb-9189-0addb8587760.png)


# Criando um *CRUD* no *DATA* para ver se esta funcionando corretamente

Para fazer o CRUD é necessario fazer com que a classe do que ira testar o CRUD, receba a DI(Dependency Injection) do Data Context de teste que recebe o ServiceProvider

![image](https://user-images.githubusercontent.com/58439854/102393732-85b92300-3fb7-11eb-94bf-49b38f7d0a98.png)

## Abaixo tem como utilizar no método de teste
![image](https://user-images.githubusercontent.com/58439854/102398922-ad5fb980-3fbe-11eb-8281-37b4f80c9443.png)

Dentro do using passamos o Repositorio onde recebe os métodos de CRUD (Select, remove, get, etc)
- Depois é so passar a entidade e implementar com os valores, exemplo abaixo:
```Csharp
UserEntity entity = new UserEntity{
    Nome = "thomaz",
    Sobreno = "peres"
};
```
Depois é so fazer a implementação de (inserir, deletar, select, etc) o teste e os asserts. Exemplo :

![image](https://user-images.githubusercontent.com/58439854/102402222-3b3da380-3fc3-11eb-815e-98a2ebea4737.png) 