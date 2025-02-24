# Desenvolver aplicações usando classes, atributos, métodos e relacionamento entre classes com o C#.

## ⭐️ Introdução e Configuração de Ambiente
🎯 *Objetivo:* Preparar o ambiente de desenvolvimento e apresentar ferramentas essenciais.

### Configuração do Ambiente de Desenvolvimento**  
1. **Apresentação do C# e .NET**  
   - O que é o .NET? Qual sua importância?  
   - Diferença entre .NET Framework, .NET Core e .NET 5+  
   - Explicação sobre a CLI do .NET  
   
2. **Instalação das Ferramentas**  
   - Instalar o [.NET SDK](https://dotnet.microsoft.com/)  
   - Instalar o [VS Code](https://code.visualstudio.com/)  
   - Instalar as extensões essenciais:
     - C# Dev Kit
   
3. **Primeiros Passos no VS Code**  
   - Criando um workspace  
   - Explorando a interface do VS Code  
   - Configurações básicas para melhor produtividade  

4. **Executando o primeiro código C#**  
   - Criando um novo projeto console:  

     ```sh
     dotnet new console -n HelloWorld
     cd HelloWorld
     code .
     ```

   - Explicação do `Program.cs` gerado automaticamente  
   - Executando o código:  
     ```sh
     dotnet run
     ```

---

## ⭐️ Fundamentos do C# e CLI 
🎯 *Objetivo:* Ensinar os fundamentos do C# e como utilizar a CLI.

* **Comandos essenciais do .NET CLI**  
   - Criar, compilar e rodar projetos  
   - Listar pacotes instalados  
   - Adicionar pacotes com `dotnet add package`  

* **Explorando o NuGet**  
   - O que é o NuGet?  
   - Instalando pacotes de terceiros  

`No desenvolvimento com C#, é essencial conhecer a CLI do .NET (Command-Line Interface) e o NuGet, que é o gerenciador de pacotes do .NET. Vamos explorar esses conceitos em detalhes.`

---

### .NET CLI - Interface de Linha de Comando
O **.NET CLI (Command-Line Interface)** é uma ferramenta poderosa que permite criar, compilar, executar e gerenciar aplicações .NET diretamente pelo terminal, sem a necessidade de usar um ambiente gráfico.

Para verificar se o .NET está instalado e sua versão, use:

```sh
dotnet --version
```

Se não estiver instalado, faça o download em: [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download).

---

**Criando, Compilando e Rodando Projetos com .NET CLI**
A CLI do .NET permite criar diferentes tipos de projetos, incluindo **aplicações console, APIs, bibliotecas e mais**.

### Criando um projeto Console
Um projeto console é uma aplicação que roda no terminal. Para criar um, execute:

```sh
dotnet new console -n MeuProjeto
```

Isso cria uma pasta chamada **MeuProjeto** com um arquivo `Program.cs` contendo o código padrão:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Agora, entre na pasta do projeto:

```sh
cd MeuProjeto
```

---

### Compilando o projeto
O comando abaixo compila o código-fonte e gera um executável:

```sh
dotnet build
```

Isso cria uma pasta `bin/Debug/net8.0/` (ou outra versão do .NET) onde o executável pode ser encontrado.

---

### Rodando o projeto
Para executar o programa diretamente sem precisar compilar manualmente, use:

```sh
dotnet run
```

Saída esperada:
```
Hello, World!
```

Se quiser rodar o executável gerado manualmente:

```sh
bin/Debug/net8.0/MeuProjeto.exe
```

---

## ⭐️ Listando e Gerenciando Pacotes com .NET CLI
No desenvolvimento com C#, é comum utilizar **pacotes de terceiros** para adicionar funcionalidades extras. O .NET usa o **NuGet** como gerenciador de pacotes.

**O que é o NuGet?**

O **NuGet** é o sistema oficial de gerenciamento de pacotes do .NET, equivalente ao **npm** no JavaScript ou ao **pip** no Python. Ele permite instalar bibliotecas de terceiros facilmente.

Para verificar se o NuGet está funcionando na sua instalação, use:

```sh
dotnet nuget list source
```

Isso mostra os repositórios configurados, como o oficial **https://api.nuget.org/v3/index.json**.

---

### Listando pacotes instalados
Se você quiser ver quais pacotes estão instalados no seu projeto, use:

```sh
dotnet list package
```

Se ainda não houver pacotes instalados, a saída será algo como:

```
No packages found.
```

Após instalar alguns pacotes, a saída será parecida com:

```
Package Reference  Resolved Version
-----------------  ----------------
Newtonsoft.Json    13.0.3
```

---

## ⭐️ Adicionando pacotes com `dotnet add package`
Para instalar um pacote NuGet em um projeto, use:

```sh
dotnet add package NomeDoPacote
```

Por exemplo, para instalar a biblioteca **Newtonsoft.Json**, usada para manipulação de JSON:

```sh
dotnet add package Newtonsoft.Json
```

Isso adiciona a seguinte linha ao arquivo `MeuProjeto.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
</ItemGroup>
```

Agora, podemos usar o pacote no código:

```csharp
using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        var pessoa = new { Nome = "Maria", Idade = 25 };
        string json = JsonConvert.SerializeObject(pessoa);
        Console.WriteLine(json);
    }
}
```

Rodando o código com `dotnet run`, a saída será:

```json
{"Nome":"Maria","Idade":25}
```

---

## ⭐️ Instalando Pacotes de Terceiros
Além do **Newtonsoft.Json**, existem muitos pacotes úteis no NuGet.

### Exemplo: Instalando o pacote `RestSharp`
O **RestSharp** é usado para fazer requisições HTTP de forma simples. Para instalá-lo:

```sh
dotnet add package RestSharp
```

Agora, um exemplo prático de como usá-lo para buscar dados de uma API:

```csharp
using System;
using RestSharp;

class Program
{
    static void Main()
    {
        var client = new RestClient("https://api.agify.io");
        var request = new RestRequest("?name=Lucas", Method.Get);
        var response = client.Execute(request);

        Console.WriteLine(response.Content);
    }
}
```

Quando rodamos `dotnet run`, a saída será algo como:

```json
{"name":"Lucas","age":28,"count":127}
```

---

## ⭐️ Sintaxe do C#
O C# é uma linguagem fortemente tipada e baseada no paradigma da **Programação Orientada a Objetos (POO)**. Vamos explorar a sintaxe do C# com exemplos práticos e detalhados.

---

## 1. Estrutura de um Programa C#
Todo programa em C# tem uma estrutura básica que segue o seguinte formato:

```csharp
using System;

namespace MeuPrograma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, Mundo!");
        }
    }
}
```

### **Explicação**
🔹 `using System;` → Importa o namespace **System**, que contém funções essenciais como `Console.WriteLine()`.  
🔹 `namespace MeuPrograma` → Define um **namespace** (espaço de nomes) para organizar o código.  
🔹 `class Program` → Declara uma **classe** chamada `Program`. No C#, todo código deve estar dentro de uma classe.  
🔹 `static void Main(string[] args)` → O método `Main` é o ponto de entrada do programa.  
🔹 `Console.WriteLine("Olá, Mundo!");` → Exibe texto no terminal.  

📌 **Importante:** O método `Main` deve ser `static`, pois é chamado automaticamente quando o programa inicia.

---

## 2. Tipos de Dados e Variáveis
No C#, uma variável deve ser declarada com um **tipo** antes de ser usada.

### **Tipos de Dados Primitivos**
| Tipo       | Descrição             | Exemplo |
|------------|----------------------|---------|
| `int`      | Números inteiros      | `int idade = 25;` |
| `double`   | Números decimais      | `double altura = 1.75;` |
| `bool`     | Verdadeiro ou falso   | `bool ativo = true;` |
| `char`     | Um único caractere    | `char letra = 'A';` |
| `string`   | Texto (sequência)     | `string nome = "Carlos";` |

### **Inferência de Tipo (`var`)**
O C# permite que o compilador deduza o tipo automaticamente:

```csharp
var idade = 30;   // O compilador entende que é um int
var nome = "Ana"; // O compilador entende que é uma string
```

🔹 **Vantagem:** Código mais limpo.  
🔹 **Desvantagem:** O tipo não pode ser alterado depois de definido.

---

### **Conversões de Tipo**
Muitas vezes, precisamos converter um tipo para outro.

#### **Conversão Explícita (`Convert` e `Parse`)**
```csharp
string numeroTexto = "10";
int numero = Convert.ToInt32(numeroTexto);  // Converte para int
int numero2 = int.Parse(numeroTexto);       // Outra forma de converter

Console.WriteLine(numero + 5); // Saída: 15
```

#### **Conversão Implícita**
O C# permite conversão automática quando não há perda de dados:

```csharp
int numeroInteiro = 100;
double numeroDecimal = numeroInteiro; // Conversão implícita
Console.WriteLine(numeroDecimal); // Saída: 100
```

---

## 3. Entrada e Saída de Dados
No C#, usamos `Console.WriteLine()` para exibir dados e `Console.ReadLine()` para capturar entradas do usuário.

```csharp
Console.Write("Digite seu nome: ");
string nome = Console.ReadLine(); // Captura a entrada do usuário
Console.WriteLine($"Olá, {nome}!");
```

### **Explicação**
🔹 `Console.Write("Digite seu nome: ");` → Exibe um texto na tela sem quebrar a linha.  
🔹 `Console.ReadLine();` → Aguarda a entrada do usuário e armazena na variável `nome`.  
🔹 `$"Olá, {nome}!"` → **Interpolação de strings**, usada para exibir variáveis dentro de textos.

---

## 4. Estruturas Condicionais
As estruturas condicionais são usadas para tomar decisões no código.

### **Usando `if` e `else`**
```csharp
Console.Write("Digite sua idade: ");
int idade = Convert.ToInt32(Console.ReadLine());

if (idade >= 18)
{
    Console.WriteLine("Você é maior de idade.");
}
else
{
    Console.WriteLine("Você é menor de idade.");
}
```

### **Usando `switch`**
O `switch` é útil quando há várias opções possíveis.

```csharp
Console.Write("Escolha um número de 1 a 3: ");
int opcao = Convert.ToInt32(Console.ReadLine());

switch (opcao)
{
    case 1:
        Console.WriteLine("Você escolheu 1.");
        break;
    case 2:
        Console.WriteLine("Você escolheu 2.");
        break;
    case 3:
        Console.WriteLine("Você escolheu 3.");
        break;
    default:
        Console.WriteLine("Opção inválida.");
        break;
}
```

---

## 5. Laços de Repetição
Os laços permitem executar um bloco de código várias vezes.

### **Usando `for`**
```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Iteração {i}");
}
```

### **Usando `while`**
```csharp
int contador = 1;

while (contador <= 5)
{
    Console.WriteLine($"Contador: {contador}");
    contador++;
}
```

### **Usando `do-while`**
```csharp
int numero;
do
{
    Console.Write("Digite um número maior que 10: ");
    numero = Convert.ToInt32(Console.ReadLine());
} while (numero <= 10);
```

📌 **Diferença:** O `do-while` garante que o código execute pelo menos uma vez, mesmo que a condição já seja falsa.

### **Usando `foreach` (para coleções)**
```csharp
string[] nomes = { "Ana", "Carlos", "Bianca" };

foreach (string nome in nomes)
{
    Console.WriteLine($"Nome: {nome}");
}
```

---

## 6. Métodos e Funções
Os **métodos** são blocos de código reutilizáveis que podem receber parâmetros e retornar valores.

### **Criando um Método Simples**
```csharp
static void ExibirMensagem()
{
    Console.WriteLine("Bem-vindo ao programa!");
}
```
🔹 **Para chamar o método:**  
```csharp
ExibirMensagem();
```

### **Método com Parâmetro e Retorno**
```csharp
static int Soma(int a, int b)
{
    return a + b;
}

int resultado = Soma(5, 3);
Console.WriteLine($"Resultado da soma: {resultado}");
```

📌 **Explicação:**  
🔹 `static int Soma(int a, int b)` → Define um método que recebe dois inteiros e retorna um inteiro.  
🔹 `return a + b;` → Retorna a soma dos valores.  
🔹 `int resultado = Soma(5, 3);` → Chama o método e armazena o valor na variável `resultado`.

---

## ⭐️ Programação Orientada a Objetos (POO)
🎯 *Objetivo:* Conceitos de POO aplicados ao C#, com explicações detalhadas e exemplos práticos.

---

## 1. Introdução à POO em C#
A **Programação Orientada a Objetos (POO)** é um paradigma de programação que organiza o código em **objetos**, que possuem **atributos (dados)** e **métodos (comportamentos)**.

### **1.1 O que são Classes e Objetos?**
- Uma **classe** é um modelo (ou blueprint) para criar objetos.
- Um **objeto** é uma instância de uma classe.

📌 **Analogia:**  
Imagine uma **fábrica de carros** 🚗.  
- A **classe** é o **molde** para fabricar um carro.  
- O **objeto** é cada **carro fabricado** a partir desse molde.  

### **1.2 Criando uma Classe em C#**
Vamos criar uma classe `Carro`, que representa um carro no mundo real.

```csharp
class Carro
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
}
```

🔹 **Explicação:**  
- `public string Modelo { get; set; }` → Propriedade pública que armazena o modelo do carro.  
- `public int Ano { get; set; }` → Propriedade pública que armazena o ano do carro.  

Agora podemos criar e manipular objetos da classe `Carro`.

---

## 2. Encapsulamento e Métodos 
**Encapsulamento** significa esconder detalhes internos de uma classe e expor apenas o necessário.

### **2.1 Modificadores de Acesso**
Os principais modificadores de acesso em C# são:  
| Modificador | Descrição |
|-------------|------------|
| `public` | Pode ser acessado de qualquer lugar |
| `private` | Só pode ser acessado dentro da própria classe |
| `protected` | Pode ser acessado na própria classe e em classes derivadas |

### **2.2 Criando Métodos na Classe**
Podemos adicionar métodos à classe `Carro` para definir seu comportamento.

```csharp
class Carro
{
    public string Modelo { get; set; }
    public int Ano { get; set; }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Modelo: {Modelo}, Ano: {Ano}");
    }
}
```

### **2.3 Criando e Utilizando um Objeto**
```csharp
Carro meuCarro = new Carro();
meuCarro.Modelo = "Fusca";
meuCarro.Ano = 1980;
meuCarro.ExibirDetalhes(); // Saída: Modelo: Fusca, Ano: 1980
```

---

## 3. Construtores e Sobrecarga de Métodos
### **3.1 Criando um Construtor**
O **construtor** é um método especial que é chamado automaticamente quando um objeto é instanciado.

```csharp
class Carro
{
    public string Modelo { get; }
    public int Ano { get; }

    // Construtor
    public Carro(string modelo, int ano)
    {
        Modelo = modelo;
        Ano = ano;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Modelo: {Modelo}, Ano: {Ano}");
    }
}
```

Agora, podemos criar um carro já passando os valores:

```csharp
Carro meuCarro = new Carro("Fusca", 1980);
meuCarro.ExibirDetalhes(); // Saída: Modelo: Fusca, Ano: 1980
```

### **3.2 Sobrecarga de Métodos**
Podemos criar métodos com o mesmo nome, mas diferentes assinaturas.

```csharp
class Calculadora
{
    public int Somar(int a, int b)
    {
        return a + b;
    }

    public double Somar(double a, double b)
    {
        return a + b;
    }
}
```

Agora, podemos chamar `Somar()` com diferentes tipos de argumentos:

```csharp
Calculadora calc = new Calculadora();
Console.WriteLine(calc.Somar(5, 3));        // Saída: 8
Console.WriteLine(calc.Somar(2.5, 3.5));    // Saída: 6
```

---

## 4. Herança e Polimorfismo
A **herança** permite que uma classe herde características de outra, evitando repetição de código.

### **4.1 Criando uma Classe Base e uma Classe Derivada**
```csharp
class Veiculo
{
    public string Marca { get; set; }
    
    public void Buzinar()
    {
        Console.WriteLine("Biiii!");
    }
}

class Carro : Veiculo
{
    public string Modelo { get; set; }
}
```

Agora, podemos usar `Carro` e acessar os métodos da classe `Veiculo`:

```csharp
Carro carro = new Carro();
carro.Marca = "Volkswagen";
carro.Modelo = "Gol";
carro.Buzinar(); // Saída: Biiii!
```

### **4.2 Polimorfismo**
O **polimorfismo** permite que uma mesma ação tenha diferentes implementações.

```csharp
class Animal
{
    public virtual void EmitirSom()
    {
        Console.WriteLine("Som genérico");
    }
}

class Cachorro : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Au Au!");
    }
}
```

Agora, podemos usar o **polimorfismo**:

```csharp
Animal meuAnimal = new Cachorro();
meuAnimal.EmitirSom(); // Saída: Au Au!
```

🔹 **Explicação:**  
- `virtual` → Permite que um método seja sobrescrito.  
- `override` → Indica que o método está sendo sobrescrito na classe filha.

---

## 5. Classes Abstratas e Interfaces
### **5.1 Criando uma Classe Abstrata**
Uma **classe abstrata** não pode ser instanciada diretamente e serve como modelo para outras classes.

```csharp
abstract class Animal
{
    public abstract void EmitirSom();
}

class Cachorro : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Au Au!");
    }
}
```

Agora, podemos usar:

```csharp
Animal meuCachorro = new Cachorro();
meuCachorro.EmitirSom(); // Saída: Au Au!
```

### **5.2 Implementando Interfaces**
As **interfaces** definem um contrato que outras classes devem seguir.

```csharp
interface IVeiculo
{
    void Mover();
}

class Bicicleta : IVeiculo
{
    public void Mover()
    {
        Console.WriteLine("A bicicleta está se movendo.");
    }
}
```

Agora, podemos chamar:

```csharp
IVeiculo minhaBicicleta = new Bicicleta();
minhaBicicleta.Mover(); // Saída: A bicicleta está se movendo.
```

🔹 **Diferença entre Classes Abstratas e Interfaces:**  
| Recurso            | Classe Abstrata | Interface |
|--------------------|---------------|-----------|
| Pode ter métodos implementados | ✅ Sim | ❌ Não |
| Pode ter construtores | ✅ Sim | ❌ Não |
| Pode ser instanciada | ❌ Não | ❌ Não |
| Pode ter múltiplas heranças | ❌ Não | ✅ Sim |

---

### Exercício (opcional)  
- Criar um sistema simples de gerenciamento de veículos  
- Aplicar todos os conceitos aprendidos  
- Utilizar entrada de usuário para adicionar e exibir dados 
