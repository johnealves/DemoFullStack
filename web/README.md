# Frontend DemoFullstack

Interface React com TypeScript e Vite para consultar `GET /api/products`.
Exibe carregamento, lista vazia, produtos e erro com opção de tentar novamente.

## Estilos e componentes

Tailwind CSS 4 está integrado ao Vite pelo plugin `@tailwindcss/vite`.
O tema fica em `src/index.css`. Os componentes shadcn/ui `Button`, `Card`
e `Skeleton` foram adicionados manualmente a `src/components/ui`, com
adaptações para React 19 e acessibilidade, a partir do registro oficial.
A configuração está em `components.json`; o alias `@/` aponta para `src/`.

Referências: [Tailwind com Vite](https://tailwindcss.com/docs/installation/using-vite)
e [shadcn/ui com Vite](https://ui.shadcn.com/docs/installation/vite).

As requisições usam Axios, com cancelamento e timeout de 15 segundos.
Todas usam a instância `apiClient` de `src/api/axios.ts`, que centraliza a
URL base e permite adicionar interceptors de autenticação futuramente.
Para configurar outra API, copie `.env.example` para `.env.local` e ajuste
`VITE_API_BASE_URL` (por exemplo, `https://api.exemplo.com/api`). O padrão é
`/api`, preservando o proxy local e a publicação na mesma origem.
Reinicie o Vite após alterar o arquivo; em produção, gere um novo build.
Variáveis `VITE_*` são públicas no frontend e não devem conter segredos.
Uma API em outra origem precisa permitir o acesso por CORS.

O TanStack Query gerencia o estado e o cache da consulta `['products']`, com
dados considerados atualizados por um minuto e uma nova tentativa automática
em caso de falha. O botão de atualização permite consultar a API manualmente.

Com as dependências já instaladas, execute nesta pasta:

```sh
npm run dev
```

O proxy de desenvolvimento em `vite.config.ts` encaminha `/api` para
`http://localhost:5002`. A API precisa estar em execução.

Verificações disponíveis: `npm run build` e `npm run lint`.
O comando `npm run preview` serve para conferir o build estático;
o proxy de desenvolvimento não faz parte dos arquivos gerados.

Veja o [README da raiz](../README.md) para executar o projeto completo e
configurar o encaminhamento da API em produção.
