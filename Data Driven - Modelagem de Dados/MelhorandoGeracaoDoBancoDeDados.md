# Melhorando a geração do banco de dados.

Na pasta **Data**, criar uma pasta de **Mapeamento**.

É criado um arquivo para dizer para o EF(Entity Framework), que quando ele gerar uma categoria, é adicionado qual o tamanho do titulo que vc quer, o tamanho da tabela, a forma do relacionamento

Ao fazer esta melhoria, é necessario herdar do:
```Csharp
IEntityTypeConfiguration<ModelQueDesejaMelhorar>
```
Após isso ele te obriga a utilizar o metodo dentro do código acima.
```Csharp
public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnType("varchar(120)");
        }
```
- builder.ToTable("Category"); = muda o nome da tabela.
- builder.HasKey(x => x.Id) = acha a propriedade **ID** e a coloca como chave.
- builder.Property(x => x.Title) = mapeia o Title, diz que é IsRequired(é obrigatorio).

## Depois de ter feito tudo isso é necessario:

- Voltar para o DataContext e informa-lo que toda vez que ele for criar, ele vai aplicar as configurações fornecidas no ***MAP***
- Então o banco de dados, cria ele baseado nos MAPS

1. **A configuração:**
```Csharp
protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
```

- Qualquer alteração que for feita no **Maps** ou no **Model** vai gerar uma **Migration(migração)** nova, então é necessario rodar denovo o **dotnet ef migration add --nome do migration--**

- Nao se esqueça, depois de criar uma **Migration** nova, é necessario dar um **dotnet ef database update** para atualizar o Banco de Dados