using Moq;
using Xunit;
using _Nexus.Models;
using _Nexus.Repository.Interface;
using Nexus.UseCase;
using System.Collections.Generic;
using MongoDB.Bson;

public class ProdutoUseCaseTests
{
    private readonly Mock<IRepository<ProdutosModel>> _mockRepository;
    private readonly ProdutoUseCase _produtoUseCase;

    public ProdutoUseCaseTests()
    {
        _mockRepository = new Mock<IRepository<ProdutosModel>>();
        _produtoUseCase = new ProdutoUseCase(_mockRepository.Object);
    }

    [Fact]
    public void GetAllTasks_ShouldReturnAllProducts()
    {
        // Arrange
        var produtos = new List<ProdutosModel>
        {
            new ProdutosModel { Nome = "Produto 1", Preco = 10.0M, Stock = 5 },
            new ProdutosModel { Nome = "Produto 2", Preco = 15.0M, Stock = 3 }
        };
        _mockRepository.Setup(repo => repo.GetAll()).Returns(produtos);

        // Act
        var result = _produtoUseCase.GetAllProdutos();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void AddProdutos_ShouldGenerateIdIfEmpty()
    {
        // Arrange
        var produto = new ProdutosModel { Nome = "Novo Produto", Preco = 20.0M, Stock = 10 };

        // Act
        _produtoUseCase.AddProdutos(produto);

        // Assert
        Assert.NotEqual(ObjectId.Empty, produto.Id);
        _mockRepository.Verify(repo => repo.Add(produto), Times.Once);
    }

    [Fact]
    public void UpdateProduto_ShouldModifyProduct()
    {
        // Arrange
        var produto = new ProdutosModel { Nome = "Produto Teste", Preco = 25.0M, Stock = 10 };
        _mockRepository.Setup(repo => repo.GetById(produto.Id.ToString())).Returns(produto);

        // Act
        produto.Nome = "Produto Atualizado";
        _produtoUseCase.UpdateProdutos(produto);

        // Assert
        _mockRepository.Verify(repo => repo.Update(produto), Times.Once);
    }

    [Fact]
    public void DeleteProduto_ShouldRemoveProduct()
    {
        // Arrange
        var produto = new ProdutosModel { Nome = "Produto Teste", Preco = 25.0M, Stock = 10 };
        _mockRepository.Setup(repo => repo.GetById(produto.Id.ToString())).Returns(produto);

        // Act
        _produtoUseCase.DeleteProdutos(produto.Id.ToString());

        // Assert
        _mockRepository.Verify(repo => repo.Delete(produto.Id.ToString()), Times.Once);
    }
}
