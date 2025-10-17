# 🧩 CrudToAlgo

**CrudToAlgo** é uma plataforma de desafios de programação inspirada em plataformas como LeetCode, HackerRank e Codeforces. O sistema permite que usuários resolvam problemas algorítmicos, submetam suas soluções e recebam feedback automático sobre a correção de seus códigos.

## 🎯 Funcionalidades

- 📚 **Gerenciamento de Desafios**: CRUD completo para problemas algorítmicos
- 💻 **Submissão de Código**: Suporte para múltiplas linguagens de programação
- ✅ **Avaliação Automática**: Execução e validação de código contra casos de teste
- 👤 **Sistema de Usuários**: Cadastro e gerenciamento de perfis
- 📊 **Sistema de Pontuação**: Gamificação com pontos por desafios resolvidos
- 🏆 **Casos de Teste**: Validação com casos públicos e privados

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** e **Domain-Driven Design (DDD)**:

```
├── 🎮 CrudToAlgo.API/          # Camada de Apresentação (Controllers, Endpoints)
├── 🎯 CrudToAlgo.Application/   # Camada de Aplicação (Services, DTOs)
├── 🧠 CrudToAlgo.Domain/        # Camada de Domínio (Entidades, Regras de Negócio)
└── 🔧 CrudToAlgo.Infrastructure/ # Camada de Infraestrutura (EF Core, Repositórios)
```

### 📋 Entidades Principais

- **👤 Usuario**: Perfis dos usuários da plataforma
- **🧩 Desafio**: Problemas algorítmicos a serem resolvidos
- **📝 CasoTeste**: Entradas e saídas esperadas para validação
- **📤 Submissao**: Códigos enviados pelos usuários

## 🚀 Tecnologias Utilizadas

### Backend
- **🔷 .NET 8** - Framework principal
- **🌐 ASP.NET Core** - API REST
- **🗄️ Entity Framework Core 9.0.1** - ORM
- **🐘 PostgreSQL 15** - Banco de dados relacional
- **🐳 Docker & Docker Compose** - Containerização

### Ferramentas de Desenvolvimento
- **📊 Swagger/OpenAPI** - Documentação da API
- **🔧 Entity Framework Tools** - Migrations e gerenciamento do banco

## 📋 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker & Docker Compose](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

## 🛠️ Configuração e Instalação

### 1. Clone o repositório
```bash
git clone https://github.com/awernek/CrudToAlgo.git
cd CrudToAlgo
```

### 2. Configure o banco de dados PostgreSQL
```bash
# Subir o container PostgreSQL
docker-compose up -d postgres
```

### 3. Configure as connection strings

Os arquivos `appsettings.json` e `appsettings.Development.json` já estão configurados com:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=crudtoalgo_dev;Username=postgres;Password=postgres;Port=5432"
  }
}
```

### 4. Instale o Entity Framework Tools (se não tiver)
```bash
dotnet tool install --global dotnet-ef
```

### 5. Execute as migrations
```bash
# Criar migration (se necessário)
dotnet ef migrations add InitialCreate --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API

# Aplicar migrations ao banco
dotnet ef database update --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API
```

### 6. Execute a aplicação
```bash
# Restaurar dependências
dotnet restore

# Executar a API
dotnet run --project CrudToAlgo.API
```

A API estará disponível em: `https://localhost:7000` ou `http://localhost:5000`

## 📚 Documentação da API

Após executar a aplicação, acesse a documentação interativa do Swagger:
- **Swagger UI**: `https://localhost:7000/swagger`

### 🔗 Principais Endpoints

#### Desafios
- `GET /api/desafios` - Lista todos os desafios
- `GET /api/desafios/{id}` - Busca desafio por ID

#### Submissões
- `POST /api/submissoes` - Criar nova submissão
- `GET /api/submissoes/{id}` - Buscar status da submissão

## 🗄️ Estrutura do Banco de Dados

```sql
-- Usuários da plataforma
usuarios (
  Id, Nome, Email, DataCadastro, Pontos
)

-- Desafios/problemas algorítmicos
desafios (
  Id, Titulo, Descricao, Dificuldade, Ativo, DataCriacao
)

-- Casos de teste para validação
casos_teste (
  Id, DesafioId, Entrada, SaidaEsperada, Publico
)

-- Submissões de código dos usuários
submissoes (
  Id, DesafioId, UsuarioId, Linguagem, Codigo, 
  DataEnvio, Status, PontosGanho
)
```

## 🐳 Docker

### Subir apenas o PostgreSQL
```bash
docker-compose up -d postgres
```

### Verificar containers em execução
```bash
docker ps
```

### Conectar ao PostgreSQL via CLI
```bash
docker exec -it crudtoalgo-postgres-1 psql -U postgres -d crudtoalgo_dev
```

## 🧪 Comandos Úteis do Entity Framework

### Migrations
```bash
# Criar nova migration
dotnet ef migrations add <NomeDaMigration> --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API

# Listar migrations
dotnet ef migrations list --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API

# Aplicar migrations
dotnet ef database update --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API

# Reverter para migration específica
dotnet ef database update <NomeDaMigration> --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API

# Remover última migration
dotnet ef migrations remove --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API
```

### Banco de Dados
```bash
# Deletar banco (cuidado!)
dotnet ef database drop --project CrudToAlgo.Infrastructure --startup-project CrudToAlgo.API --force
```

## 📈 Roadmap / Próximas Features

- [ ] 🔐 **Sistema de Autenticação** (JWT)
- [ ] 🏃‍♂️ **Executor de Código** (Judge0 ou sandbox próprio)
- [ ] 🏆 **Rankings e Leaderboards**
- [ ] 📊 **Dashboard com estatísticas**
- [ ] 🌐 **Frontend React/Blazor**
- [ ] 📧 **Sistema de notificações**
- [ ] 🔍 **Busca e filtros avançados**
- [ ] 📱 **API versioning**
- [ ] 🧪 **Testes automatizados**
- [ ] 🚀 **CI/CD Pipeline**

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 📧 Contato

**awernek** - GitHub: [@awernek](https://github.com/awernek)

Link do Projeto: [https://github.com/awernek/CrudToAlgo](https://github.com/awernek/CrudToAlgo)

---

⭐ **Gostou do projeto? Deixe uma star!** ⭐