# Programação Web com ASP.NET Core MVC e Web API

## Funcionamento do Ambiente e Aplicações Web 

### Como funciona uma Aplicação Web? 
- O que é um **servidor web**?  
- Diferença entre **Frontend e Backend**.  
- O papel do **HTTP** na comunicação cliente-servidor.  
- O conceito de **requisições e respostas**.  

**Exemplo prático:**

Abra o **Prompt de Comando** e execute:  
   ```sh
   curl -X GET https://jsonplaceholder.typicode.com/posts/1
   ```

Você deverá receber algo parecido com isso:
```sh
{
  "userId": 1,
  "id": 1,
  "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
  "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
}
```

## Introdução ao ASP.NET Core MVC 

### O que é o ASP.NET Core MVC?
- Framework para criação de **aplicações web robustas**.  
- Padrão **Model-View-Controller (MVC)**.  
- Benefícios: **modularidade, separação de responsabilidades e escalabilidade**.  

### Criando um Projeto ASP.NET Core MVC 
Execute o seguinte comando no terminal:  
```sh
dotnet new mvc -n MeuProjetoMVC
cd MeuProjetoMVC
code .
```
Agora, execute o projeto:  
```sh
dotnet run
```
- Acesse `https://localhost:porta` e veja a aplicação rodando.  

## Métodos do Protocolo HTTP

### O que é o HTTP?  
- **GET** → Buscar dados.  
- **POST** → Enviar dados.  
- **PUT** → Atualizar dados.  
- **DELETE** → Remover dados.  

### Testando Requisições com API Client Lite
1. Baixe a extensão **API Client Lite** no VS Code.  
2. Faça uma requisição **GET** para `https://jsonplaceholder.typicode.com/posts`.  
3. Faça um **POST** para criar um novo post.  

```json
GET https://jsonplaceholder.typicode.com/posts HTTP/1.1

###

POST https://jsonplaceholder.typicode.com/posts HTTP/1.1
content-type: application/json

{
    "userId": 1,
    "id": 7,
    "title": "xablau",
    "body": "A verdade é uma grande mentira."
}
```

---

## **📌 Aula 4: Criando uma Web API no ASP.NET Core**  

### **1️⃣ O que é Web API?**  
- API que retorna dados **sem interface gráfica**.  
- Normalmente, retorna **JSON**.  

### **2️⃣ Criando um Projeto Web API**  
```sh
dotnet new webapi -n MeuProjetoAPI
cd MeuProjetoAPI
code .
```
Agora, execute a API:  
```sh
dotnet run
```
A API já está funcionando no **localhost**! 🚀  

### **3️⃣ Criando um Controller de Produtos**  
No diretório `Controllers/`, crie `ProdutoController.cs`:  
```csharp
using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoAPI.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = new List<object>
            {
                new { Id = 1, Nome = "Notebook", Preco = 5000 },
                new { Id = 2, Nome = "Mouse", Preco = 100 }
            };
            return Ok(produtos);
        }
    }
}
```
**🔹 Teste no navegador:**  
Acesse `https://localhost:5001/api/produtos` e veja o **JSON retornado**.  

---

## **📌 Aula 5: REST e JSON**  

### **1️⃣ O que é REST?**  
- **REST (Representational State Transfer)** é um estilo arquitetural para **APIs web**.  
- Baseado em **recursos** (`/api/produtos`).  
- Usa **métodos HTTP** para interagir com os dados.  

### **2️⃣ JSON: O Formato de Dados das APIs**  
- Estrutura de chave-valor.  
- Suporta **listas e objetos aninhados**.  

**🔹 Exemplo JSON:**  
```json
{
  "id": 1,
  "nome": "Notebook",
  "preco": 5000
}
```

---

## **📌 Aula 6: Trabalhando com Models e Controllers**  

### **1️⃣ Criando um Model de Produto**  
No diretório `Models/`, crie `Produto.cs`:  
```csharp
namespace MeuProjetoAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
```

### **2️⃣ Alterando o Controller para usar o Model**  
```csharp
using Microsoft.AspNetCore.Mvc;
using MeuProjetoAPI.Models;
using System.Collections.Generic;

namespace MeuProjetoAPI.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 5000 },
            new Produto { Id = 2, Nome = "Mouse", Preco = 100 }
        };

        [HttpGet]
        public IActionResult GetProdutos()
        {
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            produtos.Add(produto);
            return Created("", produto);
        }
    }
}
```
### **3️⃣ Testando com o Postman**
1. **GET** → `https://localhost:5001/api/produtos`
2. **POST** → Envie este JSON:
```json
{
  "id": 3,
  "nome": "Teclado",
  "preco": 200
}
```

---

## **📌 Aula 7: Conclusão e Exercício Prático**  

### **🎯 Exercício**
- Crie um **novo endpoint** `DELETE /api/produtos/{id}` para excluir um produto.  
- Adicione um **novo Model chamado Cliente** com os campos `Id`, `Nome` e `Email`.  
- Crie um **novo Controller** `ClienteController` que tenha um método `POST` para cadastrar clientes.  

### **📌 Revisão Final**
✅ Funcionamento das aplicações web.  
✅ Criamos um projeto **ASP.NET MVC**.  
✅ Entendemos os **métodos HTTP** e o protocolo REST.  
✅ Criamos **Web API** com **Controllers** e **Models**.  
✅ Manipulamos dados no formato **JSON**.  

🚀 **Agora os alunos estão prontos para desenvolver APIs robustas no ASP.NET Core!** 🚀  

---

Esse roteiro cobre os tópicos com explicações didáticas e práticas. Se precisar de ajustes, me avise! 😉