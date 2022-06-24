# Qual a importância do CD/CD para o Banco de Dados ?
    - Comentar o código do banco de dados para o sistema de controle de versão e integração continua.
    - Adicionar testes unitarios ao seu banco de dados.
    - Gerenciamento de versões para banco de dados através da entrega contínua.
    - Monitorar o código do banco, ramificando e mesclando o código do banco de dados, dependências cruzadas (atualizando varios bancos de dados e realizando tratamento de erros)


# Ciclo de vida da aplicação como banco de dados

Circulo de vida:
    - Planejamento
    - Contiamos com código no repositorio.
    - Porém agora temos as instruções do banco de dados geralmente disponiveis atraves do arquivo ```.SQL```
    - Build

Nas Releases:
    - Começamos a executar ações no servidor e iremos efetuar a entrega.

### Desafios de deploy do Banco de Dados

- Dados persistentes durantes as atualizações.
- Configuração do Banco de Dados.
- Configurações de Segurança.