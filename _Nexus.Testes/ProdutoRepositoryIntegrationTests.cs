using _Nexus.Database;
using _Nexus.Models;
using _Nexus.Repository;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace _Nexus.Testes
{
    public class ProdutoRepositoryIntegrationTests : IDisposable
    {
        private NXContext _context;
        private Repository<ProdutosModel> _repository;

        public ProdutoRepositoryIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<NXContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new NXContext(options);
            _repository = new Repository<ProdutosModel>(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); 
            _context.Dispose();
        }

        [Fact]
        public void Add_ShouldPersistProduct()
        {
            // Arrange
            var product = new ProdutosModel
            {
                Nome = "Produto Teste",
                Preco = 25.0M,
                Stock = 10,
                Descricao = "Descrição do produto",
                Categoria = "Categoria Teste"
            };

            // Act
            _repository.Add(product);
            // Salvar as alterações no contexto
            _context.SaveChanges();
            var result = _repository.GetById(product.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Produto Teste", result.Nome);
        }

        [Fact]
        public void Update_ShouldModifyProduct()
        {
            // Arrange
            var product = new ProdutosModel
            {
                Nome = "Produto Teste",
                Preco = 25.0M,
                Stock = 10,
                Descricao = "Descrição do produto",
                Categoria = "Categoria Teste"
            };
            _repository.Add(product);
            _context.SaveChanges();
            product.Nome = "Produto Atualizado";

            // Act
            _repository.Update(product);
            _context.SaveChanges(); // Salva as alterações no contexto
            var updatedProduct = _repository.GetById(product.Id.ToString());

            // Assert
            Assert.Equal("Produto Atualizado", updatedProduct.Nome);
        }

        [Fact]
        public void Delete_ShouldRemoveProduct()
        {
            // Arrange
            var product = new ProdutosModel
            {
                Nome = "Produto Teste",
                Preco = 25.0M,
                Stock = 10,
                Descricao = "Descrição do produto",
                Categoria = "Categoria Teste"
            };
            _repository.Add(product);
            _context.SaveChanges();

            // Act
            _repository.Delete(product.Id.ToString());
            _context.SaveChanges(); // Salva as alterações no contexto
            var result = _repository.GetById(product.Id.ToString());

            // Assert
            Assert.Null(result);
        }
    }
}
