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
Execute os seguintes comandos no terminal:  
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
4. Adicione os comandos no arquivo `.http` do seu projeto

```sh
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

## Criando uma Web API no ASP.NET Core 

### O que é Web API?  
- API que retorna dados **sem interface gráfica**.  
- Normalmente, retorna **JSON**.  

### Criando um Projeto Web API  
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

## Configurando o arquivo `Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços essenciais ao container
builder.Services.AddControllers(); // Necessário para suportar controllers

var app = builder.Build();

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS automaticamente
app.UseAuthorization(); // Habilita autorização se necessário
app.MapControllers(); // Mapeia os controllers automaticamente

app.Run();

```

### Criando um Controller de Produtos 
Crie o diretório `Controllers/` e crie `ProdutoController.cs`: 

```csharp
// Importa o namespace necessário para trabalhar com controllers no ASP.NET Core
using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoAPI.Controllers // Define o namespace onde esse controller está localizado
{
    // Define que esta classe é um Controller de API
    [ApiController]
    
    // Define a rota base para esse controller.
    // Quando o usuário acessar "/api/produtos", este controller será chamado.
    [Route("/api/produtos")]

    // Criação do Controller chamado ProdutoController
    // Ele herda de ControllerBase, que é a classe base para APIs no ASP.NET Core.
    public class ProdutoController : ControllerBase
    {
        // Define um endpoint GET que responde na rota "/api/produtos"
        [HttpGet]
        public IActionResult GetProdutos()
        {
            // Criamos uma lista de produtos, onde cada produto é um objeto anônimo
            var produtos = new List<object>
            {
                new {
                    Id = 1,
                    Nome = "Notebook",
                    Preco = 5000,
                },
                new {
                    Id = 2,
                    Nome = "Mouse",
                    Preco = 100,
                },
            };

            // Retorna a lista de produtos no formato JSON com o código de status HTTP 200 (OK)
            return Ok(produtos);
        }
    }
}
```

Agora rode o projeto.

```sh
dotnet run
```

**Teste no navegador:**  
Acesse `https://localhost:porta/api/produtos` e veja o **JSON retornado**.  

## REST e JSON  

### 1️⃣ O que é REST?
`REST (Representational State Transfer)` é um estilo arquitetural para **APIs web**.  

APIs REST são baseadas em quatro conceitos principais:
1. Utilização dos métodos HTTP, como GET, POST, PUT e DELETE, para realizar operações em recursos.
2. Uso de URLs (Uniform Resource Locators) para identificar recursos específicos (`/api/produtos`).
3. Transferência de dados entre cliente e servidor em um formato padrão, geralmente JSON ou XML.
4. Manutenção do estado da aplicação no cliente, em vez de armazená-lo no servidor.

### 2️⃣ JSON: O Formato de Dados das APIs 
`JSON (JavaScript Object Notation)`
- Estrutura de chave-valor.  
- Suporta **listas e objetos aninhados**.  

**Exemplo JSON:**  
```json
{
  "id": 1,
  "nome": "Notebook",
  "preco": 5000
}
```

## Trabalhando com Models e Controllers 

### 1️⃣ Criando um Model de Produto  
Crie o diretório `Models/` e crie o arquivo `ProdutoModel.cs`:

```csharp
namespace MeuProjetoAPI.Models
{
    // Classe que representa um Produto
    public class Produto
    {
        public int Id { get; set; }    // Identificador único do produto
        public string? Nome { get; set; }  // Nome do produto
        public decimal Preco { get; set; } // Preço do produto
    }
}

```

### 2️⃣ Alterando o Controller para usar o Model  

```csharp
// Importamos o namespace do nosso Model (Produto)
using MeuProjetoAPI.Models;
// Importamos o namespace necessário para trabalhar com controllers no ASP.NET Core
using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoAPI.Controllers
{
    // Define que esta classe é um Controller de API
    [ApiController]
    
    // Define a rota base para esse controller. 
    // Quando o usuário acessar "/api/produtos", esse controller será chamado.
    [Route("/api/produtos")]

    public class ProdutoController : ControllerBase
    {
        // Criamos uma lista estática de produtos como um "banco de dados em memória"
        // Como agora temos a classe Produto, usamos uma lista de Produto em vez de objetos anônimos.
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto {Id = 1, Nome = "Notebook", Preco = 5000},
            new Produto {Id = 2, Nome = "Mouse", Preco = 300},
        };

        // Define um endpoint GET que responde na rota "/api/produtos"
        [HttpGet]
        public IActionResult GetProdutos()
        {
            // Retorna a lista de produtos no formato JSON com o código de status HTTP 200 (OK)
            return Ok(produtos);
        }

        // Define um endpoint POST que permite adicionar um novo produto
        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            // Adiciona o novo produto à lista
            produtos.Add(produto);

            // Retorna o código HTTP 201 (Created) e o objeto criado
            return Created("", produto);
        }
    }
}

```

#### O que mudou e por quê?
1. **Criamos um Model (`Produto`)**
Antes, os produtos eram definidos como objetos anônimos (`new { Id = 1, Nome = "Notebook", Preco = 5000 }`).
Agora, criamos uma classe Produto no diretório Models, o que melhora a organização do código.
Com isso, o controller pode usar essa classe fortemente tipada para representar produtos.
2. **Alteramos a lista de produtos**
Agora, produtos é uma lista de objetos Produto, ao invés de objetos anônimos.
3. **Adicionamos um endpoint POST**
Criamos um método `AdicionarProduto()` para adicionar produtos à lista via requisição HTTP POST.

### 3️⃣ Testando com o API Client Lite
1. **GET** → `https://localhost:porta/api/produtos`
2. **POST** → Envie este JSON:

```sh
POST http://localhost:porta/api/produtos
content-type: application/json

{
    "Id": 4,
    "Nome": "Yuri Alberto",
    "Preco": 10000000000
}

```