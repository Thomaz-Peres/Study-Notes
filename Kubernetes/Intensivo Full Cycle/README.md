
O kubernetes tem um ecossistema que ajuda a gente no dia-a-dia, exemplo:
    
- Vamos imaginar que vou subir uma aplicação, e nessa aplicação quero gerar um arquivo de configuração dinamico, ou seja, em modo de desenvolvimento eu tenho um LOG(tipo um debug) e em modo de produção o LOG é tipo INFO, como setar alguns arquivos que quero gerar dentro da aplicação para a aplicação resolver esses tipos de problemas
        
        O kubernetes permite a gente trabalhar com o ConfigMap
        - No ConfigMap conseguimos criar um arquivo com DADOS no ConfigMap e fazer com que sejam injetados no meu container com o nome de exemplo "wp-config.c#"
        - Toda vez que vai subir o container, o Kubernetes adiciona o WP-config do jeito modificado sem ser necessario alterar a imagem do container
___

- O Kubernetes ajuda a gerenciar as senhas também.
    - Consegue por exemplo, salvar uma senha no kubernetes e recuperar dentro do container
___
- Prove serviços de load balancer
___ 
- Service discovery
        
        Dentro de todos containers rodando (dentro do seu Cluster), quando alguem cair no seu load balancer, como ele sabe para qual container ele vai mandar o trafégo ? Como que o Kubernetes vai entender que uma API com duas replicas são caras do mesmo tipo ? Ou que uma api é diferente da outra ?
    - Os recursos do service Discovery consegue um registro dentro dele com todos containers no ar e saber quais containers estão saudaveis e baseado nisso quando alguém for acessar qualquer serviço, ele sabe pra qual container enviar.

- O Kubernetes permite que extendamos a partir do kubernetes, mecanismos como algo chamado de service mesh (vou pesquisar mais sobre quando tiver melhor com Kubernetes)
    - Além disso, consigo colocar sistemas que fazem gerenciamentos e coletas de LOGs configurados no kubernetes, Exemplo: [Prometheus](#prometheus)

- O kubernetes consegue resolver nomes e padrões de nomes (URLs)
    - Exemplos:
        ```
        Se o usuario acessar /home ele é redirecionado para a API 1 
        Se acessar /produtos é redirecinado para a API 2
        ```
    - Além disso consegue nesse caso, a possiblidade de rodar o site com TLS/SSL
    
    ## ```Prometheus```
        No prometheus, conseguimos fazer ele pegar todas as informações que estão rodando entre todos os containers que estão rodando, pegar as informações gerar as informações em formato de LOGs para conseguir métricas


O kubernetes trabalha sempre de forma distribuida, quando temos um Node1 (maquina 1), Node2 (maquina 2), Node3 (maquina 3), temos um POOL de Nodes.


O kubernetes não tem controle do container em si, ele sabe como o container está se comportando mas para conseguir gerenciar esses containers ele precisa de algo que envolva o container, os chamados PODs

POD = é uma unidade do kubernetes onde ele coloca os containers la dentro, então sempre que for falado que tem um container rodando no kubernete, ele precisa estar rodando em um POD ***O POd pode rodar mais de um container dentro dele, mas é extremamente recomendavel rodar apenas 1 container por POD***

O kubernete verifica se o POD está com saúde suficiente pra rodar o processo que o container trabalha

Se o container crashar a a memoria por exemplo, o POD envia para o kubernetes dizendo que não esta saudavel, assim o kubernete mata esse POD não saudavel e sobe um novo POD no lugar.

O kubernete também gerencia quantos PODs ele vai rodar. Ele cria baseado naquilo que dizemos para ele.

```
Vamos imaginar que em algum momento eu quero rodar dois PODs rodando um container A, temos dois PODs com containers A.   Então temos um POD 1 com container A e um POD 2 também com container A.

Digamos que o POD 2 deu problema se eu deletar ou ele ir embora, o POD não ira ser recriado automaticamente. O POD é um objeto que tem um container rodando dentro dele e ele não se recria automaticamente, então se você deletar o POD acabou.

E as vezes queremos ter os dois PODs, e quero falar para o Kubernetes que se um POD morrer cria ele de novo automaticamente.

O que ajuda a fazer isso automaticamente pra garantir que terei a quantidade de PODs que eu quero, é chamado de ReplicaSet.
```

# ReplicaSet
- O ReplicaSet fica o tempo todo olhando a quantidade de PODs que estão no ar. Então no caso explicado acima, posso criar um ReplicaSet do container A falando que quero o tempo todo 2 PODs rodando. Então se um POD caiu, ele cria outro automaticamente.

- O ReplicaSet também guarda a versão da imagem do container.

O que acontece se quiser subir o Container A com a versão 2.0.

- Como o ReplicaSet fica focado baseado na versão anterior, então mesmo se matar um dos PODs dentro dele, ele não vai criar na versão nova desejada.
___ 
- Podemos ter um cara que fica acima do ReplicaSet que nos ajuda em relação as atualizações de versões, esse cara é chamado de ```Deployment```
___ 
- Quando for criar e fazer por padrão o deploy da aplicação e garantir que a cada nova versão gerada, automaticamente ele vai matar os PODs com a versão antiga e subir os POds com a versão nova e que também consiga garantir o número de Replicas que estou esperando dos PODs, acabamos trabalhando com o Deployment, o Deployment por debaixo dos panos o ReplicaSet onde escolhemos a quantidade de Replicas, que também ele vai escolher qual imagem ele vai trabalhar pra conseguir criar os PODs.

## Como fazer pra se conectar na API/SITE que esta rodando no container

Tudo que foi feito ate agora foi ate a metade do caminho, por que para darmos acesso para que outro sistemas, outras pessoas e etc, consigam ter acesso a esse Site/API. A gente precisa de um ```SERVICE```.

O ```Service``` gera a possibilidade de ter acesso aos nossos PODs.

Vamos supor que tenha dois ```Container A``` e tenho uma tag/label chamado de ```app:back```
![image](https://user-images.githubusercontent.com/58439854/180626416-bf553ffb-f74f-4b7b-a862-f392c50c44cf.png)

Agora vamos imaginar que temos outro ```Deployment``` contendo os containers do Front.
![image](https://user-images.githubusercontent.com/58439854/180626450-62796807-6411-4616-8adf-02246d1a312a.png)

1. Como que a gente acessa um ou outro ?
    - Precisa de uma regra, e é por conta disso que configuramos um Service.

Quando configuramos o service, usamos um "selector", e esse selector que vamos trabalhar vai ser por exemplo, o ```app:front```. E quando isso é configurado no Service, o service avisa pro Kubernetes que você quer acessar qualquer POD que contém o selector especificado.

Com o ```service``` conseguimos ter algumas possibilidades, por exemplo conseguimos:
- Gerar um IP Interno.
- Gerar um IP externo.
- Disponibilizar um porta

Podemos ter varios PODs, o proprio kubernetes entende o número de PODs que você tem e a cada hora ele randomiza com um algoritmo pra trabalhar com randomização de tipo de balanceamento chamado de "RoundRobin" e cada vez ele faz o service enviar para um POD diferente (lembrando que ele envia para PODs diferentes que contém o mesmo container e selector) assim diluindo o processamento/memoria, já que cada hora cai em um, conseguindo escalar o processo.

Um desenvolvedor não precisa aprender a gerenciar Cluster, mas precisa saber fazer um deployment via Kubernetes

Quando trabalhamos com o kubernetes e vamos coloca-lo em produção, podemos colocar o Kubernetes em um formato mais on-premises, onde a gente cria a maquina, instalamos o kubernetes e gerencia tudo ou instalamos o Kubernetes em serviços gerenciaveis, AWS, Azure, Google.


Pra não ter que ficar criando maquinas e gastando pra criar o kubernetes, a gente pode utilizar algumas soluções para rodar local, duas soluções (conseguimos instalar o Kubernetes local na maquina pessoal):
- MiniKube.
- Kind (simula o Cluster kubernetes utilizando o Docker da maquina, cada Cluster é como se fosse um container).


Kubectl apply -f k8s/deployment.yaml = aplicando o conteudo do arquivo dentro do kubernetes
    - Quando ele cria, e você procura saber se gerou certo, pode usar o Kubectl get pods.


service LoadBalancer
- Quando cria um service com LoadBalancer, ele cria um Ip que externamente a gente consegue acessar o cluster (um IP externo).
- Independente se especificar o tipo ```Type: LoadBalancer```, qualquer serviço que acessar no Kubernetes, ele balanceia a carga automaticamente pra qual POD ele vai cair.


O kubernetes permite que a gente faça um encaminhamento de porta para que a Maquina se conecte com o Kubernetes atraves de uma porta (tipo como acontece com o Docker)


Como se conectar internamente do seu computador para o Kubernetes 
- kubectl port-forward service/{nome-service-desejado} {porta-do-service}:{porta-maquina-local}
- Agora no seu proprio computador, consegue acessar o serviço criado que está no kubernetes


# ferramentas que ajudam quando estamos trabalhando com Kubernetes

- LENS
    - conseguimos escalar
    - Entrar nos PODs
    - Rodar comandos
    - Consigo ter acesso a informações necessárias
    - Instalar charts do Helm
    

# Aprender mais
- Secrets
- ConfigMap
- Diferenças entre Deployments e StateFul Sets
- Aprender a trabalhar com namespace
- Service Accounts
- Helm