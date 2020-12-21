# Fazendo o teste de integração de POST do usuario

## Fazendo o teste de integração do **POST**.

![image](https://user-images.githubusercontent.com/58439854/102787896-88819280-4380-11eb-8018-a04a1c7b5172.png)

Na imagem acima, a variavel **response**, chama o metodo ```PostJsonAsync()``` e faz a publicação do usuario.

A variavel **postResult** chama o response e Lê a mensagem do PostJsonAsync.

A variavel **registroPost** deserializa a mensagem para um UserDtoCreate.

Depois passa os asserts, o primeiro ```Assert.Equal(HttpStatusCode.Created, response.StatusCode);``` voce esta esperando o tipo de create do HTTP ser igual ao StatusCode do response, que fez o post da mensagem

## Fazendo o teste de integração do **GetAll**.
![image](https://user-images.githubusercontent.com/58439854/102793387-99ce9d00-4388-11eb-8a0f-44c0781f9b28.png)

Na imagem acima, fazemos o Get na rota, e vemos se o status HTTP é *OK* e o response é igual

Na variavel **jsonResult** recebemos os usuarios que foram postados

Na variavel **listaFromJson** deserealiza em um Enumerable(uma lista dos usuarios)

Depois fazemos os assert, pra saber se a lista é null, se é maior q 0, etc

O ultimo assert ```Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);``` ele esta filtrando a lista pelo registro que foi adicionado anteriormente no post, e vai contar 1, pois fez o *where*

## Fazendo o teste de integração do **PUT**.
![image](https://user-images.githubusercontent.com/58439854/102795795-12832880-438c-11eb-9abc-5e1424b5d49a.png)

Na imagem acima, adicionamos uma atualização do *User*, e a variavel stringContent envia o ```updateUserDto``` como se fosse no corpo da requisição, e serializa ele para json

Na variavel ```jsonRestul``` estamos recebendo a "mensagem"

Na variavel ```registroAtualizado``` recebemos a mensagem deserializada

Depois basta adicionarmos os Asserts, no caso acima verificamos o status que recebemos do HTTP e da variavel ```response```, e depois verificamos se os registros são diferentes dos adicionados anteriormente

## Fazendo o teste de integração do **Get By Id**.
![image](https://user-images.githubusercontent.com/58439854/102803635-4ca5f780-4397-11eb-97c8-13a0dfb29420.png)

Na imagem acima, utilizamos o response passando o segundo parametro do ID do registro atualizado, e em seguida ja verificamos se o Status HTTP são iguais.

Na variavel ```jsonResult```, recebemos a "mensagem".

Na variavel ```registroSelecionado```, fazemos a deserialização do ```jsonResult```, e passamos como parametros do **UserDto**

Depois basta criarmos os Asserts, onde verificamos se o registroSelecionado nao é nullo, e se o registro que buscamos recebe o mesmo nome, do registro que atualizamos anteriormente

## Fazendo o teste de integração do **Delete**.
![image](https://user-images.githubusercontent.com/58439854/102804222-377d9880-4398-11eb-98fc-b6945744d2f8.png)

No reponse passamos o registro que queremos deletar.

Depois criamos o Assert, onde dizemos se o status do HTTP é o mesmo do response.

Podemos criar um assert para verificar se o ```registroSelecionado``` é nullo, para termos a confirmação