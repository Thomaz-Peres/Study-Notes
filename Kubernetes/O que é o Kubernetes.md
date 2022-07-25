# O que é o Kubernetes

Kubernetes de maneira bem resumida é um [orchestrator](/Orchestrator.md/#orchestração-de-containershttpswwwredhatcompt-brtopicscontainerswhat-is-container-orchestration) dos containers

*tarefas que ele gerencia e executa de forma bem macro (dentro do kubernetes é uma estrutura bem maior)*
``` 
É responsavel pela orchestração para implantação, gerenciamento e escala de containers.

Podemos orquestrar um cluster de uma maquina virtual.

Agendar execução de containers nas VMs, levando em conta os recursos de computação disponiveis e nos requisitos de recursos em cada container.

Gerencia automatiamente a descoberta de novos serviços.

Incorpora o balanceamento de carga.

Acompanha a alocação de recursos e dimensiona com base no uso da computação e verifica a integradidade de recursos individuais e permite que aplicativos alto estabeleçam reiniciando ou ate replicando o container automaticamente.

Monitora o aplicativo, e se o container necessitar de mais recursos Kubernetes é responsavel por sumir outros containers e até eliminar containers que não são mais utilizados.
```