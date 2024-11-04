<div align="center">
   <h2>⚜️ N E X U S ⚜️</h2>
</div>

<h3>👥 Integrantes do Grupo</h3>

- Matheus O.A.C Silva - RM 98502
- Amorgan M. Lopes - RM 98552
- Guilherme C. de Matos - RM 98874
- Gustavo G. da Silva - RM 99585
- Erick K. da Silva - RM 550371
- --------------------------------------------------
## 🏛 Arquitetura<h3>

Optamos por uma arquitetura monolítica pois o projeto tem um escopo definido e as funcionalidades são bem integradas, facilitando a comunicação entre os módulos. Além disso, como a aplicação é menor, o desenvolvimento e os testes são mais simples, já que se lida com um único aplicativo. Não há expectativa de grande crescimento ou mudanças complexas no curto prazo, então o monolito é mais prático e econômico para as necessidades atuais. Também ajuda a economizar nos custos de infraestrutura.
- --------------------------------------------------
## 📚 Projeto 

<p>Bem-vindo ao Nexus. O projeto consiste no desenvolvimento de um Chatbot funcional que utiliza o WhatsApp como plataforma principal. Esse Chatbot será capaz de se integrar a diversos sistemas externos, como APIs de inteligência artificial, e-commerce, e sistemas de recomendações. Isso permitirá oferecer um atendimento personalizado e eficaz aos clientes e usuários.</p>
<p>O público-alvo do projeto Nexus são empresas que buscam soluções inovadoras para melhorar o atendimento ao cliente, aumentando assim, sua satisfação e consequentemente otimizando suas operações comerciais.</p>

<br/>

- --------------------------------------------------
## 🧠 Design Patterns Utilizados

- **Singleton**: Gerenciamento de configurações.
- **Repository Pattern**: Para abstração do acesso a dados.
- **Service Layer**: Desacoplamento da lógica de negócios.
- --------------------------------------------------
## 🧠 Práticas de Clean Code Utilizadas

- **Nomes Significativos**: Todos os métodos e variáveis foram nomeados de forma descritiva, como `Add`, `Update`, `Delete` e `GetById`, refletindo claramente suas responsabilidades. Isso facilita a compreensão do código por outros desenvolvedores.
  
- **Funções Pequenas**: O código foi estruturado de modo que cada função tenha uma única responsabilidade, tornando-o mais legível e testável. Por exemplo, métodos no repositório tratam apenas de operações de CRUD.

- **Evitar Código Duplicado**: Práticas de **DRY (Don't Repeat Yourself)** foram aplicadas, utilizando métodos auxiliares para evitar duplicação de lógica e facilitar a manutenção.

- **Single Responsibility Principle (SRP)**: Cada classe foi projetada para ter uma única responsabilidade. Por exemplo, a classe `ProdutosModel` se concentra apenas em representar os dados de um produto, enquanto o `Repository` gerencia a persistência de dados.

- **Open/Closed Principle (OCP)**: O design do sistema permite que novas funcionalidades sejam adicionadas sem modificar o código existente. Isso foi alcançado através do uso de interfaces e abstrações, permitindo a extensão do sistema de maneira flexível.

- **Liskov Substitution Principle (LSP)**: As subclasses podem ser utilizadas em lugar de suas superclasses sem afetar a funcionalidade do programa. Isso foi garantido através da implementação de heranças corretas e do uso de interfaces.

- **Interface Segregation Principle (ISP)**: As interfaces foram divididas em componentes menores e específicos, evitando que os clientes dependessem de métodos que não utilizavam. Isso promove uma arquitetura mais limpa e compreensível.

- **Dependency Inversion Principle (DIP)**: A injeção de dependência foi utilizada para desacoplar classes, permitindo que dependências fossem passadas como parâmetros em vez de serem criadas diretamente dentro das classes. Isso melhora a testabilidade e a flexibilidade do código.

- --------------------------------------------------
## 💻 Testes

### Testes Unitários
Os testes unitarios são fundamentais para garantir a qualidade e a funcionalidade do código. Os seguintes testes foram implementados:

- **ProdutoUseCaseTests**: 
  - Verifica a funcionalidade dos métodos como `GetAllProdutos`, `AddProdutos`, entre outros, assegurando que cada método se comporte como esperado.

- **UsuarioUseCaseTests**: 
  - Garante a criação e recuperação de usuários, testando a lógica de autenticação e manipulação de dados.

### Testes de Integração
Os testes de integração são essenciais para validar a interação entre diferentes componentes do sistema. Os seguintes testes foram implementados:

- **ProdutoRepositoryIntegrationTests**: 
  - Valida a persistência de dados no repositório, incluindo operações de adicionar, atualizar e excluir produtos. Esses testes garantem que as operações no banco de dados funcionem corretamente e que as mudanças sejam refletidas de forma adequada.

- --------------------------------------------------
## 🎁 Recomendação
# Sistema de Recomendação com ML.NET

Este projeto implementa um sistema de recomendação utilizando **ML.NET** para gerar sugestões personalizadas de produtos para usuários, com base nas avaliações e nos produtos previamente curtidos. A API inclui também funcionalidades de IA generativa, permitindo que o usuário receba recomendações personalizadas.

## Estrutura do Sistema de Recomendação

A classe **RecommendationEngine** é responsável pelo treinamento e pela previsão das recomendações de produtos. Ela utiliza uma técnica de **fatoração de matriz (Matrix Factorization)**, uma abordagem comum em sistemas de recomendação para prever avaliações de produtos.

## Componentes e Fluxo do Sistema

### Treinamento do Modelo

- O método **TrainModel** coleta dados da tabela **UsuarioLike** e os converte em instâncias de **ProductRating**.  
  Essas instâncias representam as avaliações de produtos e são usadas para treinar o modelo de recomendação.
- Durante o treinamento, a técnica de fatoração de matriz ajusta o modelo para entender as preferências do usuário com base nas avaliações passadas.

### Predição de Recomendação

- O método **Predict** prevê uma pontuação de recomendação para um produto específico com base no histórico de interações do usuário.  
  Para isso, o modelo considera os produtos que o usuário já avaliou ou curtiu e sugere novos produtos similares com base nas preferências anteriores.

### Funcionalidade de IA Generativa e API

Para facilitar o uso da recomendação, a API possui um controlador específico para lidar com as recomendações.

#### RecommendationController

O **RecommendationController** expõe o endpoint **/GetRecommendations**, que fornece sugestões de produtos para um usuário específico. Este controlador trabalha da seguinte forma:

1. **Endpoint de Recomendação (GetRecommendations)**:
   - O controlador chama a **RecommendationEngine** para obter sugestões de produtos com base nas interações do usuário.
   - A lógica implementada verifica produtos semelhantes por categoria, garantindo que produtos já curtidos pelo usuário não sejam recomendados novamente.

2. **Filtro de Recomendação**:
   - A API exclui produtos que o usuário já curtiu, concentrando-se em recomendar produtos similares que ele ainda não conhece.

- --------------------------------------------------
## 🔏 Autenticação
Este projeto implementa um sistema de autenticação que garante a segurança das operações da API, utilizando um método de autenticação baseado em **token fixo**. O objetivo é assegurar que apenas usuários autorizados possam acessar os recursos da aplicação.

## Implementação da Autenticação

A autenticação é realizada através de um token fixo, que deve ser incluído no cabeçalho das requisições. O sistema utiliza classes e middleware do **ASP.NET Core** para gerenciar a autenticação de forma eficiente.

## Classes e Configuração

### TokenAuthenticationOptions

- Esta classe estende **AuthenticationSchemeOptions** e contém a propriedade **Token**, que armazena o token fixo utilizado para a autenticação.

### TokenAuthenticationHandler

- Extende **AuthenticationHandler<TokenAuthenticationOptions>** e implementa a lógica de autenticação. 
- O método **HandleAuthenticateAsync** verifica se o cabeçalho **"Authorization"** está presente e se o token fornecido corresponde ao token fixo definido nas opções.
- Se o token for válido, cria uma identidade e um principal que são retornados como resultado da autenticação.

### TokenAuthenticationMiddleware

- Este middleware verifica o cabeçalho **"Authorization"** em cada requisição, retornando um erro **401 (Unauthorized)** caso o cabeçalho esteja ausente ou o token fornecido seja inválido.
- O middleware é aplicado antes da execução das requisições, garantindo que apenas usuários autenticados possam prosseguir.

- --------------------------------------------------
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

- --------------------------------------------------
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
       "MongoDbConnectionString": "",
       "MongoDbDatabase": ""
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
6. Para fazer as requisições coloque "Bearer YeObXpVpKCJw1I4En8ArK1621qBG0IWkQvCK86728139b86651" para realizar autenticação
