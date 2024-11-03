using _Nexus.Database;
using _Nexus.Models;
using _Nexus.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace _Nexus.Testes.IntegrationTests
{
    public class RepositoryTests
    {
        private readonly NXContext _context;
        private readonly Repository<ProdutosModel> _repository;

        public RepositoryTests()
        {
            // Configura o contexto para usar o InMemoryDatabase
            var options = new DbContextOptionsBuilder<NXContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new NXContext(options);
            _repository = new Repository<ProdutosModel>(_context);
        }

        [Fact]
        public void Add_ShouldAddEntityToDatabase()
        {
            // Inicializa a entidade com valores
            var entity = new ProdutosModel
            {
                Nome = "Produto A",
                Preco = 10.99m,
                Stock = 100,
                Descricao = "Descrição do Produto A",
                Categoria = "Categoria A"
            };

            _repository.Add(entity);

            var allEntities = _repository.GetAll();
            Assert.Contains(entity, allEntities);
        }

        [Fact]
        public void GetById_ShouldReturnEntity_WhenIdIsValid()
        {
            var entity = new ProdutosModel
            {
                Nome = "Produto B",
                Preco = 15.49m,
                Stock = 50,
                Descricao = "Descrição do Produto B",
                Categoria = "Categoria B"
            };

            _repository.Add(entity);

            var retrievedEntity = _repository.GetById(entity.Id.ToString());
            Assert.Equal(entity.Nome, retrievedEntity.Nome);
            Assert.Equal(entity.Preco, retrievedEntity.Preco);
            Assert.Equal(entity.Stock, retrievedEntity.Stock);
            Assert.Equal(entity.Descricao, retrievedEntity.Descricao);
            Assert.Equal(entity.Categoria, retrievedEntity.Categoria);
        }

        [Fact]
        public void Update_ShouldModifyEntityInDatabase()
        {
            var entity = new ProdutosModel
            {
                Nome = "Produto C",
                Preco = 20.00m,
                Stock = 30,
                Descricao = "Descrição do Produto C",
                Categoria = "Categoria C"
            };

            _repository.Add(entity);

            // Modifica uma propriedade e atualiza
            entity.Nome = "Produto C Atualizado";
            _repository.Update(entity);

            var updatedEntity = _repository.GetById(entity.Id.ToString());
            Assert.Equal("Produto C Atualizado", updatedEntity.Nome);
        }

        [Fact]
        public void Delete_ShouldRemoveEntityFromDatabase()
        {
            var entity = new ProdutosModel
            {
                Nome = "Produto D",
                Preco = 5.00m,
                Stock = 20,
                Descricao = "Descrição do Produto D",
                Categoria = "Categoria D"
            };

            _repository.Add(entity);

            _repository.Delete(entity.Id.ToString());
            var allEntities = _repository.GetAll();
            Assert.DoesNotContain(entity, allEntities);
        }
    }
}
