É um serviço de nuvem que pode ser usado para criar e testar automaticamente o código, e disponibiliza-lo para os Usuarios

- O Pipeline combina
    - Continuous Integration (CI)
    - Continuous Delivery (CD)

### **Resumo do Ciclo do pipéline**

    - Código passa pelo PR, roda o build
    - Durante o Build gera o Pipeline
    - feito a entrega da Release, onde é feita a Entrega Continua para o servidor

## Existem duas formas de criar o Pipeline

1. Forma clássica onde é criado o ciclo de geração do artefato de forma visual atraves de uma interface simples e fácil de usar inicialmente

2. Opção via YAML, definindo os pipelines com a sintaxe