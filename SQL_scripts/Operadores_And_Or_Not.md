# Operadores And, Or e Not

Esses são os 3 operadores principais utilizados no SQL.

Eles funcionam iguais ao C#, &&(AND) ||(OR) ou !=(NOT) 

Porem seria para pesquisas, como no exemplo abaixo, que vou receber um select onde a data de nascimento nao é nulla, e o id é maior que 3

```SQL
-- No exemplo abaixo os dois tem que receber true

select * from cliente where Nascimento is not null AND ClientID > 3
```