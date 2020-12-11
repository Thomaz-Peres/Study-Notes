# Os mocks são objetos "falsos" que simulam o comportamento de uma classe ou objeto "real" para que possamos focar o teste na unidade a ser testada.

![image](https://user-images.githubusercontent.com/58439854/101921533-e1487280-3bab-11eb-889c-014ab7578f70.png)

- **Exemplos**

Digamos que queremos testar uma conexão com o banco de dados, porém nossos testes devem ser desacoplados, como faremos?

Podemos imaginar que temos um banco de dados totalmente funcional e criar um objeto que represente ele, que finja ser o banco de dados, mas ele só vai possuir e responder aos métodos que chamamos e que utilizamos, e vamos poder responder da maneira que quisermos.

Desta forma podemos testar nossa conexão com o banco de dados, assumindo que o mesmo funciona e retornará um valor previsto por nós (que será o que nossa função testada estará esperando).

## Objetos de testes (conhecidos como *test double*) dividem entre 5 categorias: *spies*, *stubs*, *mocks*, *Dummie* e *Fakes*

### ***Spies :***
Spies não é um conceito tão comum quanto Mocks ou Stubs. Spy pode ser definido como um tipo de combinação de um Mock com um Stub. Mas não apenas isso, spies também permitem gravar as chamadas para o método “espionado”, além de outras informações.

***Quando e para que usar:*** Quando queremos gravar o comportamento de um método dentro de um objeto e/ou controlar o que esse método retorna.

### ***Stubs :***
Stubs são objetos que usamos para simular interações de chegada de alguma dependência externa ao SUT. Diferente do Mock, stubs são objetos com respostas prontas para serem usados no nosso teste. Eles não sabem responder quantas vezes um método de uma dependência externa foi ou não chamado e quais parâmetros foram usados, apenas trazem resposta prontas.

***Quando e para que usar:***

1 -Para testar retornos de uma dependência externa;

2- Testar o comportamento do nosso SUT frente aos diferentes retornos da API. Por exemplo, retornos de sucesso, falhas ou exceções.

```“Não é aconselhável utilizar Mocks ou Stubs para testes de integração, já que estes devem ser o mais próximo possível do ambiente de produção.”```

### ***Fakes :***
Fakes são na verdade objetos reais, muito próximos da sua versão em produção, mas que trazem velocidade aos nossos teste.

```“Fakes são úteis em testes funcionais ou testes de integração, mas não são recomendados para testes unitários onde podemos suprir nossas necessidades com stubs.”```

***Quando e para que usar:*** Para simular grandes quantidades de dados em memória vindos de uma chamada assíncrona de um banco de dados ou de uma API externa.

### ***Dummies :*** 
Dummies nada mais são do que uma lista de argumentos que utilizamos para manter a assinatura de um método em nosso teste. Servem apenas para preencher um espaço necessário, mas não produzem efeitos no teste.

``` Vimos também que Fakes, Spies e Dummies são casos particulares de Mocks e Stubs. A verdade é que a diferença entre os Tests Doubles é muito sutil, mas é de extrema importância entender os conceitos para garantir a confiabilidade de nossos testes. ```