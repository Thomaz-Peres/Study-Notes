# SQL Server pelo docker

1. instalando a imagem do mssql
    - docker pull microsoft/mssql-server-linux

2. Criando um **"servidor"**
    - docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=dS47222381*' -p 1433:1433 --name sqlserver -d microsoft/mssql-server-linux