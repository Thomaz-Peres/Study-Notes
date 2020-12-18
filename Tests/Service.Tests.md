# Testando repositorio de *Service* de DDD

- No service é usado os testes para testar os métodos HTTP "cru", ou seja, nao é testado o controller.
- Ao inves de utilizar um Database, ou o serviço *Data*, utilizamos o *MOQ*

É necessario criar o automapper para mapear as entidades, DTOs, models, ou o que estiver usando.

![image](https://user-images.githubusercontent.com/58439854/102408177-fff3a280-3fcb-11eb-9cd3-7f03ddbd40ab.png)

### Também é necessario criar os DTOs, models, para fazer os testes e o construtor para fazer o que estara recebendo do testes no parametro.

# Fazendo a implementação

(mockar = imitar a classe que ele esta chamando, e copiar os metodos dentro dela).

- Quando estou utilizando o "serviceMock" e o "service" é para mockar os metodos, os result são feitos para executar os metodos que estão sendo instanciados.

Exemplo de como ficaria testando o **GetBy ID**:

![image](https://user-images.githubusercontent.com/58439854/102493259-b0f05080-4051-11eb-8c23-b48a1219d555.png)

Exemplo de como ficaria testando o **GetAll**:

![image](https://user-images.githubusercontent.com/58439854/102497480-74275800-4057-11eb-82ca-9ea354f65938.png)

Exemplo de como ficaria testando o **POST**:

![image](https://user-images.githubusercontent.com/58439854/102507426-fff2b180-4062-11eb-8255-6e4a2e072bdf.png)

Exemplo de como ficaria testando o **PUT**:

![image](https://user-images.githubusercontent.com/58439854/102508501-37ae2900-4064-11eb-9376-91968a8ed07c.png)

Exemplo de como ficaria testando o **DELETE**:

![image](https://user-images.githubusercontent.com/58439854/102508835-9f647400-4064-11eb-824b-e8df09b59d9e.png)

## Depois é so ir fazendo de acordo com os testes que vc quer realizar