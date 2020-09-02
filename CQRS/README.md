# o que é o CRQS.

CQRS - Command query responsability Segregation
A ideia do CRQS é dizer q tem commands e querys, e que vai separa-los de forma responsavel.

O **CQRS** são

## Commands: 
    - Representa uma intenção de mudança no estado de uma entidade
    - São expressivos e representam uma unica intenção. 

### EX:

1. AumentarSalarioFuncionarioCommand
    - Se vai aumentar o salario, existe um comando, para coloca-lo de ferias, existe um comando.

    - Ou seja, ele tem um função bem definida, e provoca uma mudança no estado.

## Queries: 
    -É uma forma de obter dados de um banco ou origem de dados para atender as necessidades da aplicação (forma de consulta simples).


## Diferença entre CQRS E CQS

Os principios dos dois, sao iguais, porém o **CQS = Command Query Separation**, a ideia do CQS, é mais simples.
