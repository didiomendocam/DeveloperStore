using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class GetBranchServiceTests
{
    private readonly Mock<IBranchRepository> _branchRepositoryMock;
    private readonly GetBranchService _service;

    public GetBranchServiceTests()
    {
        _branchRepositoryMock = new Mock<IBranchRepository>();
        _service = new GetBranchService(_branchRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_WithValidId_ShouldReturnBranch()
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

        // Act
        var result = await _service.Execute(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(branch.Id, result.Id);
        Assert.Equal(branch.Name, result.Name);
        Assert.Equal(branch.Cnpj, result.Cnpj);
        Assert.Equal(branch.Address, result.Address);
        Assert.Equal(branch.Phone, result.Phone);
        Assert.Equal(branch.Email, result.Email);
        Assert.Equal(branch.IsActive, result.IsActive);
        Assert.Equal(branch.CreatedAt, result.CreatedAt);
        Assert.Equal(branch.UpdatedAt, result.UpdatedAt);
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
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
    }

    [Fact]
    public async Task Execute_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var id = Guid.NewGuid();

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.Execute(id));
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
    }
} 