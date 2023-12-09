**K = kubectl


Comando mostra os logs ao rodar a api no pods
- ```k --v={número da fila do serviço} logs {nome-serviço}```

ex :
    
    k --v=1 logs checkout-api-6d47c8f865-zwjkz

![image](https://user-images.githubusercontent.com/95287311/198115578-15b2dbec-0714-4d49-a391-34ffecb9180c.png)

---


Comando mostra a configuração completa do kubernetes com os contextos conectados
- ```k config view```
---

Comando mostra os contextos possiveis para mexer
- ```k config get-contexts```

---

Comando para configurar qual o contexto que quer utilizar
- ```k config use-context {context-name}```