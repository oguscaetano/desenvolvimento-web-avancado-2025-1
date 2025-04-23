# Introdução ao `fetch()`

## O que é `fetch()`?

O `fetch()` é uma função **nativa do JavaScript** usada para fazer requisições HTTP (como `GET`, `POST`, `PUT`, `DELETE`).

Ela retorna uma **Promise** — ou seja, o resultado será entregue **futuramente** (async/await ou `.then()`).

---

## 🔹 3. Primeira requisição com `fetch()` (modo simples)

Abra o console do navegador (F12 > Aba Console) ou use o Node.js e digite:

```javascript
fetch("https://pokeapi.co/api/v2/pokemon/pikachu")
  .then(response => response.json()) // converte para JSON
  .then(data => console.log(data)) // exibe no console
  .catch(error => console.error("Erro na requisição:", error));
```

---

### 🧠 Explicando linha por linha:

```js
fetch("https://pokeapi.co/api/v2/pokemon/pikachu")
```
➡️ Faz uma requisição GET para a URL da API.

```js
.then(response => response.json())
```
➡️ Quando a resposta chega, converte o corpo da resposta em JSON.

```js
.then(data => console.log(data))
```
➡️ Mostra os dados no console.

```js
.catch(error => console.error("Erro na requisição:", error));
```
➡️ Captura e exibe erros se algo der errado (ex: internet caída ou URL errada).

---

## 🔹 4. Exibindo informações específicas

```javascript
fetch("https://pokeapi.co/api/v2/pokemon/charmander")
  .then(response => response.json())
  .then(data => {
    console.log("Nome:", data.name);
    console.log("Altura:", data.height);
    console.log("Peso:", data.weight);

    console.log("Habilidades:");
    data.abilities.forEach(h => {
      console.log("- " + h.ability.name);
    });
  });
```

---

## 🔹 5. Usando `async/await` (mais moderno)

```javascript
async function buscarPokemon(nome) {
  try {
    const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${nome}`);
    const data = await response.json();

    console.log("Nome:", data.name);
    console.log("Peso:", data.weight);
    console.log("Altura:", data.height);
  } catch (error) {
    console.error("Erro:", error);
  }
}

buscarPokemon("bulbasaur");
```