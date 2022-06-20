# [O que é Docker ?](#docker)
# [DockerFile](#docker-file)
# [Docker Image](#docker-image)
# [Containers](#entendendo-containers)
# [Docker Compose](#docker-compose-1)
# [Docker Swarm](#docker-swarm-1)


## Docker

é uma plataforma aberta para criação, execução e deploy para os *Containers* a partir da imagem.

## Docker File

Escrevemos o que precisamos na imagem, tudo o que a aplicação necessita escrevemos no *Docker File*

## Docker Image

Um template que contém todos os dados e meta-dados necessários para rodar o *Container*

## Entendendo containers

Forma de empacotar uma ou mais aplicações e suas dependencias de forma padronizada

***OBS***: é criado a partir das imagens

- menos recursos físicos, um container não tem tood o SO apenas o que necessita
- menor tamanho
- inicialização mais rápida
- atualizações simplificadas
- problemas de deploy menor

## Docker Compose

Podemor definir as aplicações usando diversos containers, exemplo:

```Criar um container para o banco de dados e outro para a aplicação WEB e todos descritos no``` **Docker Compose**

## Docker Swarm

ferramenta onde podemos orquestrar em clusters os containers, similar a Kubernetes