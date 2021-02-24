# Operador Like

O operador like funciona de uma maneira diferente, ele possuiu dois *caracteres coringa*: **%** e **_**

% = Especifica qualquer caractere (0 1 ou multiplos)

_ = Especifica q quantidade de caracteres a partir de um ponto

### Exemplos de %:

```SQL
-- Nessa primeira consulta, a pesquisa tem que começar com a letra "B", e depois pode ter qualquer caractere, independente da quantidade de caracteres
select * from cliente where NomeCliente like ('b%');

-- Nessa segunda consulta, eu quero que termine com a letra "O", independente de quantos caracteres tiver antes
select * from cliente where NomeCliente like ('%o');

-- Nessa terceira consulta, eu quero que ele comece com "B" e termine com "O", independete de quantos caracteres tiver entre eles
select * form cliente where NomeCliente like ('b%o');
```

### Exemplos de _:

```SQL
-- Nessa primeira consulta, a pesquisa tem que começar com "B", e ter apenas dois caracteres depois dele
select * from cliente where NomeCliente like ('b__');

-- Nessa segunda consulta, a pesquisa so vai procurar resultados/dados, que possuem 5 caracteres
select * from cliente where NomeCliente like('_____');
```