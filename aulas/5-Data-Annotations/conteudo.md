# O que são Validações com Data Annotations?  
**Data Annotations** são atributos usados em **C#** para validar automaticamente os dados de uma classe. Essas validações são aplicadas diretamente nos **modelos** (models) e garantem que os dados enviados para a API estejam corretos antes de serem salvos no banco de dados.  

Com as **Data Annotations**, podemos garantir regras como:  
✅ Campos obrigatórios.  
✅ Tamanhos mínimos e máximos de caracteres.  
✅ Valores dentro de um intervalo específico.  
✅ Formatos específicos (e-mails, números, etc.).  

## Como adicionar validações ao nosso código?  
Vamos aplicar algumas validações na classe **`Personagem`**, garantindo que:  
✔ O **Nome** seja obrigatório e tenha no máximo 50 caracteres.  
✔ A **Espécie** seja obrigatória e tenha no máximo 30 caracteres.  

### Código atualizado do Model (`Personagem.cs`):  
```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDBZ.Models
{
    public class Personagem
    {
        [Key] // Define que essa propriedade é a chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")] // Garante que o nome não seja nulo ou vazio
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")] // Define o tamanho máximo do nome
        public string Nome { get; set; }

        [Required(ErrorMessage = "A espécie é obrigatória!")] // Garante que a espécie seja obrigatória
        [MaxLength(30, ErrorMessage = "A espécie deve ter no máximo 30 caracteres.")] // Define o tamanho máximo da espécie
        public string Especie { get; set; }
    }
}
```

## Como isso funciona na API?
Agora que adicionamos as validações, quando alguém tentar enviar um **POST** com dados inválidos (exemplo: sem preencher o nome), a API retornará automaticamente um erro **400 Bad Request** com a mensagem de erro definida no **Data Annotation**.  

## Como aplicar as validações no Controller?  
No **Controller**, precisamos garantir que as validações sejam verificadas antes de salvar os dados. Para isso, usamos o **ModelState.IsValid** antes de processar a requisição.

### Atualizando o método POST no Controller (`PersonagensController.cs`):  
```csharp
[HttpPost]
public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
{
    if (!ModelState.IsValid) // Verifica se os dados enviados são válidos
    {
        return BadRequest(ModelState); // Retorna um erro 400 com os detalhes das validações que falharam
    }

    _appDbContext.Personagens.Add(personagem);
    await _appDbContext.SaveChangesAsync();

    return Created("", personagem); // Retorna status 201 Created com o personagem cadastrado
}
```

## Exemplo de resposta com erro ao tentar adicionar um personagem inválido: 
Se tentarmos enviar um **POST** sem preencher o **Nome**, a API retornará:  
```json
{
  "Nome": [
    "O nome é obrigatório!"
  ]
}
```

## Resumo
✔ **Data Annotations** são usados para validar dados nos models.  
✔ As validações ajudam a evitar erros antes de salvar os dados no banco.  
✔ O **ModelState.IsValid** garante que só salvamos dados válidos.  
✔ Retornamos **400 Bad Request** quando os dados são inválidos.  