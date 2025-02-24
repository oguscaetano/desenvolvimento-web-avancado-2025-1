
## Exemplo de solução ao exercício

1. Criamos uma **classe abstrata** `Veiculo`.
2. Criamos duas classes `Carro` e `Moto`, que herdam de `Veiculo`.
3. Criamos uma **interface** `IVeiculo`, que contém o método `ExibirDetalhes()`.
4. Implementamos um menu interativo com entrada de dados do usuário.
5. Utilizamos **listas** (`List<Veiculo>`) para armazenar os veículos.

### Passo 1: Criar um Projeto Console no .NET Core 8
```sh
dotnet new console -n GerenciamentoVeiculos
cd GerenciamentoVeiculos
code .
```

Agora, substituímos o código de `Program.cs` pelo seguinte:

---

### **Código Completo:**
```csharp
using System;
using System.Collections.Generic;

namespace GerenciamentoVeiculos
{
    // Interface para exibir detalhes
    interface IVeiculo
    {
        void ExibirDetalhes();
    }

    // Classe abstrata Veiculo (Base)
    abstract class Veiculo : IVeiculo
    {
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }
        public int Ano { get; protected set; }

        public Veiculo(string marca, string modelo, int ano)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
        }

        public abstract void ExibirDetalhes(); // Método abstrato
    }

    // Classe Carro (Derivada de Veiculo)
    class Carro : Veiculo
    {
        public int Portas { get; private set; }

        public Carro(string marca, string modelo, int ano, int portas)
            : base(marca, modelo, ano)
        {
            Portas = portas;
        }

        public override void ExibirDetalhes()
        {
            Console.WriteLine($"🚗 Carro: {Marca} {Modelo} ({Ano}) - {Portas} portas");
        }
    }

    // Classe Moto (Derivada de Veiculo)
    class Moto : Veiculo
    {
        public bool TemPartidaEletrica { get; private set; }

        public Moto(string marca, string modelo, int ano, bool temPartidaEletrica)
            : base(marca, modelo, ano)
        {
            TemPartidaEletrica = temPartidaEletrica;
        }

        public override void ExibirDetalhes()
        {
            string partida = TemPartidaEletrica ? "Sim" : "Não";
            Console.WriteLine($"🏍 Moto: {Marca} {Modelo} ({Ano}) - Partida elétrica: {partida}");
        }
    }

    class Program
    {
        static List<Veiculo> listaDeVeiculos = new List<Veiculo>();

        static void Main()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n===== Sistema de Gerenciamento de Veículos =====");
                Console.WriteLine("1. Cadastrar Carro");
                Console.WriteLine("2. Cadastrar Moto");
                Console.WriteLine("3. Listar Veículos");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("⚠ Entrada inválida. Digite um número.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarCarro();
                        break;
                    case 2:
                        CadastrarMoto();
                        break;
                    case 3:
                        ListarVeiculos();
                        break;
                    case 4:
                        Console.WriteLine("🚀 Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("⚠ Opção inválida.");
                        break;
                }
            } while (opcao != 4);
        }

        static void CadastrarCarro()
        {
            Console.Write("\nDigite a marca do carro: ");
            string marca = Console.ReadLine();

            Console.Write("Digite o modelo do carro: ");
            string modelo = Console.ReadLine();

            Console.Write("Digite o ano do carro: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite o número de portas: ");
            int portas = int.Parse(Console.ReadLine());

            Carro novoCarro = new Carro(marca, modelo, ano, portas);
            listaDeVeiculos.Add(novoCarro);

            Console.WriteLine("✅ Carro cadastrado com sucesso!");
        }

        static void CadastrarMoto()
        {
            Console.Write("\nDigite a marca da moto: ");
            string marca = Console.ReadLine();

            Console.Write("Digite o modelo da moto: ");
            string modelo = Console.ReadLine();

            Console.Write("Digite o ano da moto: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("A moto tem partida elétrica? (s/n): ");
            bool temPartidaEletrica = Console.ReadLine().ToLower() == "s";

            Moto novaMoto = new Moto(marca, modelo, ano, temPartidaEletrica);
            listaDeVeiculos.Add(novaMoto);

            Console.WriteLine("✅ Moto cadastrada com sucesso!");
        }

        static void ListarVeiculos()
        {
            if (listaDeVeiculos.Count == 0)
            {
                Console.WriteLine("⚠ Nenhum veículo cadastrado.");
                return;
            }

            Console.WriteLine("\n===== Lista de Veículos Cadastrados =====");
            foreach (var veiculo in listaDeVeiculos)
            {
                veiculo.ExibirDetalhes();
            }
        }
    }
}
```

---

## Explicação do Código
### 1 - Criamos a Interface `IVeiculo`
- Define um contrato com o método `ExibirDetalhes()`, obrigatório para todas as classes que a implementarem.

### 2 - Criamos a Classe Abstrata `Veiculo`
- Contém propriedades `Marca`, `Modelo` e `Ano`.
- Possui um **método abstrato** `ExibirDetalhes()`, que será implementado pelas classes filhas.

### 3 - Criamos as Classes `Carro` e `Moto`
- Ambas herdam de `Veiculo` e implementam `ExibirDetalhes()`.
- `Carro` tem um atributo extra `Portas`.
- `Moto` tem um atributo extra `TemPartidaEletrica`.

### 4 - Criamos o Menu Interativo
- O usuário pode **cadastrar carros e motos**, **listar os veículos cadastrados** e **sair do sistema**.
- Utilizamos uma **lista (`List<Veiculo>`)** para armazenar os veículos.

---

## Testando o Sistema
1️⃣ **Execute o programa** no terminal:  
```sh
dotnet run
```

2️⃣ **Interaja com o menu**:
```
===== Sistema de Gerenciamento de Veículos =====
1. Cadastrar Carro
2. Cadastrar Moto
3. Listar Veículos
4. Sair
Escolha uma opção: 
```

3️⃣ **Cadastre alguns veículos e liste-os!** 🚗🏍
