# Analisador sintatico

Analisador sintatico pode ser conhecido/chamado também de `parser`


A partir da sentença/gramatica vamos verificar se eles sao efetivamente válidas ou não.

O conjunto de lexicemas/tokens/simbolos, que conseguimos reconhecer como válidos eles efetivamente obedecem uma regra da nossa gramatica.

Na analise lexica, estamos preocupados em reconhecimento de simbolos, na sintatica estamos preocupados na sequencia desses simbolos

#### Como implementamos analise sintatica

Basicamente um metodo de varredura, ate podemos salvar em memoria porem nao temos condicoes de ficar vendo o fim e/ou inicio, retrocedendo e andando no arquivo, a ideia
é ser sempre uma varredura do inicio ao fim.

Dentro dessa implementação de varredura temos:
- Apenas um método algorítmico (autômatos finitos).

E dentro  da análise sintática temos duas categorias:
- Ascendente
- Descendente


#### Ascendete ou Bottom-up (tem tendencia a ser mais complexa)

Inicia das folhas em direção a raiz.

Se a partir do token final conseguimos inferir o simbolo inicial, o programa esta correto.

#### Descendente ou Top-down

Inicia na raiz da árvore e segue para as folhas.


#### Explicando fluxos.

Dada a gramatica

S::= aS|c

Queremos derivar a cadeia w=aac

Imagem referente a um fluxo descendente

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/e89e8489-04c7-4b6f-bb19-a77464e14afb)

________________________________________

Imagem referente a um fluxo ascendente

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/40dabc42-8818-49c5-acb9-7ec2f62db161)

#### Análise sintática descendente (ASD)

Existem 2 tipos de ASD:
- ASD com retrocesso;
- ASD preditiva:
    - Recursiva;
    - Não recursiva.

##### ASD com Retrocesso

Testa diferentes possibilidades de análise sintática da entrada, retrocedendo se alguma possibilidade falhar;

É um método de tentativa e erro;

A ASD com retrocesso, é mais para conteudo informatico do que de implementação, pois é uma análise inviavel, ja que é lenta e requer em geral, tempo exponencial para execução.

Tambem temos outro problerma, que é a recursividade à esquerda. Sempre entramos em um loop infinito.


##### ASD

So se torna eficiente quando se eliminam retrocessos.

Alem de não serem recursivas à esquerda, as gramáticas devem obedecer duas restriçõesÇ
- Os lados direitos das producoes devem começar por terminais
- Para um não terminal qualquer, não devem existir duas regras que comecem com um mesmo terminal.


![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/a49ff282-2fd1-45b7-93e3-0df25d339f89)

![image](https://github.com/Thomaz-Peres/Study-Notes/assets/58439854/b0989845-c9d3-43ac-8161-a59668978cfb)