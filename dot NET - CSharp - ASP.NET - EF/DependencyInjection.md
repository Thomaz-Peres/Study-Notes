Mesma instancia em injecao de dependencia quer dizer que dados serão compartilhados, então se tenho 2 usuarios simultaneos,
teremos dados compartilhados entre todas requicições.

![image](https://user-images.githubusercontent.com/58439854/233747034-9736c882-ab53-4375-8e2b-440fdff838bc.png)
![image](https://user-images.githubusercontent.com/58439854/233747055-26156093-1d9c-4a67-829f-b28e0755c287.png)

## Transient 

Transient objects are always different; a new instance is provided to every controller and every service.

This means that every time an object of this type is injected or requested, a new instance of that object is created.

This lifetime works best for lightweight, stateless services

## Scoped

Scoped objects are the same within a request, but different across different requests.

This means, that objects with scoped lifetime are created once per request and shared across all classes and comoponents within that request.

This lifetime is appropriate for objects that have state and should be shared within a single request

## Singleton

Singleton objects are the same for every object and every request (regardless of whether an instance is provided in `ConfigureServices`).

Singleton lifetime is appropriate for objects that are expensive to create, and need to be shared across the application