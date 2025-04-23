# Exemplo: Pokédex em Next.js

Execute o comando:

```bash
npx create-next-app@latest pokedex-next
```

Depois, substitua o conteúdo de `app/page.tsx` com o código abaixo, conforme a versão do Next que estiver usando.

## 💻 Código completo: `app/page.tsx`

```jsx
"use client";

import { useState } from 'react';

type Pokemon = {
  nome: string;
  id: number;
  imagem: string;
};

export default function Home() {
  const [input, setInput] = useState<string>('');
  const [pokemon, setPokemon] = useState<Pokemon | null>(null);
  const [erro, setErro] = useState<string>('');

  const buscarPokemon = async (e: React.FormEvent) => {
    e.preventDefault();
    setErro('');
    setPokemon(null);

    try {
      const resposta = await fetch(`https://pokeapi.co/api/v2/pokemon/${input.toLowerCase()}`);

      if (!resposta.ok) {
        throw new Error('Pokémon não encontrado.');
      }

      const dados = await resposta.json();

      setPokemon({
        nome: dados.name,
        id: dados.id,
        imagem: dados.sprites.front_default,
      });

    } catch (err: any) {
      setErro(err.message);
    }
  };

  return (
    <div style={{ padding: '2rem', fontFamily: 'Arial', textAlign: 'center' }}>
      <h1>Buscar Pokémon</h1>
      <br/>
      <form onSubmit={buscarPokemon}>
        <input
          type="text"
          placeholder="Digite o nome ou ID do Pokémon"
          value={input}
          onChange={(e) => setInput(e.target.value)}
          style={{ padding: '0.5rem', width: '300px' }}
        />
        <button type="submit" style={{ padding: '0.5rem', marginLeft: '1rem' }}>
          Buscar
        </button>
      </form>

      {erro && <p style={{ color: 'red', marginTop: '30px' }}>{erro}</p>}

      {pokemon && (
        <div style={{ marginTop: '2rem' }}>
          <h2>{pokemon.nome} (#{pokemon.id})</h2>
          <img src={pokemon.imagem} alt={pokemon.nome} style={{ width: '200px' }} />
        </div>
      )}
    </div>
  );
}
```

## 🚀 Como testar

1. Rode seu projeto com:

```bash
npm run dev
```

2. Acesse `http://localhost:3000`