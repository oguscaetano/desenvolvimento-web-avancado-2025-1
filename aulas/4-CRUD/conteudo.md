# Continuação do CRUD usando C# .NET, Entity Framework e MySQL

## Método `GET`

Para criarmos o método GET, precisamos acrescentar a chamada do método no nosso controller.

```csharp
[HttpGet] // Define que esse método responde a requisições HTTP do tipo GET
public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
{
    // Busca todos os personagens do banco de dados e os armazena na variável "personagens"
    var personagens = await _appDbContext.Personagens.ToListAsync();

    // Retorna a lista de personagens com o status 200 OK
    return Ok(personagens);
}
```

## Método `GET` por `ID`

```csharp
[HttpGet("{id}")] // Define que esse método responde a requisições GET com um ID na URL, ex: api/personagens/1
public async Task<ActionResult<Personagem>> GetPersonagem(int id)
{
    // Busca o personagem pelo ID informado
    var personagem = await _appDbContext.Personagens.FindAsync(id);

    // Se o personagem não for encontrado, retorna o status 404 Not Found com uma mensagem
    if (personagem == null)
    {
        return NotFound("Personagem não encontrado.");
    }

    // Se encontrado, retorna o personagem com o status 200 OK
    return Ok(personagem);
}
```

## Método `PUT` por `ID`

```csharp
[HttpPut("{id}")] // Define que esse método responde a requisições PUT com um ID na URL, ex: api/personagens/1
public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
{
    // Busca o personagem existente no banco de dados pelo ID
    var personagemExistente = await _appDbContext.Personagens.FindAsync(id);

    // Se o personagem não for encontrado, retorna o status 404 Not Found
    if (personagemExistente == null)
    {
        return NotFound("Personagem não encontrado.");
    }

    // Atualiza os valores do personagem existente com os valores enviados na requisição
    _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);

    // Salva as mudanças no banco de dados
    await _appDbContext.SaveChangesAsync();

    // Retorna o status 201 Created indicando que a atualização foi feita com sucesso
    return StatusCode(201, personagemExistente);
}
```

## Método `DELETE` por `ID`

```csharp
[HttpDelete("{id}")] // Define que esse método responde a requisições DELETE com um ID na URL, ex: api/personagens/1
public async Task<IActionResult> DeletePersonagem(int id)
{
    // Busca o personagem pelo ID informado
    var personagem = await _appDbContext.Personagens.FindAsync(id);

    // Se o personagem não for encontrado, retorna o status 404 Not Found
    if (personagem == null)
    {
        return NotFound("Personagem não encontrado.");
    }

    // Remove o personagem do banco de dados
    _appDbContext.Personagens.Remove(personagem);

    // Salva as mudanças no banco de dados
    await _appDbContext.SaveChangesAsync();

    // Retorna uma mensagem indicando que a exclusão foi bem-sucedida, com o status 200 OK
    return Ok("Personagem deletado com sucesso!");
}
```

## BÔNUS: Criar ID automaticamente

Para deixarmos a criação dos IDs automáticos, de tal forma que não precisemos nos preocupar com eles, podemos adicionar o seguinte código ao nosso Model:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace ProjetoDBZ.Models
//{
//    public class Personagem
//    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public string Nome { get; set; }
//        public string Tipo { get; set; }
//    }
//}
```

>Dessa forma o Id se torna chave primária da tabela e o seu valor é gerado automaticamente 🤠