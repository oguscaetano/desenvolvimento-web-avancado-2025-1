# 🧠 O que é LINQ?

**LINQ (Language Integrated Query)** é uma forma de **consultar, filtrar, ordenar, transformar** coleções (como listas, arrays ou dados de banco) usando uma **sintaxe parecida com SQL**, **direto no código C#**.

> Em vez de escrever `for` e `if` toda hora, você faz tudo com uma linha elegante de código.

## 🔍 Por que usar LINQ?

- Mais legível.
- Menos código repetitivo.
- Facilita consultas em listas, arrays, `DbSet` (com Entity Framework) e muito mais.

## ✏️ Exemplo com `List<T>`

```csharp
List<string> personagens = new List<string> { "Goku", "Vegeta", "Gohan", "Freeza" };

// LINQ para filtrar personagens com nome maior que 5 letras
var resultado = personagens.Where(p => p.Length > 5);

foreach (var nome in resultado)
{
    Console.WriteLine(nome); // Vegeta, Freeza
}
```

## 🔧 Principais métodos LINQ

| Método       | Para quê serve                      |
|--------------|--------------------------------------|
| `Where`      | Filtrar elementos (`if`)            |
| `Select`     | Projetar/transformar dados          |
| `OrderBy`    | Ordenar ascendente                  |
| `OrderByDescending` | Ordenar descendente         |
| `FirstOrDefault` | Buscar o primeiro elemento       |
| `Any`        | Verificar se existe algum elemento  |
| `Count`      | Contar elementos                    |
| `ToList()`   | Converter resultado para lista      |


## Diferença entre `foreach` e LINQ:

```csharp
// Sem LINQ
foreach (var p in lista)
{
    if (p.StartsWith("G"))
        Console.WriteLine(p);
}

// Com LINQ
var nomes = lista.Where(p => p.StartsWith("G"));
```

## `Where` e `Select`

- Filtrar personagens com base em condições:
```csharp
var guerreirosZ = personagens.Where(p => p.Contains("G")).ToList();
```

- Transformar resultado com `Select`:
```csharp
var upper = personagens.Select(p => p.ToUpper()).ToList();
```

## `OrderBy`, `OrderByDescending`

```csharp
var ordenados = personagens.OrderBy(p => p).ToList();
var ordenadosDesc = personagens.OrderByDescending(p => p).ToList();
```

## `FirstOrDefault`, `Any`, `Count`

```csharp
var goku = personagens.FirstOrDefault(p => p == "Goku"); // Retorna ou null
bool temVegeta = personagens.Any(p => p == "Vegeta");    // true/false
int total = personagens.Count();                         // 4
```

## 🎓 Conclusão

- LINQ é uma das ferramentas mais poderosas e subestimadas para devs.
- Deixa o código mais limpo, expressivo e elegante.
- Usado fortemente com Entity Framework para acessar banco de dados.