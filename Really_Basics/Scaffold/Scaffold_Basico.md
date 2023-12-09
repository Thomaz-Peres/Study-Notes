# O que é Scaffold ? (texto e explicação tirado de: https://pt.stackoverflow.com/questions/119731/o-que-é-scaffold)

- Scaffold é um pré-moldado. O termo vem emprestado da construção civil. A técnica de conversão do Scaffold em um elemento da arquitetura ASP.NET MVC é chamado de Scaffolding.

Scaffold é uma técnica antiquíssima de geração de código baseado em gabaritos de operações comuns que costumam ser usadas em aplicações diferentes.

Ao contrário do que muita gente acredita, provavelmente fruto de ter aprendido por receita de bolo, existem várias técnicas para obter o resultado final.

É possível realizar isto em tempo de execução ou em tempo de desenvolvimento, gerando códigos fontes que são agregados ao projeto como se fossem escritos por uma pessoa.

Esta técnica usa uma especificação em algum lugar para gerar todo o código necessário baseado em gabaritos de código preestabelecidos em algum lugar. Esta especificação pode ser direta ou indiretamente obtidas do banco de dados, das classes do modelo ou outra forma (um arquivo XML/JSON ou formato especifico auxiliar ou mesmo um banco com um dicionário de dados*, por exemplo). O resto é gerado pela ferramenta de scaffolding.

A técnica é mais bem empregada quando este mesmo dado é usado em vários pontos do código, mas mesmo em outras situações ele pode ser útil, inclusive gerando códigos para alguns padrões de projeto mais conhecidos.

Também, ao contrário do que muita gente pensa, ele não é só usado para fazer CRUD, ainda que seja em um ponto onde a técnica seja bem empregada.

A ferramenta é uma ótima auxiliar para obter o DRY.

Com o C# 7 e o Visual Studio 15 iniciaram incentivos às técnicas de scaffolding. E no C# 10 deve ter mais ainda com a adição de Source Generators (ainda que seja usado para algo além de scaffold.

Uso com MVC
O MVC é um padrão de projeto que propõe a criação de 3 camadas, principalmente o modelo e a visão normalmente estão fortemente ligadas ao conteúdo do banco de dados. Ou seja, as colunas do banco de dados são os membros de uma classe do modelo e serão os controles da tela na visão. Há uma relação de um para um. É óbvio que não faz sentido você ter cada uma destas partes dissonantes entre si. E é claro também que o MVC não precisa necessariamente usar um database como fonte de dados, isto depende da ferramenta utilizada. a estrutura do banco de dados pode até mesmo ser gerada pela ferramenta de scaffolding.

Em alguns casos o controlador pode ter alguma coisa bem padronizada, principalmente quando se trata de CRUD. E isto pode ser gerado pela ferramenta de scaffold, em alguns casos aproveitando a mesma fonte de dados das demais partes.

Então no MVC você tem pelo menos 3 locais, ou mais, com código bem burocrático, que podemos chamar de boilerplate, que se repete em todas as aplicações só variando os "campos" que serão utilizados. Sua estrutura básica é a mesma, não importa em que linguagem, que tipo de aplicação, padrão de projeto ou tecnologia que está sendo aplicado.

Normalmente sempre preferi a geração feita em tempo de execução, até pelo tipo de aplicação que costumo trabalhar, mas para o ASP.NET MVC vejo mais comum a geração durante o desenvolvimento, e ultimamente tenho visto algum valor nisto.

ASP.NET MVC
É possível adotar várias ferramentas de scaffolding com o ASP.NET MVC. Pode-se criar a sua própria, mas a maioria usa a ferramenta pronta mais atual disponibilizada pela Microsoft.

O ASP.NET MVC já possui boas ferramentas integradas com o Visual Studio e permite bastante personalização. Em geral elas funcionam melhor com Entity Framework usando o modelo como especificação para o resto. Lembrando que o modelo pode ser gerado usando como base o banco de dados, conforme confirma outra resposta, contradizendo os comentários que geraram negativos na minha resposta. Cito especificamente o trecho "pode ser qualquer outro elemento que alimente a cadeia de geração de código" e complemento que um desses elementos é o banco de dados, mesmo que isto seja feita de forma indireta.

Como a ferramenta utiliza pelo ASP.NET MVC é integrada com o EF ela pode gerar os códigos (incluindo SQL) necessários para manter o banco de dados em sincronia com a aplicação.

Então a ferramenta mantém a sincronia entre DB-Model-View (HTML/JS).

Toda esta descrição e liberdade de fonte de dados da especificação e de resultado final fica ainda mais evidente com a ferramenta moderna de scaffolding Yeoman. Certamente o tempo fará ela abrir a mente de quem está acostumado com apenas uma ferramenta de scaffolding.

*Dicionário de dados é algo existente há décadas, mas que não pegou tração no mercado. Como tudo que não é muito falado é ignorado pela imensa maioria da pessoas. Esta é um ferramenta poderosíssima para documentar de forma ativa o que o software trabalha e principalmente subsidiar a automação da criação de códigos, justamente o scaffolding. Se isto fosse melhor divulgado haveria um ganho de produtividade enorme para muita gente, abrindo uma janela de oportunidades e nova forma de desenvolvimento de software evitando o trabalho burocrático que toma a maior parte do tempo dos programadores. Por isso eu reforço que é preciso ser criativo, buscar o que não é mainstream, pensar fora da caixa e olhar a experiência dos outros ao invés de apenas seguir o fluxo, olhar apenas para ferramentas já existentes e repetir o que todo mundo está fazendo sem questionamentos.