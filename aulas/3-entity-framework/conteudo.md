# O que é Mapeamento Objeto-Relacional (ORM)?

O **ORM (Object-Relational Mapping)** permite interagir com um **banco de dados relacional** usando **objetos** em vez de comandos SQL diretos.
No **universo de Dragon Ball**, imagine que o **banco de dados** seja a **Grande Enciclopédia dos Guerreiros Z**, onde estão registradas todas as informações dos personagens.
Cada **personagem** (objeto) tem **atributos** como **nome, nível de poder e raça**. O ORM permite que a gente manipule essas informações sem precisar escrever SQL puro.

### 💻 Exemplo: Criando uma classe `Personagem`
```csharp
public class Personagem
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Raca { get; set; }
    public int NivelPoder { get; set; }
}
```
>**Essa classe representa a tabela de personagens no banco de dados!**  

# Introdução ao Entity Framework Core

O **Entity Framework Core (EF Core)** é um ORM para .NET que permite interagir com um banco de dados relacional usando **C#**.
Ele traduz operações em **C#** para comandos **SQL** automaticamente.
Assim como o **Goku** precisa do **Ki** para soltar um Kamehameha, o **EF Core** precisa de um **banco de dados** para armazenar os dados.

Para instalar o **Entity Framework Core** no seu projeto **.NET Core**, siga estes passos:  

### 1️⃣ Instalar o pacote principal do EF Core

```sh
dotnet add package Microsoft.EntityFrameworkCore
```

### 2️⃣ Instalar o provedor de banco de dados

```sh
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

### 3️⃣ Instalar o Entity Framework Core Tools

```sh
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

>Com isso, você pode rodar comandos do EF Core como **migrations** e **database update**.

### 💻 Criando o `DbContext`

O **`DbContext`** é a **classe principal do Entity Framework Core**. Ele atua como uma **ponte** entre a aplicação e o banco de dados, permitindo que você consulte, insira, atualize e exclua dados de forma fácil e eficiente (CRUD da alegria 😀).  

Pense no `DbContext` como um **supervisor** que gerencia o fluxo de dados entre o seu código e o banco de dados.  
Ele rastreia todas as entidades (objetos) e sabe quando **salvar mudanças** ou **buscar informações** no banco.  

**Principais Responsabilidades do `DbContext`**
1. **Gerenciar a conexão com o banco de dados**  
2. **Mapear classes do C# para tabelas do banco**  
3. **Realizar operações CRUD (Create, Read, Update, Delete)**  
4. **Rastrear mudanças nos objetos para atualizar o banco automaticamente**  

Exemplo:

```csharp
using Microsoft.EntityFrameworkCore;

public class DragonBallContext : DbContext
{
    public DbSet<Personagem> Personagens { get; set; } // Tabela Personagens

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=DragonBallZ;user=root;password=senha");
    }
}
```
➡️ **Agora, o EF Core sabe onde armazenar os personagens no banco de dados MySQL!**

---

## **🟢 Aula 3: Conectando ao MySQL**
### **📌 Instalando os pacotes necessários**
Antes de conectar ao **MySQL**, precisamos instalar o **Entity Framework Core** e o **provider do MySQL**:
```sh
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

### **📌 Criando e aplicando a migração**
Agora, vamos **criar o banco de dados** com o comando:
```sh
dotnet ef migrations add CriarBanco
dotnet ef database update
```
➡️ **O MySQL agora tem a tabela `Personagens` criada!**

---

## **🟢 Aula 4: Validações com Data Annotations**
### **📌 O que são Data Annotations?**
- São **anotações** usadas para definir regras e restrições nas classes do Entity Framework Core.
- Imagine que o **Mestre Kame** só aceita treinar **lutadores que tenham nome e nível de poder maior que 1000**. Podemos aplicar isso na classe `Personagem`!

### **💻 Aplicando validações**
```csharp
using System.ComponentModel.DataAnnotations;

public class Personagem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required]
    [Range(1000, 1000000, ErrorMessage = "O nível de poder deve ser maior que 1000")]
    public int NivelPoder { get; set; }
}
```
➡️ **Agora, se tentarmos criar um personagem sem nome ou com nível de poder abaixo de 1000, teremos um erro!**

---

## **🟢 Aula 5: Trabalhando com Collections**
### **📌 O que são Collections?**
- São **estruturas de dados** para armazenar múltiplos objetos em **listas**.
- Exemplo: **A equipe dos Guerreiros Z** é uma **Collection** de personagens.

### **💻 Exemplo de Collection**
```csharp
List<Personagem> guerreirosZ = new List<Personagem>
{
    new Personagem { Id = 1, Nome = "Goku", Raca = "Saiyajin", NivelPoder = 9001 },
    new Personagem { Id = 2, Nome = "Vegeta", Raca = "Saiyajin", NivelPoder = 8500 },
    new Personagem { Id = 3, Nome = "Piccolo", Raca = "Namekuseijin", NivelPoder = 7000 }
};

foreach (var personagem in guerreirosZ)
{
    Console.WriteLine($"{personagem.Nome} tem nível de poder {personagem.NivelPoder}");
}
```
➡️ **Criamos uma lista de personagens e exibimos os detalhes deles!**

---

## **🟢 Aula 6: Consultando Dados com LINQ**
### **📌 O que é LINQ?**
- **LINQ (Language Integrated Query)** permite fazer consultas em listas e bancos de dados usando C#.
- Exemplo: Goku quer **encontrar todos os Saiyajins** para formar um time!

### **💻 Exemplo de consulta LINQ**
```csharp
var saiyajins = guerreirosZ.Where(p => p.Raca == "Saiyajin").ToList();

Console.WriteLine("Saiyajins encontrados:");
foreach (var s in saiyajins)
{
    Console.WriteLine(s.Nome);
}
```
➡️ **Agora conseguimos filtrar os personagens que são Saiyajins!**

---

## **🟢 Aula 7: Expressões Lambda**
### **📌 O que são Expressões Lambda?**
- São funções anônimas que podem ser usadas para simplificar consultas.
- Lembra do **Instinto Superior** do Goku? Ele age rápido sem precisar pensar! Lambda faz a mesma coisa no código.

### **💻 Exemplo de Lambda**
```csharp
var maisForte = guerreirosZ.OrderByDescending(p => p.NivelPoder).First();

Console.WriteLine($"O personagem mais forte é: {maisForte.Nome} com nível de poder {maisForte.NivelPoder}");
```
➡️ **Ordenamos os personagens por nível de poder e pegamos o mais forte!**

---

## **🟢 Conclusão**
- **Usamos ORM** para mapear objetos no banco de dados.
- **Configuramos o Entity Framework Core** para conectar ao MySQL.
- **Aplicamos validações** com Data Annotations.
- **Criamos collections** para armazenar os personagens.
- **Utilizamos LINQ** para consultar dados.
- **Aplicamos expressões Lambda** para consultas rápidas.

### **🛠 Exercício Prático**
➡️ **Crie um CRUD completo para personagens do Dragon Ball no MySQL, incluindo GET, POST, PUT e DELETE!**  

---

### **🔥 E aí, pronto para treinar com os Guerreiros Z no mundo da programação? 🚀🔥**