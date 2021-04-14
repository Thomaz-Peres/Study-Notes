# Entendendo Extensions e como funcionam

## O que são os extension methods ? 

Os métodos de extesão permitem que você "adicione" tipos existentes sem criar um novo tipo derivado, recompilar ou, caso contrário, modificar o tipo original. Os métodos de extensão, são métodos estaticos(static), mas são chamados como se fossem métodos de instância no tipo entendido. Para o código de cliente escrito em C#, não há nenhuma diferença aparente entre chamar um método de extensão e os métodos definidos de um tipo.

## Resumidamente

O extension methods, nada mais é que objetos/métodos criados, para manter os ja existentes, e fazer um novo e reutilizar sem precisar recriar o objeto. Podemos pensar de uma forma **Não sei a implementação dele, porém preciso de uma implementação dele de uma seguinte forma**