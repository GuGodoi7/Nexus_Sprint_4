<div align="center">
   <h2>⚜️ N E X U S ⚜️</h2>
</div>
<h3> 👥 Integrantes do Grupo </h3>

- Matheus O.A.C Silva - RM 98502
- Amorgan M. Lopes - RM 98552
- Guilherme C. de Matos - RM 98874
- Gustavo G. da Silva - RM 99585
- Erick K. da Silva - RM 550371

---

## 🏛 Arquitetura

Optamos por uma arquitetura monolítica devido ao escopo definido do projeto e à integração entre as funcionalidades, que facilita a comunicação entre os módulos. A escolha pelo monólito simplifica o desenvolvimento e os testes, sendo ideal para a aplicação atual, sem previsão de expansão ou mudanças complexas. Esse modelo também reduz os custos de infraestrutura.

---

## 📚 Projeto

Bem-vindo ao **Nexus**! Este projeto consiste no desenvolvimento de um Chatbot funcional, usando o WhatsApp como plataforma principal. Nosso Chatbot se integra a sistemas externos, como APIs de IA e e-commerce, oferecendo atendimento personalizado e eficaz para empresas que buscam soluções inovadoras para melhorar o atendimento ao cliente.

### Público-alvo
Empresas que buscam melhorar o atendimento ao cliente, otimizando suas operações comerciais com tecnologia de ponta.

---

## 🧠 Design Patterns Utilizados
- **Singleton**: Gerenciamento de configurações.
- **Repository Pattern**: Abstração do acesso a dados.
- **Service Layer**: Desacoplamento da lógica de negócios.

---

## 🧠 Práticas de Clean Code Utilizadas
- **Nomes Significativos**: Métodos e variáveis nomeados de forma descritiva para clareza.
- **Funções Pequenas**: Cada função tem uma única responsabilidade.
- **Evitar Código Duplicado**: Aplicação do princípio **DRY**.
- **Princípios SOLID**: Aderência aos princípios SRP, OCP, LSP, ISP e DIP para uma arquitetura limpa e testável.

---

## 💻 Testes

### Testes Unitários
- **ProdutoUseCaseTests**: Testa métodos como `GetAllProdutos`, `AddProdutos` para garantir funcionalidade.
- **UsuarioUseCaseTests**: Valida criação e recuperação de usuários e lógica de autenticação.
- **CEPMoqTest**: Utiliza o framework Moq para simular o comportamento do serviço de CEP. Testa a função FindCEP, assegurando que um CEP válido retorna um objeto AddressResponse correto e não nulo, enquanto o uso de um CEP inválido deve resultar em null, garantindo a integridade e a robustez do sistema ao lidar com diferentes entradas.
- **CEPTest**: Verifica a funcionalidade de busca de endereços por CEP, validando que um CEP válido retorna um objeto AddressResponse, enquanto um CEP inválido resulta em null, assegurando o tratamento adequado de entradas.

### Testes de Integração
- **ProdutoRepositoryIntegrationTests**: Verifica persistência no repositório, garantindo operações corretas no banco de dados.

---

## 🎁 Recomendação
### Sistema de Recomendação com ML.NET
Este projeto usa **ML.NET** para sugerir produtos com base nas interações do usuário. A classe **RecommendationEngine** aplica **fatoração de matriz** para previsão de preferências.

#### Principais Componentes
1. **Treinamento**: Coleta dados e treina o modelo para compreender preferências do usuário.
2. **Predição**: Prevê recomendações com base no histórico de interações.
3. **Funcionalidade de IA Generativa e API**: O controlador **RecommendationController** gerencia o endpoint `/GetRecommendations`.

---

## 🔏 Autenticação
Implementação de autenticação por **token fixo** para garantir segurança nas operações da API.

### Componentes
- **TokenAuthenticationOptions**: Armazena o token fixo para autenticação.
- **TokenAuthenticationHandler**: Lida com a lógica de autenticação.
- **TokenAuthenticationMiddleware**: Verifica o cabeçalho de autorização em cada requisição.

### TOKEN
 - Para realizar as requisições, adicione "Bearer YeObXpVpKCJw1I4En8ArK1621qBG0IWkQvCK86728139b86651" no cabeçalho dos endpoints.



---

## 📋 Endpoints
### Usuários
- `GET /api/Users` - Retorna todos os usuários.
- `GET /api/Users/{id}` - Retorna um usuário específico.
- `POST /api/Users` - Cria um novo usuário.
- `PUT /api/Users/{id}` - Atualiza um usuário existente.
- `DELETE /api/Users/{id}` - Exclui um usuário.

### Produtos
- `GET /api/Produtos` - Retorna todos os produtos.
- `GET /api/Produtos/{id}` - Retorna um produto específico.
- `POST /api/Produtos` - Cria um novo produto.
- `PUT /api/Produtos/{id}` - Atualiza um produto existente.
- `DELETE /api/Produtos/{id}` - Exclui um produto.

### Recomendações
- `GET /api/recomendacao/{userId}` - Recomenda um produto de acordo com a curtida do usuario.
### CEP
- `GET /CEP` - Retorna Dados de acordo com o CEP.
---

## 🚀 Como Rodar a Aplicação

Pré-requisitos:
- .NET 8 
- Oracle Database
- Visual Studio ou VS Code
- Git  

Passos:
1. Clone o repositório:
   ```bash
   git clone https://github.com/GuGodoi7/Nexus_Sprint_4.git
   cd Nexus_Sprint_4
   cd Nexus
2. Configure a string de conexão com o mongoDB no appsettings.json:
    ```json
    {
       "MongoDbConnectionString": "",
       "MongoDbDatabase": ""
    }     

3. Restaure as dependências e execute a aplicação:
     ```bash
    dotnet restore
    dotnet run --launch-profile https
4. Acesse o Swagger (localhost varia de acordo com a maquina):
    ```bash
      https://localhost:7232/swagger/index.html
    
5. Para realizar as requisições, adicione "Bearer YeObXpVpKCJw1I4En8ArK1621qBG0IWkQvCK86728139b86651" no cabeçalho dos endpoints.
