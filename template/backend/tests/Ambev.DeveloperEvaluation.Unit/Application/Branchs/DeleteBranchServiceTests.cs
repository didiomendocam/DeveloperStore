using Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;
using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class DeleteBranchServiceTests
{
    private readonly Mock<IBranchRepository> _branchRepositoryMock;
    private readonly DeleteBranchService _service;

    public DeleteBranchServiceTests()
    {
        _branchRepositoryMock = new Mock<IBranchRepository>();
        _service = new DeleteBranchService(_branchRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_WithValidId_ShouldDeleteBranch()
    {
        // Arrange
        var id = Guid.NewGuid();
        var branch = new Branch(
            "Filial São Paulo",
            "12345678901234",
            "Av. Paulista, 1000",
            "(11) 99999-9999",
            "sp@ambev.com.br",
            true
        );

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync(branch);

        _branchRepositoryMock
            .Setup(x => x.Delete(It.IsAny<Branch>()))
            .Returns(Task.CompletedTask);

        _branchRepositoryMock
            .Setup(x => x.SaveChanges())
            .Returns(Task.CompletedTask);

        // Act
        await _service.Execute(id);

        // Assert
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Delete(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task Execute_WhenBranchNotFound_ShouldThrowException()
    {
        // Arrange
        var id = Guid.NewGuid();

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync((Branch?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => _service.Execute(id));
        Assert.Equal($"Branch with id {id} not found", exception.Message);
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Delete(It.IsAny<Branch>()), Times.Never);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task Execute_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var id = Guid.NewGuid();
        var branch = new Branch(
            "Filial São Paulo",
            "12345678901234",
            "Av. Paulista, 1000",
            "(11) 99999-9999",
            "sp@ambev.com.br",
            true
        );

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync(branch);

        _branchRepositoryMock
            .Setup(x => x.Delete(It.IsAny<Branch>()))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.Execute(id));
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Delete(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Never);
    }
} 