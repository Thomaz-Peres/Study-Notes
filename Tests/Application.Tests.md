# Testando repositorio de *Application* de DDD

- No aplication, testamos o retorno do controller(200, 201, 400, 500, etc)
- Também se utiliza Moq

Para criar os testes do application abaixo, vou explicar abaixo passo a passo ([exemplo de retorno 200 do post](#200))

- 1. Na imagem abaixo estamos fazendo a conexao com o mock e mocando o IUserService, e no setup fazemos a "inicialização" do mock
    - 1.1 ![image](https://user-images.githubusercontent.com/58439854/102558413-21c45680-40ac-11eb-987d-d63e3105ef7b.png)



## <a name="200"></a> Testando o retorno 200 do **post**

![image](https://user-images.githubusercontent.com/58439854/102558102-7c10e780-40ab-11eb-90a0-6c9e73183f8f.png)


## Testando o retorno de BadRequest do **post**

![image](https://user-images.githubusercontent.com/58439854/102557771-b1690580-40aa-11eb-86af-1f3a1dd56e67.png)