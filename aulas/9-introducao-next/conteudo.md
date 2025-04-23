# Introdução ao `Next.js`

**Next.js** é um **framework** (um conjunto de ferramentas) construído em cima do **React**, que facilita a criação de aplicações web modernas, rápidas e organizadas.

Pense assim:  
> 👉 **React** é uma biblioteca.  
> 👉 **Next.js** é um kit completo de construção de sites usando React.

Enquanto o React por si só foca na criação de **componentes da interface**, o Next.js adiciona recursos essenciais que um projeto real precisa, como:

- Sistema de **rotas automático**
- **Renderização no servidor** (SSR)
- **Geração de páginas estáticas** (SSG)
- Suporte nativo para **API routes**
- Otimização automática de performance

## 🔗 Qual é a relação entre **Next.js** e **React**?

Next.js **usa React por baixo dos panos**.

Você ainda escreve componentes React, usa hooks como `useState`, `useEffect`, etc., mas com o Next você ganha uma estrutura pronta, organizada, e recursos avançados para o seu projeto escalar com facilidade.

É como se o React fosse o motor, e o Next.js fosse o carro inteiro montado com o motor já incluso.

## 🌐 Qual a importância do Next.js em projetos front-end?

### ✨ Ele facilita a vida dos desenvolvedores com:
- **Rotas automáticas**: Cada arquivo `.js` em `src/` vira uma URL automaticamente.
- **SEO melhorado**: Por conta do Server-Side Rendering.
- **Performance otimizada**: Carregamento inteligente das páginas.
- **Deploy fácil**: Muito usado com o Vercel, que é a plataforma dos criadores do Next.js.
- **Experiência de usuário mais fluida**: Páginas carregam mais rápido.

## 🔌 Como o Next.js se conecta com o backend?

### 🔁 Integração via API:

O Next.js consome dados de APIs usando `fetch` ou bibliotecas como `axios`.

Se você tem uma API feita em **C# com .NET**, por exemplo, o Next.js pode se conectar a ela assim:

```js
// Exemplo básico com fetch
const response = await fetch("http://localhost:5000/api/personagens");
const data = await response.json();
console.log(data);
```

Essa comunicação é feita por **requisições HTTP** (`GET`, `POST`, `PUT`, `DELETE`, etc.), que permitem que o front-end:

- Leia dados do backend
- Envie dados do formulário
- Atualize ou delete informações

# Hello World com `Next.js`

## ✅ 1. Pré-requisitos:
- Ter o **Node.js** instalado ([https://nodejs.org/](https://nodejs.org/))
- Ter o **npm** (vem junto com o Node)

## ✅ 2. Criar o projeto:
Abra o terminal e digite:

```bash
npx create-next-app@latest ola-next
```

Quando ele perguntar:

- **Would you like to use TypeScript?** → `No`
- **Would you like to use ESLint?** → `Yes` ou `No` (tanto faz pra esse exemplo)
- **Would you like to use Tailwind CSS?** → `No`
- **Would you like your code inside a `src/` directory?** → `Yes`
- **Would you like to use App Router? (recommended)** → `Yes`
- **Would you like to use Turbopack for `next dev`?** → `No`
- **Would you like to customize the import alias (`@/*` by default)?** → `No`

Depois entre na pasta do projeto:

```bash
cd ola-next
```

E rode o projeto:

```bash
npm run dev
```

Abra o navegador em: [http://localhost:3000](http://localhost:3000)

## Agora vamos alterar a página principal

Abra o arquivo:

```
ola-next/src/page.js
```

Apague tudo e coloque esse código bem simples:

```jsx
export default function Home() {
  return (
    <div>
      <h1>Olá, mundo!</h1>
      <p>Esse é meu primeiro projeto. 🚀</p>
    </div>
  );
}
```

## ✅ Pronto!

Você acabou de criar sua **primeira página com Next.js**.  

## 💡 Dicas:
- O arquivo `src/page.js` é a **página principal (home)** do seu site.
- Qualquer outro arquivo dentro da pasta `src` vira uma rota automaticamente.
- O comando `npm run dev` inicia o servidor de desenvolvimento.