# Max e Min

São utilizados para quando quiser selecionar e limitar valores minimos e maximos dentro da tabela.

Para utilizar é simples, basta utilizar Max(valor que deseja) ou min(valor que deseja)

Porem, se usar igual na explicação acima, ele traria apenas 1 valor mesmo se tiver dois valores altos iguais.

Vamos supor que tenho dois valores iguais tanto menor quanto para maior, se eu utilizar o *Max* ou o *Min* eles vao me trazer apenas 1 desses valores.

Exemplo, tenho dois valores de 1500 com Ids de "venda" diferentes (sendo eles os maiores valores), ele vai me trazer apenas 1 deles.

Para que eu consiga trazer uma lista de todos os valores maiores ou menores, mais algumas informações, vou utilizar como no exemplo abaixo

```SQL
select * from venda
where ValorVenda = (select max(ValorVenda) from venda);
```
O exemplo acima fica igual a imagem abaixo.

![image](https://user-images.githubusercontent.com/58439854/108892265-6dd0d180-75ee-11eb-9ee3-7354a38c4aa3.png)

