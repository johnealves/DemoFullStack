# Orientações para agentes

## Contexto do projeto

- Backend: ASP.NET Core com .NET 10, em `api/DemoFullstack.Api`.
- Frontend: React, TypeScript e Vite, em `web`.
- Solução .NET: `DemoFullstack.slnx`, na raiz.
- Comunique-se com o usuário em português.

## Permissões obrigatórias

- Não crie nem altere testes automatizados sem permissão explícita do usuário.
- Não instale bibliotecas, pacotes, ferramentas ou novas dependências sem permissão explícita do usuário. Isso inclui NuGet, npm e instalações globais.
- Não atualize nem remova dependências sem permissão explícita do usuário.
- Quando uma tarefa depender dessas ações, explique a necessidade e aguarde autorização antes de executá-las. Continue outras partes independentes da tarefa quando possível.

## Forma de trabalhar

- Leia os arquivos envolvidos antes de propor ou implementar mudanças.
- Faça alterações pequenas e focadas na solicitação. Preserve alterações existentes do usuário.
- Não faça refatorações amplas, renomeações ou mudanças de arquitetura sem necessidade para a tarefa.
- Prefira os recursos da plataforma e as dependências já presentes no projeto.
- Não adicione camadas, abstrações ou ferramentas apenas por antecipação de necessidades futuras.
- Não exponha credenciais ou dados sensíveis em código, logs ou respostas.

## Backend

- Mantenha controllers focados no tratamento HTTP; extraia regras de negócio para serviços quando a complexidade justificar.
- Use nomes consistentes para arquivos, classes e namespaces, seguindo as convenções de C#.
- Preserve contratos de endpoints existentes, salvo quando a solicitação exigir mudança.
- Mantenha configurações específicas de ambiente fora do código de negócio e segredos fora de arquivos versionados.
- Ao alterar caminhos ou projetos, confira as referências em `DemoFullstack.slnx`.

## Frontend

- Use componentes funcionais e hooks do React.
- No código React, prefira arrow functions sempre que possível, incluindo componentes, hooks e callbacks.
- Defina tipos explícitos para dados da API e evite `any` sem justificativa.
- Separe componentes reutilizáveis e chamadas HTTP conforme a aplicação crescer.
- Ao implementar chamadas HTTP, trate carregamento, erro e ausência de dados.
- Preserve acessibilidade, HTML semântico e comportamento responsivo nas alterações de interface.

## Validação e entrega

- Valide mudanças com ferramentas já disponíveis e verificações proporcionais ao escopo.
- Builds e lint podem ser executados sem autorização adicional, desde que não instalem dependências. Se houver necessidade de instalação ou restauração de pacotes, peça permissão antes.
- Execute testes existentes apenas quando forem relevantes; a autorização para executá-los não autoriza escrever ou alterar testes.
- Não afirme que uma validação passou sem executá-la.
- Ao concluir, informe o que mudou, quais verificações foram feitas e eventuais limitações.
