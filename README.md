 Prevent+ – Aplicativo de Prevenção e Educação para Desastres Naturais

## 📌 Descrição
Projeto desenvolvido com .NET 8 utilizando Razor Pages, API RESTful, banco de dados SQLite, Swagger e boas práticas de arquitetura. O sistema permite o gerenciamento de usuários, alertas, regiões, desastres, dicas, checklists, entre outros, promovendo a conscientização e resposta rápida em casos de desastres naturais.

---

## 📁 Repositório
**GitHub:** [https://github.com/cahAmaral/PreventPlus](https://github.com/cahAmaral/PreventPlus)

---

## 🧩 Estrutura do Projeto
- API RESTful com .NET 9
- Razor Pages com TagHelpers
- SQLite como banco de dados
- Swagger para documentação
- Boas práticas de arquitetura (camadas: Models, DTOs, Controllers, Services)

---

## 📊 Diagrama da Solução

![Diagrama](docs/diagrama.png)

---

## 🔧 Tecnologias Utilizadas
- ASP.NET Core 8
- SQLite
- Entity Framework Core
- Swagger
- Razor Pages com TagHelpers

---

## 🚀 Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/cahAmaral/PreventPlus.git
```
2. Restaure os pacotes:
```bash
dotnet restore
```
3. Execute as migrations:
```bash
dotnet ef database update
```
4. Rode o projeto:
```bash
dotnet run
```
5. Acesse via navegador:
```
http://localhost:5006/swagger
```

---

## 🧪 Exemplos de Teste via Swagger

### Testar Regiões (POST /api/regioes)
**JSON de exemplo:**
```json
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
