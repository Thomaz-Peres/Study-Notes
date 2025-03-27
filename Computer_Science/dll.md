DLL = Dynamically linked library.

Coleção de funcionalidades que podem ser compartilhadas por vários programas e que o `SO` carrega na memória quando socilitado pelo programa.


Digamos que tenha uma DLL que conecta com TCP (trumpet winsock no WIN 3.11 por exemplo) e um APP precisa chamar a internet, o app chama a DLL executa e descarrega.

Isso não necessariamente deixa o código mais rápido, na verdade tende a deixar um pouco mais lento (normalmente não é nada perceptível).

A vantagem é reduzir o tamanho de vários programas ao centralizar o código que implementa funcionalidades que serão usadas por muitos programas diferentes.
