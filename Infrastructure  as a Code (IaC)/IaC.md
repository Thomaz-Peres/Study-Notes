# Infraestrutura como código (IaC)

É o nome dado a ação de transformar a infraestrutura em código. (criar um APP Service via código e subir ele via código também)

Scripts onde temos passo a passo o que precisamos para subir o ambiente.

- Ferramentas
    - ARM (azure resource manager)
    - Terraform


# ARM (azure resource manager)

Todos servidos criados no azure pelo portal, sempre gera no final do cadastro, um script em ARM. Esse script é escrito no formato JSON.

- Desvantagens
    - So é possivel utilizar no azure
    - Dificil leitura para humanos

- Vantagens do uso do ARM
    - Criar script a partir de recursos ja provisionados pelo azure.
    - Uso de quick-start.
    - Criar template pelo visual studio de maneira rapida.

# Terraform

Ferramenta declarativa de provisionamento e orchestração de infraestrutura automatizando o provisionamento de todos os aspectos da estrutura corporativa baseado em nuvem e or-primese.

Terraform pode ser usado no azure, amazon e google.

Permite automatizar a criação de recursos em varios servidores em paralelo independete de onde residem os servidores fisicos, servidores DNS ou o banco de dados.

Pode fornecer aplicativos escritos em qualquer linguagem, e com uma usabilidade mais simples do que o ARM. Não oferece recurso de gerenciamento, mas pode trabalhar lado a lado,

O Terraform utiliza uma linguagem proprio chama de HCL (HashiCorp Configuration Language)