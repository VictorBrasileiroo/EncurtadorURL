# 💬 UrlDux
<img src="https://raw.githubusercontent.com/VictorBrasileiroo/EncurtadorURL/master/banner.png" alt="Banner do Projeto UrlDux" style="width: 100%; max-width: 800px; height: auto;"></img>

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-purple)
![C#](https://img.shields.io/badge/C%23-12-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-orange)
![SQL Server](https://img.shields.io/badge/SQL-Server-red)
![Swagger](https://img.shields.io/badge/Documentation-Swagger-green)
![FluentValidation](https://img.shields.io/badge/Validation-FluentValidation-yellow)


---

## 🚀 Visão Geral

O **UrlDux** é um encurtador de URLs completo, desenvolvido para transformar links longos e complexos em URLs curtas, memoráveis e fáceis de compartilhar. O projeto visa demonstrar uma arquitetura de aplicação moderna.
Construído com **ASP.NET Core 8.0** e **C# 12**, a aplicação adota uma **arquitetura limpa**, utiliza algoritmos de codificação eficientes como **Base62** para a geração de códigos curtos únicos, e possui validações de entrada robustas via **FluentValidation**, com documentação de API automática via **Swagger**.

---

## 🛠️ Tecnologias Utilizadas

### Backend (ASP.NET Core)
- ASP.NET Core 8
- C# 12
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- FluentValidation
- Codificação Base62
---

## ⚙️ Pré-requisitos

Para rodar o projeto localmente, você precisará de:

- **Backend:**
    - Visual Studio 2022 ou um editor de código compatível com .NET.
    - .NET SDK 8.0
    - SQL Server (LocalDB ou uma instância acessível)
    - Git

---

## 📃 Formato de Respostas JSON

Todas as respostas da API seguem o mesmo padrão de estrutura:

```json
{
  "urlOriginal": "[https://www.example.com/long-url-here](https://www.example.com/long-url-here)",
  "urlEncurtada": "[https://urldux.com/XyZ123A](https://urldux.com/XyZ123A)",
  "codigoCurto": "XyZ123A"
}
```

### Exemplo de erro (400 Bad Request):
```json
{
  "type": "[https://tools.ietf.org/html/rfc7231#section-6.5.1](https://tools.ietf.org/html/rfc7231#section-6.5.1)",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "UrlLonga": [
      "A URL original não pode ser vazia.",
      "Formato de URL inválido."
    ]
  }
}
```

### Exemplo de erro (404 Not Found):
```json
{
  "longUrl": null,
  "codigoCurto": "codigoNaoExiste"
}
```

---

### 📋 Endpoints Disponíveis

#### 👤 Encurtador de URL
| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| POST | `/api/Url/encurtar` | Encurta uma URL longa. |
| GET | `//{codigoCurto}` | Redireciona para a URL longa original (tratado na raiz do app). |

---

## 🧬 Desafios Enfrentados

- Implementação eficiente do algoritmo de codificação Base62 para a geração de códigos curtos únicos.
- Construção de uma arquitetura limpa e modular para o backend.
- Validação robusta de entrada de dados com FluentValidation.
- Tratamento de exceções e retorno de mensagens claras para o usuário.

## 💻 Instalação

```bash
# 1. Clone o repositório
git clone [https://github.com/VictorBrasileiroo/EncurtadorURL.git](https://github.com/VictorBrasileiroo/EncurtadorURL.git)

# 2. Acesse a pasta da solução
cd EncurtadorURL

# 3. Restaure os pacotes NuGet para todos os projetos
dotnet restore

# 4. Acesse a pasta do projeto de infraestrutura para aplicar as migrações (onde está o DbContext)
cd EncurtadorURL.Infra # Certifique-se de que este é o nome correto da sua pasta Infraestrutura

# 5. Atualize o banco de dados (certifique-se de que seu SQL Server está rodando e a connection string está correta)
# Use -s para apontar para o projeto de startup (onde está o appsettings.json e Program.cs)
dotnet ef database update --project EncurtadorURL.Infra --startup-project EncurtadorURL.API

# 6. Volte para a pasta raiz da solução
cd ..

# 7. Execute o projeto da API
dotnet run --project EncurtadorURL.API
# A API estará disponível em https://localhost:7080 (ou a porta configurada)
```
---

## 📂 Estrutura do Projeto

```bash
├── EncurtadorURL.sln
│
├── EncurtadorURL.API/             # Projeto da API (endpoints, controllers, Program.cs)
│   ├── Controllers/
│   ├── Program.cs
│   ├── appsettings.json
│
├── EncurtadorURL.Application/     # Camada de Aplicação (DTOs, Interfaces de Serviço, Implementação de Serviços, Validações)
│   ├── Dto/
│   ├── Interfaces/
│   ├── Services/
│   ├── Validation/
│
├── EncurtadorURL.Core/            # Camada Core (Modelos de Domínio, Interfaces de Repositório, Classes Utilitárias)
│   ├── Models/
│   ├── IRepositories/
│   ├── Utils/                     # Para ConversorBase62
│
├── EncurtadorURL.Infra/           # Camada de Infraestrutura (DbContext, Implementação de Repositórios, Migrações)
│   ├── Context/
│   ├── Repositories/
│   ├── Migrations/
```

## ⚖️ Licença

Este projeto está sob a licença MIT - veja o arquivo LICENSE para detalhes.

---

## 📧 Contato

Victor André Lopes Brasileiro - valb1@ic.ufal.br
