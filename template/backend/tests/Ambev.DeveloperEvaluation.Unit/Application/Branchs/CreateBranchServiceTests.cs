using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class CreateBranchServiceTests
{
    private readonly Mock<IBranchRepository> _branchRepositoryMock;
    private readonly CreateBranchService _service;

    public CreateBranchServiceTests()
    {
        _branchRepositoryMock = new Mock<IBranchRepository>();
        _service = new CreateBranchService(_branchRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_WithValidData_ShouldCreateBranch()
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        _branchRepositoryMock
            .Setup(x => x.Add(It.IsAny<Branch>()))
            .Returns(Task.CompletedTask);

        _branchRepositoryMock
            .Setup(x => x.SaveChanges())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.Execute(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _branchRepositoryMock.Verify(x => x.Add(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public async Task Execute_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        _branchRepositoryMock
            .Setup(x => x.Add(It.IsAny<Branch>()))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.Execute(dto));
        _branchRepositoryMock.Verify(x => x.Add(It.IsAny<Branch>()), Times.Once);
        _branchRepositoryMock.Verify(x => x.SaveChanges(), Times.Never);
    }
} 