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