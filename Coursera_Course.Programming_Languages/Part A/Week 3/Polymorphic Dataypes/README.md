
# Polymorphic Datatypes

Other than the strange syntax of **[]** and **::**, the only thing that distinguishes the built-in lists and options from our example datatype binding is that the built-in ones are ***polymorphic*** - they can be used for carrying values of any type.


It is very useful for building "generic" data structures.

While we will not focus on using this feature here (i.e., you are not responsible for knowing how to do it), there is nothing very complicated about it. For example, this is
exactly how options are pre-defined in the environment:

```sml
datatype 'a option = NONE | SOME of 'a
```

Such a binding does not introduce a type option. Rather, it makes it so that if t is a type, then t option is type. You can also define polymorphic datatypes that take multiple
types. For example, here is a binary tree where internal nodes hold values of type ’a and leaves hold values of type ’b

```sml
datatype ('a, 'b) tree = Node of 'a * ('a, 'b) tree * ('a. 'b) tree
                        | Leaf of 'b
```

PT|BR 
Então, temos tipos como árvore (int,int) (em que cada nó e folha possui um int) e árvore (string,bool) (em que cada nó possui uma string e cada folha possui um bool). A maneira como você usa construtores e correspondência de padrões é a mesma para tipos de dados regulares e tipos de dados polimórficos.

EN|US
We then have types like (int,int) tree (in which every node and leaf holds an int) and (string,bool) tree
(in which every node holds a string and every leaf holds a bool). The way you use constructors and patternmatching is the same for regular datatypes and polymorphic datatypes



I ask for a help for a chatGPT, that is what he give me (in portuguese, if you is a guy who droped here and read in english, ask for chatGPT to translate to EN):
```
Essa sentença técnica é lida como a definição de um tipo de dados em linguagens de programação que suportam a definição de tipos de dados algébricos. A definição descreve uma árvore binária que contém nós e folhas.

Em termos mais específicos, a definição começa com a palavra-chave "datatype", seguida pelo nome do tipo de dados (neste caso, "(’a,’b) tree"). Em seguida, a definição enumera os possíveis construtores para o tipo de dados: "Node" e "Leaf".

O construtor "Node" é definido como uma tupla que contém um valor do tipo 'a e duas subárvores do mesmo tipo. O construtor "Leaf" é definido como um valor do tipo 'b.

Essa definição é útil porque permite que os programadores criem instâncias de árvores binárias usando os construtores definidos e realizem operações nesses valores, como a adição ou remoção de nós e folhas, por exemplo.
```