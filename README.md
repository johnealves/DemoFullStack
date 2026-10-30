# DemoFullstack

Aplicação de demonstração com ASP.NET Core (.NET 10) e React/TypeScript/Vite.
A API retorna uma lista fixa de produtos, sem banco de dados.

## Estrutura

- `DemoFullstack.slnx`: solução .NET.
- `api/DemoFullstack.Api`: API HTTP e configurações de ambiente.
- `web`: interface e configurações do frontend.

## Execução local

Pré-requisitos: SDK .NET 10, Node.js compatível com o Vite 8 e npm.
Em uma instalação nova, restaure as dependências com `dotnet restore DemoFullstack.slnx`
e `npm ci` dentro de `web`. Esses comandos baixam pacotes.

Com as dependências disponíveis, execute na raiz:

```sh
dotnet run --no-restore --project api/DemoFullstack.Api
```

Em outro terminal:

```sh
cd web
npm run dev
```

Abra a URL informada pelo Vite. A API atende em `http://localhost:5002`;
o frontend encaminha `/api` para essa origem pelo proxy do Vite, dispensando
CORS nesse fluxo. O contrato é `GET /api/products`, com resposta JSON no formato
`[{ "id": 1, "nome": "Notebook" }]`.

Em desenvolvimento, a documentação está em `http://localhost:5002/swagger`
e o documento OpenAPI em `http://localhost:5002/openapi/v1.json`.
O arquivo `api/DemoFullstack.Api/DemoFullstack.Api.http` contém uma requisição de exemplo.

## Validação

```sh
dotnet build DemoFullstack.slnx --no-restore
cd web
npm run build
npm run lint
```

Ainda não há uma suíte de testes automatizados.

## Publicação

O build do frontend é gerado em `web/dist`. Configure a hospedagem para servir
esses arquivos e encaminhar `/api` para a API na mesma origem pública.
O proxy do Vite é exclusivo do desenvolvimento. A publicação e esse
encaminhamento ainda não estão automatizados no projeto.

Mantenha segredos em variáveis de ambiente ou no gerenciador de segredos do .NET;
não os inclua nos arquivos versionados de configuração.
