# Testando repositorio de *Service* de DDD

- No service é usado os testes para testar os métodos HTTP.
- Ao inves de utilizar um Database, ou o serviço *Data*, utilizamos o *MOQ*

É necessario criar o automapper para mapear as entidades, DTOs, models, ou o que estiver usando.

![image](https://user-images.githubusercontent.com/58439854/102408177-fff3a280-3fcb-11eb-9cd3-7f03ddbd40ab.png)

### Também é necessario criar os DTOs, models, para fazer os testes e o construtor para fazer o que estara recebendo do testes no parametro.

# Fazendo a implementação

(mockar = imitar a classe que ele esta chamando, e copiar os metodos dentro dela).