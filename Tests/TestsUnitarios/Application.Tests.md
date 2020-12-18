# Testando repositorio de *Application* de DDD

- No aplication, testamos o retorno do controller(200, 201, 400, 500, etc)
- Também se utiliza Moq

Para criar os testes do application abaixo, vou explicar abaixo passo a passo ([exemplo de retorno 200 do post](#200))

- 1. Na imagem abaixo estamos fazendo a conexao com o mock e mocando o IUserService, e no setup fazemos a "inicialização" do mock. e criamos um UserDtoCreate
    - 1.1 ![image](https://user-images.githubusercontent.com/58439854/102558413-21c45680-40ac-11eb-987d-d63e3105ef7b.png)

- 2. Abaixo passamos pro _controller o objeto que criamos acima, e criamos uma URL mockada.
    - 2.1 ![image](https://user-images.githubusercontent.com/58439854/102621886-03e40980-411f-11eb-9d2d-b6c116bc570f.png)

- 3. Abaixo criamos o Usuario, passamos o result, que é quando realmente fazemos a chamada do controller, e criamos os asserts, *OBS: eu poderia parar o teste no ```Assert.true(result is CreatedResult);``` pois ali ja recebo status que esta retornando
    - 3.1 ![image](https://user-images.githubusercontent.com/58439854/102623039-a51f8f80-4120-11eb-9bba-73cc2111778f.png)


## <a name="200"></a> Testando o retorno 200 do **post**

![image](https://user-images.githubusercontent.com/58439854/102558102-7c10e780-40ab-11eb-90a0-6c9e73183f8f.png)


## Testando o retorno de BadRequest do **post**

No caso do BadRequest, permanece a mesma coisa, porém eu preciso criar um "problema" no ModelState para ele ser invalido

![image](https://user-images.githubusercontent.com/58439854/102624045-3a6f5380-4122-11eb-960b-376a66d8ca9c.png)

## Testando o retorno ok do **Delete**

Funcionaria do mesmo jeito q o Post, e os outros(update, get, também seriam quase iguais)

- Como anteriormente, o ```resultValue``` nao é necessario, so o ```var result = ... e o Assert.True```  ja testa o retorno.

O ```resultValue``` serve para abstrair os valores do objeto, voce continua com ele, igual na imagem abaixo
![image](https://user-images.githubusercontent.com/58439854/102628677-d439ff00-4128-11eb-8f04-0b7f668b40f5.png)