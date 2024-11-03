<div align="center">
   <h2>⚜️ N E X U S ⚜️</h2>
</div>

<h3>👥 Integrantes do Grupo</h3>

- Matheus O.A.C Silva - RM 98502
- Amorgan M. Lopes - RM 98552
- Guilherme C. de Matos - RM 98874
- Gustavo G. da Silva - RM 99585
- Erick K. da Silva - RM 550371

## clean code

## Testes

## 📋 Endpoints

#### **Usuários**
- `GET /api/Users` - Retorna todos os usuários.
- `GET /api/Users/{id}` - Retorna um usuário específico por ID.
- `POST /api/Users` - Cria um novo usuário.
- `PUT /api/Users/{id}` - Atualiza um usuário existente por ID.
- `DELETE /api/Users/{id}` - Exclui um usuário por ID.

#### **Produtos**
- `GET /api/Produtos` - Retorna todos os produtos.
- `GET /api/Produtos/{id}` - Retorna um produto específico por ID.
- `POST /api/Produtos` - Cria um novo produto.
- `PUT /api/Produtos/{id}` - Atualiza um produto existente por ID.
- `DELETE /api/Produtos/{id}` - Exclui um produto por ID.

## 🚀 Como Rodar a Aplicação

Pré-requisitos:
- .NET 8 
- Oracle Database
- Visual Studio ou VS Code
- Git  

Passos:
1. Clone o repositório:
   ```bash
   git clone https://github.com/GuGodoi7/Nexus_sprint.git
   cd Nexus_sprint
   cd Nexus
2. Configure a string de conexão no appsettings.json:
    ```json
      {
        "ConnectionStrings": {
              "NXContext": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=xxxxx;Password=xxxxx;"
        }
      }
3. Crie as tabelas no seu banco de dados (Execute esse comando no Console do Gerenciador de Pacotes. Além disso, selecione '_Nexus.Database' como Projeto padrão):
     ```bash
   Update-Database

4. Restaure as dependências e execute a aplicação:
     ```bash
    dotnet restore
    dotnet run --launch-profile https
5. Acesse o Swagger (localhost varia de acordo com a maquina):
    ```bash
      https://localhost:7232/swagger/index.html
