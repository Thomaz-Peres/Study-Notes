# Entendendo o comportamento de **OnDelete**

- O comportamento do OnDelete funciona para mostrar como a entidade será excluida, no caso a entidade **school que tem varios alunos, e os alunos tem 1 escola**.

![image](https://user-images.githubusercontent.com/58439854/101837065-3db08100-3b1d-11eb-858c-2deff3abf692.png)

## Exemplos de OnDelte 1:N

- Nao posso excluir uma escola se ela tiver alunos, logo **:**

```CSharp
.OnDelete(DeleteBehavior.Restrict);
```

## Exemplos de OnDelte 1:1

- Nao posso excluir uma escola se ela tiver alunos, logo **:**

```CSharp
modelBuilder.Entity<School>().HasOne(s => s.ContactInformation).WithOne()
    .HasForeignKey<ContactInformation>(s => s.SchoolId);
```