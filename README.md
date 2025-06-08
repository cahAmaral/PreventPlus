## Prevent+ - Aplicativo de Prevenção e Educação para Desastres Naturais

(adicione seu logo aqui, se tiver)

Índice
Descrição do Projeto

Arquitetura e Diagramas

Desenvolvimento

Testes

Como Executar

Exemplos de Testes com Swagger e Postman

Vídeos

Contato

## Descrição do Projeto
Prevent+ é um sistema desenvolvido em .NET Core para auxiliar na prevenção e educação sobre desastres naturais. A aplicação oferece funcionalidades para gerenciamento de alertas, dicas, checklists, notificações e usuários, visando aumentar a conscientização e a preparação da população.

Arquitetura e Diagramas
Diagrama de Entidades (Modelo ER)

(adicione aqui o diagrama de entidades que mostra as tabelas e relacionamentos)

Diagrama de Classes (Backend)

(diagrama com as classes principais do projeto, por exemplo: Usuario, Alerta, Dica, etc)

Fluxo da Aplicação

(fluxo das chamadas entre front-end (Razor Pages) e API RESTful)

Desenvolvimento
Tecnologias: ASP.NET Core, Entity Framework Core, Oracle Database, Swagger, Razor Pages

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

## Como Executar
Pré-requisitos
.NET 7 SDK ou superior

Oracle Database (com o script de criação do schema rodado)

Rider, Visual Studio 2022 ou VSCode

Docker (opcional, se usar container)

Git

Passos para rodar localmente
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seuusuario/preventplus.git
cd preventplus
Configure a string de conexão no appsettings.json:

json
Copiar
Editar
"ConnectionStrings": {
  "OracleConnection": "User Id=usuario;Password=senha;Data Source=localhost:1521/xe;"
}
Restaure os pacotes:

bash
Copiar
Editar
dotnet restore
Rode as migrations (se aplicável) para criar o banco:

bash
Copiar
Editar
dotnet ef database update
Execute a aplicação:

bash
Copiar
Editar
dotnet run --project PreventPlus.API
Acesse o Swagger para testes:

bash
Copiar
Editar
http://localhost:5006/swagger/index.html
Exemplos de Testes com Swagger e Postman
Criar Usuário (POST /api/usuarios)
json
Copiar
Editar
{
  "nomeUsuario": "Carolzinha",
  "emailUsuario": "carol@example.com",
  "senhaUsuario": "senha123",
  "tipoUsuario": "Admin",
  "usuarioCriado": "2025-06-08T10:00:00",
  "idRegiao": 1,
  "checklists": [],
  "dicas": [],
  "kits": [],
  "notificacoes": [],
  "locaisFavoritos": []
}
Atualizar Alerta (PUT /api/alertas/{id})
json
Copiar
Editar
{
  "idAlerta": 1,
  "titulo": "Alerta de Enchente",
  "descricao": "Possibilidade de enchentes nas próximas 24 horas",
  "usuarioId": 2,
  "tipoDesastreId": 3
}
