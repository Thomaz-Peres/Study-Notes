A utilização do hexadecimais é a facilidade de conversão do binário para o hexadecimal e vice-versa. E também por que fica mais enxuto, logo mais facilidade na hora de ler e entender

hexadecimais: base de 16 digitos, seguem eles em binários.

Decorar:

0: 0000
1: 0001
2: 0010
3: 0011
4: 0100
5: 0101
6: 0110
7: 0111
8: 1000
9: 1001
a: 1010
b: 1011
c: 1100
d: 1101
e: 1110
f: 1111

16 bits em hexadecimais sao 2 bytes e se representam com 4 digitos:
16-bits - 0x906A

8 bits ou 1 byte se representa com 2 digitos:
0-bits - 0x09

Exemplo de um HELLO WORLD em um txt simples
![image](https://github.com/Thomaz-Peres/Theme/assets/58439854/f33ff2d0-75c2-4588-88ac-708f27124400)

Quando utilizamos `xxd -b` ele nos retorna o `HELLO WORLD` escrito em 8 bits (maiusculo e minusculo importa).

Quando utilizazmos o `xxd` ele nos retorna o `HELLO WORLD` em tabela HEXADECIMAL, exemplo:

OBS: cada 2 letras são 2 bytes

4845 4c4c 4f20 574f 524c 440a

48 = H
45 = E

4c = L
4c = L

4f = O
20 = space

57 = W


Para entender mais procure por tabela HEXADECIMAL
