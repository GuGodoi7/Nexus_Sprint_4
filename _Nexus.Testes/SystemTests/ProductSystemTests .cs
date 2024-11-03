using _Nexus.Models;
using MongoDB.Bson;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace _Nexus.Testes.SystemTests
{
    public class ProductControllerTests
    {
        private readonly HttpClient _client;

        public ProductControllerTests()
        {
            // Inicialize seu cliente HTTP e configure o contexto aqui, se necess�rio
            _client = new HttpClient(); // ou use uma inst�ncia do WebApplicationFactory
        }

        [Fact]
        public async Task GetProduct_ShouldReturnProduct_WhenIdIsSimulated()
        {
            // Arrange
            // Simular um ID de produto existente
            var simulatedId = ObjectId.GenerateNewId().ToString(); // Gera um novo ID
            var simulatedProduct = new ProdutosModel
            {
                Id = ObjectId.Parse(simulatedId), // Usa o ID simulado
                Nome = "Produto Simulado",
                Preco = 9.99m,
                Stock = 10,
                Descricao = "Descri��o do Produto Simulado",
                Categoria = "Categoria Simulada"
            };

            // Aqui voc� deve adicionar o produto simulado ao banco de dados em mem�ria
            // Por exemplo: _context.Produtos.Add(simulatedProduct);
            // Lembre-se de chamar SaveChanges() se estiver usando um contexto de EF

            // Act
            var response = await _client.GetAsync($"/api/produtos/{simulatedId}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            // Voc� pode tamb�m verificar o conte�do da resposta para garantir que � o produto simulado
        }
    }
}
