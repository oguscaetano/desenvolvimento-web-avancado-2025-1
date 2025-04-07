# 🧠 O que são Collections em C#?

**Collections** são estruturas que permitem armazenar e gerenciar grupos de objetos (dados), como listas de nomes, carrinhos de compras, históricos de mensagens, etc.

🔸 Em vez de criar mil variáveis (`nome1`, `nome2`, `nome3`...), usamos **coleções**.

## 🔧 Tipos de Collections mais comuns

| Tipo | Descrição |
|------|-----------|
| `List<T>` | Lista genérica, aceita qualquer tipo de dado (como objetos, strings, números etc.). Pode crescer dinamicamente. |
| `Dictionary<TKey, TValue>` | Armazena pares de chave-valor (como um dicionário ou mapa). |
| `HashSet<T>` | Coleção de valores únicos (sem repetições). |
| `Queue<T>` | Fila (primeiro a entrar, primeiro a sair – FIFO). |
| `Stack<T>` | Pilha (último a entrar, primeiro a sair – LIFO). |

### `List<T>`

```csharp
List<string> nomes = new List<string>();
nomes.Add("Goku");
nomes.Add("Vegeta");
nomes.Add("Gohan");

foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}
```

### `Dictionary<TKey, TValue>`

```csharp
Dictionary<int, string> personagens = new Dictionary<int, string>();
personagens.Add(1, "Goku");
personagens.Add(2, "Vegeta");

Console.WriteLine(personagens[1]); // Goku
```

### `Queue<T>` e `Stack<T>`

```csharp
Queue<string> fila = new Queue<string>();
fila.Enqueue("Goku");
fila.Enqueue("Vegeta");
Console.WriteLine(fila.Dequeue()); // Goku

Stack<string> pilha = new Stack<string>();
pilha.Push("Piccolo");
pilha.Push("Gohan");
Console.WriteLine(pilha.Pop()); // Gohan
```

### `HashSet<T>`

```csharp
HashSet<string> poderes = new HashSet<string>();
poderes.Add("Kamehameha");
poderes.Add("Final Flash");
poderes.Add("Kamehameha"); // Ignorado
```