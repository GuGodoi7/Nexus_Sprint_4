using Moq;
using Xunit;
using _Nexus.Models;
using _Nexus.Repository.Interface;
using Nexus.UseCase;
using System.Collections.Generic;
using _Nexus.Services.CepService;

public class UsuarioUseCaseTests
{
    private readonly Mock<IRepository<UsuarioModel>> _mockUserRepository;
    private readonly Mock<IRepository<UsuarioLike>> _mockUserLikeRepository;
    private readonly Mock<ICEP> _mockCepService; 
    private readonly UsuarioUseCase _usuarioUseCase;

    public UsuarioUseCaseTests()
    {
        _mockUserRepository = new Mock<IRepository<UsuarioModel>>();
        _mockUserLikeRepository = new Mock<IRepository<UsuarioLike>>();
        _mockCepService = new Mock<ICEP>(); 


        _usuarioUseCase = new UsuarioUseCase(_mockUserRepository.Object, _mockCepService.Object, _mockUserLikeRepository.Object);
    }

    [Fact]
    public void CreateUser_ShouldAddUser()
    {
        // Arrange
        var userRequest = new UsuarioRequest { NomeUsuario = "User1", Email = "user1@example.com", Password = "password" };
        var user = new UsuarioModel(userRequest.Email, userRequest.Password);

        // Act
        _usuarioUseCase.CreateUser(userRequest);

        // Assert
        _mockUserRepository.Verify(repo => repo.Add(It.Is<UsuarioModel>(u => u.Email == userRequest.Email)), Times.Once);
    }

    [Fact]
    public void GetUsers_ShouldReturnAllUsers()
    {
        // Arrange
        var users = new List<UsuarioModel>
        {
            new UsuarioModel("user1@example.com", "password") { NomeUsuario = "User 1" },
            new UsuarioModel("user2@example.com", "password") { NomeUsuario = "User 2" }
        };
        _mockUserRepository.Setup(repo => repo.GetAll()).Returns(users);

        // Act
        var result = _usuarioUseCase.GetUsers();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void DeleteUser_ShouldRemoveUser()
    {
        // Arrange
        var user = new UsuarioModel("user@test.com", "password");
        _mockUserRepository.Setup(repo => repo.GetById(user.Id.ToString())).Returns(user);

        // Act
        _usuarioUseCase.DeleteUser(user.Id.ToString());

        // Assert
        _mockUserRepository.Verify(repo => repo.Delete(user.Id.ToString()), Times.Once);
    }
}
