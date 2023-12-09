# na pratica no arquivo aula09.cs

## Operadores de Bitwise ou Shits
- Servem para deslocar bits dentro de variaveis inteiras


### Bitwise direita e esquerda

- bitwise para a esquerda DOBRA o valor 
- bitwise para a direita divide pela METADE o valor 

### EXEMPLOS desdobramento para a esquerda 

BITS         | VALOR
------------ | -----
00001010     |   10

- Ao fazer uma operação de Bitwise para a esquerda (significa q vou deslocar os 5 ultimos bits para a esqueda )

BITS         | VALOR
------------ | -----
00010100     |   20

### EXEMPLOS desdobramento para a direita

BITS         | VALOR
------------ | -----
00011010     |   26

- Ao fazer uma operação de Bitwise para a direita ( Desloca os 5 ultimos bits para a direita e praticamente elimino o ultimo bit )

BITS         | VALOR
------------ | -----
00001101     |   13




### Explicando para mim

-. PARA A ESQUERDA EU TIRO 1 ZERO DO COMEÇO E ADICIONO 1 NO FINAL
-.. isso se for para <<1
-... se eu quiser dobrar <<2, eu tiro dois zeros e adiciono no final

BITS         | VALOR
------------ | -----
00000010     |   2


- se refere a 1 BIT PARA A ESQUERDA

BITS         | VALOR
------------ | -----
00000100     |   4

- se refere a 2 BITS PARA A ESQUERDA

BITS         | VALOR
------------ | -----
00001000     |   8


-. PARA A DIREITA EU TIRO 1 ZERO DO FINAL E ADICIONO NO COMEÇO
-.. isso se for para >>1
-.. se eu quiser tirar >>2, eu tiro dois zeros do final e adiciono no inicio.

BITS         | VALOR
------------ | -----
00010100     |   20

- se refere a 1 BITS PARA A DIREITA

BITS         | VALOR
------------ | -----
00010100     |   4

- se refere a 2 BITS PARA A DIREITA

BITS         | VALOR
------------ | -----
00001000     |   8