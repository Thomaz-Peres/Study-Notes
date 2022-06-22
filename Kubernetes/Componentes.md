# Dentro disso tudo em [```Arquitetura do Kubernetes se divide em 4 pontos principais```](/Kubernetes/Kubernetes.md/#arquitetura-do-kubernetes-se-divide-em-4-pontos-principais)

temos alguns componentes a mais.

* kubernet architeture diagram
![image](https://user-images.githubusercontent.com/95287311/174889079-56c03e8a-4c64-4dc5-8e4c-13de8805e21d.png)

- [ETCD]()

- API SERVER

- Controller Manager

- Workers

- Scheduler

- KubeCTL

- KubeLet

- Kube Proxy

- Controller Manager (Replication Controller, Node Controller, Endpoint Controller, Service Controller)

## Detalhamento dos componentes a mais

Começando pela ``MASTER NODE (MASTER)``

Em um alto nivel consiste em um plano de controle, que nada mais é do que a ***Master***, e ele também precisa de um sistema de armazenamento distribuido para master o estado do cluster consistente, que é onde entra o ```ETCD```.

além disso ele precisa de varios NODES no cluster que podemos chamar de Kubelets (mais adiante)*

### ***ETCD***:
- Nosso banco de dados, responsavel pelo armazenamento de alta disponibilidade de informações. 
- Ele guarda as informações em formato de chaves e valores, esse serviço armazena todos os dados de configuração e estado do cluster.
- É utilizado como armazenamento de apoio para todos os dados do cluster do Kubernetes.
- Ao usa-lo como repositorio de apoio, precisamos ter um plano de backup para esses dados.
- Mais informações : https://etcd.io/docs/

### ***KUBELETS***:
- É o agente executado em cada um dos nodes de um worker quando ele se conecta ao ```DOCKER```
- Tem a resposabilidade de realizar a criação, modificação, execução e exclusão dos Containers.
- O Kuberlet obtém informações da master e garante que todos os ```PODs``` atribuidos a ele estejam em execução e configurados no seu estado desejado.
- Todos os ```nodes``` do Kubernet, devem ter um ***Kubelet***.
- O Kubelet cria um ```POD``` deixando pronto para o container, além de testar e verificar a sua saúde.

### ***Worker Node***:
- É exatamente a representação da imagem anteriormente.
- Contém o ```Kubelet``` visto acima e o ```Kube Proxy```, e se conectam aos ```PODs``` dentro do Docker

### ***Kube Proxy***:
- Observa todos os serviços e mantém a configuração da rede em todos elementos do cluster.
- Encaminha trafego para os containers, com base no endereçamento dos IPs e nos números das portas da solicitação processada.

### ***POD***:
- Nele que rodamos o nosso container *(podemos rodar mais de 1, porém o ideal é rodar apenas 1)*.
- Consiste em um grupo de container implantados em um único ```Worker Node```.
- Conceito crucial no Kubernetes.
- Ponto onde os devs interagem.
- Ele é a menor unidade do Cluster Kubernetes, ja que rodamos o nosso container nela.
- Compartilhar recursos em instruções sobre como executar o container.
- Podem se conectar dentro do Cluster, usando o IP de serviço.
- ```PODs``` possuem vida limitada, e ao reduzir a escala ou atualizar para uma nova versão, o POD pode morrer.
- Podem realizar dimensionamento horizontal, diminuindo ou aumentando o número de instancias.
- Podem realizar o nosso deploy.
- Existem varios tipos de PODs.

### ***API SERVER***:
- Consiste em um servidor de aplicações que fornece as APIs do kubernetes por meio da tecnologia Json.
- Os estados dos objetos desse aplit ficam armazenados no ETCD

### ***KUBECTL***:
- Usa o API server para se comunicar com o cluster.

### ***CONTROLLERS***:

![image](https://user-images.githubusercontent.com/58439854/174905387-6a3280a9-2136-4186-a75a-03e603da5eac.png)

OBS: a imagem é bem parecida com a primeira mas funcionam de maneiras diferentes, antes era a Master Cluster, agora temos a Master Controller Plane

- Cada controller tem um processo diferente.
- Para reduzir complexidade, são compilados em um único binário e em um único processo.

- ***Node controller:***
    - Responsável por notificar e responder quando os Nodes caem.

- ***Replication controller:***
    - Responsável por manter o número correto de PODs para cada objeto de controller e replicação do sistema.

- ***Endpoints Controllers:***
    - Fazem a junção do serviços e PODs.

- ***Service Controller:*** (ou service account e token controller)
    - Cria contas padrões e tokens de acesso a API para novos ingressantes.

- ***Kube Controller Manager:***
    - O  kube controller manager é o componente do master que roda os controladores.
    
- ***Clound Controller Manager:***
    - Permite o código do fornecedor de CLOUD e código de Kubernetes possa evoluir independente um do outro.

#### Kube-api-server    
    - Servidor de API.
    - Componente da master do kubernetes que expoem a API.
    - Pode ser dimensionado horizontalmente (dimensionado com a implantação de mais instancias).
    - Pode executar variás instancias do Kube-Api-Server e equilibrar o trafégo entre elas.

#### Kube-Scheduler

- Componentes da master que observa os PODs recém criado e sem nenhum NODE atribuito e seleciona um NODE para executa-los.
- Leva em conta os requisitos de recursos individuais e coletivos, restrições de Hardware, Software e pólitica, além de especificações de afinidade e anti-afinidade, localidade de dados, interferencia entre cargas de trabalho e seus prazos.

#### KubeCTL
- Ferramenta de linha de código para se comunicar com o servidor Kubernetes API.