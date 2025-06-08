Prevent+ - Aplicativo de Prevenção e Educação para Desastres Naturais



(adicione seu logo aqui, se tiver)Índice

Descrição do Projeto

Arquitetura e Diagramas

Desenvolvimento

Testes

Como Executar

Exemplos de Testes com Swagger e Postman

Vídeos

Contato

Descrição do Projeto

Prevent+ é um sistema desenvolvido em .NET Core para auxiliar na prevenção e educação sobre desastres naturais. A aplicação oferece funcionalidades para gerenciamento de alertas, dicas, checklists, notificações e usuários, visando aumentar a conscientização e a preparação da população.

Arquitetura e Diagramas

Diagrama de Entidades (Modelo ER)



(adicione aqui o diagrama de entidades que mostra as tabelas e relacionamentos)Diagrama de Classes (Backend)



(diagrama com as classes principais do projeto, por exemplo: Usuario, Alerta, Dica, etc)Fluxo da Aplicação



(fluxo das chamadas entre front-end (Razor Pages) e API RESTful)Desenvolvimento

Tecnologias: ASP.NET Core, Entity Framework Core, Swagger, Razor Pages

Estrutura:

Models: definição das entidades e relacionamentos

DTOs: objetos de transferência para comunicação API

Controllers: pontos de acesso REST para os recursos

Services: regras de negócio e acesso ao banco

Views: interface Razor Pages para interação com o usuário

Boas práticas: injeção de dependência, validação via Data Annotations, uso de DTOs para segurança e desacoplamento.

Testes

Testes manuais com Swagger UI para endpoints REST.

Testes com Postman para diferentes cenários de CRUD.

Validação de dados via FluentValidation / Data Annotations.

Testes unitários (se implementados) com xUnit ou NUnit (adicione aqui se tiver).

Logs e tratamento de exceções configurados para facilitar a depuração.

Como Executar

Pré-requisitos

.NET 7 SDK ou superior

Oracle Database (com o script de criação do schema rodado)

Rider, Visual Studio 2022 ou VSCode

Docker (opcional, se usar container)

Git

Passos para rodar localmente

Clone o repositório:

bash

CopiarEditar

git clone https://github.com/seuusuario/preventplus.gitcd preventplus

Configure a string de conexão no appsettings.json:

json

CopiarEditar

"ConnectionStrings": {

  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

Restaure os pacotes:

bash

CopiarEditar

dotnet restore

Rode as migrations (se aplicável) para criar o banco:

bash

CopiarEditar

dotnet ef database update

Execute a aplicação:

bash

CopiarEditar

dotnet run --project PreventPlus.API

Acesse o Swagger para testes:

bash

CopiarEditar

http://localhost:5006/swagger/index.html

Exemplos de Testes com Swagger e Postman

Testar Regiões (POST /api/regioes)
JSON de exemplo:

json
Copiar
Editar
[
  {
    "idRegiao": 1,
    "nomeRegiao": "Região Metropolitana",
    "estadoRegiao": "SP",
    "usuarios": null,
    "historicosRisco": null
  },
  {
    "idRegiao": 2,
    "nomeRegiao": "Litoral Norte",
    "estadoRegiao": "SP",
    "usuarios": null,
    "historicosRisco": null
  }
]
