# Autenticação e Autorização de usuarios.

- Necessario instalar o pacote = Microsoft.AspNetCore.Authentication

- **Autenticação** = quem o usuario é.
- **Autorização** = o que o usuario pode fazer.

## Aprendendo de uma forma mais simples e funcional possivel.

- Na API nao fica conectado nela, então é gerado um **token** na API, e a cada requisição que o usuario faz na API, ele precisa enviar o **token**, em um cabeçalho especial chamado de autorization.

- O **token** gerado fica em um REST, uma string gigantesca e fica gravado em um formato chamado **JWT (Jason Web Token)**, é um *padrao do token*.

- Para trabalhar com o formato **JWT** também é necessario instalar/adicionar um pacote chamado de **Microsoft.AspNetCore.Authentication.Jwtbearer**

- Toda vez que o token é gerado, é necessario uma **chave privada**, ela é usada para *desencriptar* o token e so o nosso servidor tem.

## Gerando uma chava assimetrica.

var key = Encoding.ASCII.GetBytes(Settings.Secret);
(transforma a chave em BITS).

## Gerando um codigo de settings para guardar a chave.

- Quando é feita essa chave nos SETTINGS, é para nao precisar ficar colocando a chave toda hora, entao ele carrega a chave. (e é um item que se mudar a chave, invalida todos tokens da aplicação)

namespace Shop
{
    public static class Settings
    {
        public static string Secret = "NarutaoTheBrabo123456798";
    }
}