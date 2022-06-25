# API, REST e RESTFUL

Cliente (Client)
Garçom(pedidos, levar seus pedidos, para a cozinha)(API)
Cozinha (Server)

**API**(Application Programming Interface) = Copnjunto de rotinas e padroes que uma aplicação disponibiliza, para que outras aplicações utilizem essas informções.

- Resposável por estabeler comunicação entre diferentes serviços.
- Meio de campo entre as tecnologias.

# Rest

**REST**(Representational State Transfer)

Será feita a transferência de daods de uma maneira simbólica, figurativa, representativa, de maneira didática.

o **REST** determina algumas obrigaçoes nas transferencias de dados, geralmente, usando o protocolo HTTP.

O **Rest**, delimita algumas obrigações nessas transferências de dados.

Os dados no Rest são chamados de *Resources* , *Resources* seria então, uma entidade, um objeto.

### 6 NECESSIDADES (constraints) para ser RESTFUL

- _Client-server_: Separação do cliente e do armazenamento de dados (servidor), dessa forma, poderemos ter uma portabilidade do nosso sistema, usando um Framework para WEB e um Framework para o smartphone, por exemplo.

- _Stateless_: Cada requisição que o cliente faz para o servidor, deverá conter todas as informações necessárias para o servidor entender e responder (RESPONSE) a requisição (REQUEST). __Exemplo:__ A sessão do usuario deverá ser enviada em todas as requisições, para saber se aquele usuario está autenticado e aptio a usar os serviços, e o servidor não pode lembrar que o cliente foi autentitcado na requisição anterior.

- _Cacheable_: As respostas para uma requisição, deverão ser explicitas ao dizer se aquela requisição, pode ou não ser cacheada pelo cliente.

- _Layered System_: O cliente acessa a um endpoint, sem precisar saber da complexidade, de quais passos estão sendo necessários para o servidor responder a requisição, ou quais outras camadas o servidor estrá lidando, para que a requisição seja respondida.

- _Code on demand (optional)_: Dá a possibilidade da nossa aplicação pegar códigos, como o C#, e executar no cliente.


## RESTFUL

RESTFUL, é a aplicação dos padrões REST.


## Fluent APIs

Fluent API é uma API orientada a objetos cujo design se baseia amplamente no encadeamento de métodos. 

# Sobre fluent APIs com Entity Framework Core
Tratar(mapear) as entidades, tabelas e colunas sem utilizar os Data Anonnations do EF Core.
Tratamento(mapear) usando uma configuração do *ModelBuilder* como nos exemplos abaixo.

- Inicio 
![image](https://user-images.githubusercontent.com/58439854/101818026-0a142d80-3b02-11eb-98ba-dd85a049c7df.png)

- continuação
![image](https://user-images.githubusercontent.com/58439854/101817903-df29d980-3b01-11eb-82e4-d57fff7af569.png)

## Também pode ser utilizado separando por Pastas e classes

- Exemplos de mapemanto por classes diferentes

- Exemplo 1

![image](https://user-images.githubusercontent.com/58439854/101818789-1ea4f580-3b03-11eb-8c7a-c6dbdeece845.png)

- Exemplo 2

![image](https://user-images.githubusercontent.com/58439854/101818834-2ebcd500-3b03-11eb-8138-2a902be69154.png)


## Chamando isso no DataContext da aplicação
![image](https://user-images.githubusercontent.com/58439854/101818907-4e53fd80-3b03-11eb-9a63-01f22ce4361f.png)