# Fazendo o teste de integração

- Normalmente se faz a referencia a todas as camadas dentro do projeto, e nuget do TestHost.

- É necessario a utilização do ```IWebHostEnvironment``` na classe Startup, que normalmente, ja é utiliza quando otiliza o Azure DevOps, ou github actions, etc.
### Exemplo do startup configurado com o ```WebHostEnvironment```
![image](https://user-images.githubusercontent.com/58439854/102650431-b0d37c00-4149-11eb-82fd-6fed6888fcb7.png)

## Caso sua aplicação tenha token, é necessario fazer uma implementação no *intregration.tests* de uma rotina que vai pegar esse token e fazer um login toda vez que for fazer um teste de integração.

- Para isso ocorrer, é necessario um objeto que contenha todas as propriedades do retorno do token. Então criamos uma classe na **Integration.Tests** que sera de propriedades(props) e que recebera um ```[JsonProperty("nome que esta na propriedade do token")]```, o nome da classe sera **LoginResponseDto**

Exemplos: 

- Objeto "normal" que recebe o token.
![image](https://user-images.githubusercontent.com/58439854/102657197-07de4e80-4154-11eb-82f5-dd2b437da115.png)

- Classe do teste que recebe as propriedades do token
![image](https://user-images.githubusercontent.com/58439854/102657228-1593d400-4154-11eb-9415-f2d078767b95.png)

## Agora iremos fazer a integração base, e ela sera chamada de **BaseIntegration**

A base integration precisa de um contexto do banco de dados para fazer a conexao do DataBase

Do *HttpClient* pois é ele que vai executar as requisições

Do Mapper. 

A propriedade de string hostApi serve para ficar o local host(https://localhost:5001/api)

O **HttpResponseMessage** que retorna a mensagem do response

![image](https://user-images.githubusercontent.com/58439854/102663675-15013a80-4160-11eb-80ce-f80e102c6b69.png)

## No construtor
![image](https://user-images.githubusercontent.com/58439854/102660208-69ed8280-4159-11eb-9cf2-61225dd14adb.png)

Um construtor onde vai receber o *hostapi*, fazer a conexão do Environment e a Startup atraves da variavel *builder*, e depois a variavel server que recebera a conexao do servidor atraves do ```TestServer(builder)```;

Na Variavel MyContext voce pega o Contexto que esta dentro do startup, e cria um migration

No mapper a gente vai receber outro método, que é a configuração do mapper igual no startup:

![image](https://user-images.githubusercontent.com/58439854/102663742-32ce9f80-4160-11eb-805e-f0a707dbdb08.png)

A variavel ```client```, esta levantando um servidor para conseguir fazer as requisições, ele seria o *Postman em memoria*.

## Metodo *AdicionarToken*

É quem ficará responsavel por receber o token, fazer o login, e enviar para a variavel ```client```
![image](https://user-images.githubusercontent.com/58439854/102664315-3ca4d280-4161-11eb-9234-12c6acb8d1e9.png)

a variavel ```resultLogin``` é o resultado da requisição para chamar o *PostJsonAsync* 

a variavel ```jsonLoging``` é criada para receber o JSON do login, e enviar o json como uma string

a variavel ```loginObject``` vai receber a variavel ```jsonLoging``` deserializar e receber com os parametros de ```LoginResponseDto```

e por ultimo em ```client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",loginObject.accessToken);``` estou recebendo o tipo de autenticação, e o token de acesso.

## Metodo *PostJsonAsync*

É usado para fazer o login e nao precisar ficar colocando ele toda hora, e ja fazer automaticamente.

![image](https://user-images.githubusercontent.com/58439854/102664442-8a213f80-4161-11eb-8588-7157dc7194ff.png)

## Método dispose da classe, no caso a ***BaseIntegration***

O método ```Dispose()``` quando chegar nele, ele vai fechar o client e o banco de dados:
![image](https://user-images.githubusercontent.com/58439854/102664127-e899ee00-4160-11eb-910a-1d6fd5bcf059.png)