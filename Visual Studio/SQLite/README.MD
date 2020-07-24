# ENTENDENDO O BANCO DE DADOS SQLite

### todos projetos que utilizarem o SQLite, é necessario adicionar o NUGET 

### aprendendo criando uma classe, e dentro dela, implementar as rotinas principais para a utilização do banco de dados

### e diretamente dentro da janela.

### aqui estou aprendendo as duas, CLASSE DE BANCO DE DADOS, E ACESSO DIRETO DENTRO DA JANELA SEM UTILIZAÇÃO DA CLASSE

#### importe de dados na classe using System.Data;
#### using System.Data.SQLite;

#### criando a variavel e o metodo de conexão

private static SQLiteConnection conexao;    //  variavel

- metodo que faz a conexao com o banco

private static SQLiteConnection ConexaoBanco()  //  metodo
{
    conexao = new SQLiteConnection("Data Source = C:\\Users\\AlphaPaiN\\Documents\\dev\\Notes\\Visual Studio\\SQLite\\Banco de Dados\\Banco_academia.db");
    conexao.Open();
    return conexao;
}


## o using engloba todo conteudo dentro do comando 