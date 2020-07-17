## Conversoes de tipo ou TypeCast

- Operações de typecast é quando precisamos converter tipo, em outro tipo, (INT PARA STRING);


## Conversão implitica

- Conversões implicitas sao seguras e é feita automaticamente
-- Quando nao é seguro é feito as conversões com TypeCast.
- Exemplo passar INT para FLOAT.
- os TypeCasts sao necessarios quando converter um valor não é uma conversão explicita.

## Conversão explicita

float n1 = 10.5;
int n2 = (int)n1;
- no () eu informo para que tipo eu quero transformar o N1.
-- no caso eu estou convertendo o tipo FLOAT para tipo INT.
--- eu perco o valor flutuante, no caso o numero 10.5, vira 10.