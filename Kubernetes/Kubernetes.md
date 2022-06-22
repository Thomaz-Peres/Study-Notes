# Origem do nome Kubernetes e como surgiu o Kubernetes

Kubernetes ou  K8s é uma palavra de origem grega e quer dizer timoneiro

É um sistma de código aberto para gerenciamento de containers. Foi criado em 2003 como uma tecnologia interna do google com o nome de BORG.

O BORG fornecia e gerenciava aplicativos e serviços que ficavam em centanas de milhoes de containers,

2014 o google colocou o projeto no ar e saiu do papel.

2015 kubernetes se tornou código aberto

2020 principais projetos de código aberto no GitHub

Principais serviços de nuvem tem um serviço dedicado para o Kubernetes

# O que é o Kubernetes

Kubernetes de maneira bem resumida é um [orchestrator](/Orchestrator.md/#orchestração-de-containershttpswwwredhatcompt-brtopicscontainerswhat-is-container-orchestration) dos containers

*tarefar que ele gerencia e executa de forma bem macro (dentro do kubernetes é uma estrutura bem maior)*
``` 
É responsavel pela orchestração para implantação, gerenciamento e escala de containers.

Podemos orquestrar um cluster de uma maquina virtual.

Agendar execução de containers nas VMs, levando em conta os recursos de computação disponiveis e nos requisitos de recursos em cada container.

Gerencia automatiamente a descoberta de novos serviços.

Incorpora o balanceamento de carga.

Acompanha a alocação de recursos e dimensiona com base no uso da computação e verifica a integradidade de recursos individuais e permite que aplicativos alto estabeleçam reiniciando ou ate replicando o container automaticamente.

Monitora o aplicativo, e se o container necessitar de mais recursos Kubernetes é responsavel por sumir outros containers e até eliminar containers que não são mais utilizados.
```

# Arquitetura do Kubernetes se divide em 4 pontos principais

OBS: resumo dos componentes, para expadir entre [aqui](/Kubernetes/Componentes.md)

1. Cluster no kubernetes (podemos ter varios)
    - O cluster é um conjunto de componentes na imagem a seguir
![image](https://user-images.githubusercontent.com/95287311/174880236-1145982f-8a2b-4729-99d6-18634b64b630.png)

- **Master** : é a maquina mestre que recebe as configurações decalaradas no arquivo ```.YAML``` e gerencia os ```NODES```. Pode gerenciar 1 ou mais ```NODES```

- **Node** : é uma maquina ativa, dentro do node ficam os serviços necessarios para rodar os PODs, e entre eles temos o proprio ```Docker. o kubernet e o kuberproxy```. Pode conter 1 ou mais ```PODs```

- **Pod** : menor unidade implantada que podemos criar, escalar e manusear, funcionam como uma coleção ótica de container que pertecem a sua aplicação. Pode conter e gerenciar 1 ou mais containers, mas o ideal é sempre 1 container por POD principalmente pelo acoplamento, precisamos manter um container por POD para manter o isolamento entre containers.