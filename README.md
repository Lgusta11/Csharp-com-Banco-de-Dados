```markdown
# Screen Sound 3.0

[![Licença](https://img.shields.io/badge/licença-MIT-blue.svg)](LICENSE)

O Screen Sound 3.0 é uma aplicação de console para gerenciar artistas e suas músicas.

## Recursos

- **Gerenciamento de Artistas:** Adicione, atualize, exclua e exiba informações sobre artistas.
- **Gerenciamento de Músicas:** Registre e gerencie músicas associadas aos artistas.

## Começando

### Pré-requisitos

- .NET SDK
- MySQL Server

### Instalação

1. Clone o repositório:

   ```bash
   https://github.com/Lgusta11/Csharp-com-Banco-de-Dados
   cd screensound
   ```

2. Restaure as dependências:

   ```bash
   dotnet restore
   ```

3. Configure a conexão com o banco de dados:

   - Abra o arquivo `appsettings.json` e atualize a seção `ConnectionStrings` com os detalhes do seu servidor MySQL.

4. Aplique as migrações do banco de dados:

   ```bash
   dotnet ef database update
   ```

5. Execute a aplicação:

   ```bash
   dotnet run
   ```



