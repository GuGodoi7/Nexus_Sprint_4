<div align="center">
   <h2>⚜️ N E X U S ⚜️</h2>
</div>

<h3>👥 Integrantes do Grupo</h3>

- Matheus O.A.C Silva - RM 98502
- Amorgan M. Lopes - RM 98552
- Guilherme C. de Matos - RM 98874
- Gustavo G. da Silva - RM 99585
- Erick K. da Silva - RM 550371

## 1. Clean Code
- **Nomes Significativos**: Todos os métodos e variáveis foram nomeados de forma descritiva, como `Add`, `Update`, `Delete`, e `GetById`, refletindo claramente suas responsabilidades. Isso facilita a compreensão do código por outros desenvolvedores.
  
- **Funções Pequenas**: O código foi estruturado de modo que cada função tenha uma única responsabilidade, tornando-o mais legível e testável. Por exemplo, métodos no repositório tratam apenas de operações de CRUD.

- **Evitar Código Duplicado**: Práticas de DRY (Don't Repeat Yourself) foram aplicadas, utilizando métodos auxiliares para evitar duplicação de lógica e facilitar a manutenção.

- **Comentários Úteis**: Comentários foram adicionados apenas onde necessário, explicando a lógica complexa, mas evitando comentários desnecessários que apenas repetem o que o código já expressa.

### 2. Princípios SOLID
- **Single Responsibility Principle (SRP)**: Cada classe foi projetada para ter uma única responsabilidade. Por exemplo, a classe `ProdutosModel` se concentra apenas em representar os dados de um produto, enquanto o `Repository` gerencia a persistência de dados.

- **Open/Closed Principle (OCP)**: O design do sistema permite que novas funcionalidades sejam adicionadas sem modificar o código existente. Isso foi alcançado através do uso de interfaces e abstrações, permitindo a extensão do sistema de maneira flexível.

- **Liskov Substitution Principle (LSP)**: As subclasses podem ser utilizadas em lugar de suas superclasses sem afetar a funcionalidade do programa. Isso foi garantido através da implementação de heranças corretas e do uso de interfaces.

- **Interface Segregation Principle (ISP)**: As interfaces foram divididas em componentes menores e específicos, evitando que os clientes dependessem de métodos que não utilizavam. Isso promove uma arquitetura mais limpa e compreensível.

- **Dependency Inversion Principle (DIP)**: A injeção de dependência foi utilizada para desacoplar classes, permitindo que dependências fossem passadas como parâmetros em vez de serem criadas diretamente dentro das classes. Isso melhora a testabilidade e a flexibilidade do código.

## Testes

## Recomendação

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
