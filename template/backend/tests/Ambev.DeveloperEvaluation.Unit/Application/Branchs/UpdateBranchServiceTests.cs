using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class UpdateBranchServiceTests
{
    private readonly Mock<IBranchRepository> _branchRepositoryMock;
    private readonly UpdateBranchService _service;

    public UpdateBranchServiceTests()
    {
        _branchRepositoryMock = new Mock<IBranchRepository>();
        _service = new UpdateBranchService(_branchRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_WithValidData_ShouldUpdateBranch()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new UpdateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        var branch = new Branch(
            "Filial Rio de Janeiro",
            "98765432109876",
            "Av. Rio Branco, 1000",
            "(21) 99999-9999",
            "rj@ambev.com.br",
            true
        );

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync(branch);

        _branchRepositoryMock
            .Setup(x => x.Update(It.IsAny<Branch>()))
            .Returns(Task.CompletedTask);

        _branchRepositoryMock
            .Setup(x => x.SaveChanges())
            .Returns(Task.CompletedTask);

        // Act
        await _service.Execute(id, dto);

        // Assert
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Update(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task Execute_WhenBranchNotFound_ShouldThrowException()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new UpdateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync((Branch?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => _service.Execute(id, dto));
        Assert.Equal($"Branch with id {id} not found", exception.Message);
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Update(It.IsAny<Branch>()), Times.Never);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Never);
    }

    [Fact]
    public async Task Execute_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new UpdateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        var branch = new Branch(
            "Filial Rio de Janeiro",
            "98765432109876",
            "Av. Rio Branco, 1000",
            "(21) 99999-9999",
            "rj@ambev.com.br",
            true
        );

        _branchRepositoryMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync(branch);

        _branchRepositoryMock
            .Setup(x => x.Update(It.IsAny<Branch>()))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.Execute(id, dto));
        _branchRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        _branchRepositoryMock.Verify(x => x.Update(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Never);
    }
} 