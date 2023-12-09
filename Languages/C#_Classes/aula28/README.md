# classe é um tipo de classe composto por membros.
## seus membros sao as propriedades da classe, e os metodos, que sao as funçoes

# classe é um dado composto onde eu instancio objetos da classe, ela quem define as regras e os comportamentos da classe.
## a partir de uma classe, posso instanciar quantos METODOS forem necessarios, e os METODOS, sao independentes um do outro. 

### Modificador de classe é quem define a visibilidade da classe (public void NOME_CLASSE)
### tipos de modificadores 🔽 :arrow_down_small:

- public: Publica , sem restricao de visualizaçao
- abstract: Classe-base para outras classes, nao podem ser instanciados objetos desta classe
- sealed:  Classe nao pode ser herdada
- static:  Classe nao permite a instanciação de objetos e seus membros devem ser static.

# dentro das classes tem as variaveis, onde temos o espicificador de acesso (public int NOME VARIAVEL)


### Especificador de acesso : onde um menbro da classe pode ser acessado
- public: Sem restrição de acesso
- private: So pode ser acessado pela propria classe
- protected: podem ser acessados na propria classe e nas classes Derivadas
- abstract: os métodos nao tem implementação somente os cabeçalhos (utilizado em classes pai como base)
- sealed: o metodo nao pode ser redefinido
- virtual: o método pode ser redefinido em uma classe derivada
- static: o método pode ser chamado mesmo sem a instanciação de um objeto.
