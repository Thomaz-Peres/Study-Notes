# Evitando excesso de postagem

Atualmente, o aplicativo de exemplo expõe o TodoItem objeto inteiro. Os aplicativos de produção normalmente limitam os dados que são inseridos e retornados usando um subconjunto do modelo. Há várias razões por trás disso e a segurança é uma importante. O subconjunto de um modelo é geralmente conhecido como um objeto Data Transfer Object (DTO), um modelo de entrada ou um modelo de exibição. O **DTO** é usado neste artigo.

## Um DTO pode ser usado para:

- Evitar sobrepostos.

- Oculte as propriedades que os clientes não devem exibir.

- Omita algumas propriedades para reduzir o tamanho da carga.

- Mesclar grafos de objeto que contêm objetos aninhados. Os gráficos de objeto achatados podem ser mais convenientes para os clientes.