using Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;
using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class ListBranchsServiceTests
{
    private readonly Mock<IBranchRepository> _branchRepositoryMock;
    private readonly ListBranchsService _service;

    public ListBranchsServiceTests()
    {
        _branchRepositoryMock = new Mock<IBranchRepository>();
        _service = new ListBranchsService(_branchRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_WithValidFilters_ShouldReturnPaginatedList()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = "São Paulo",
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        var branches = new List<Branch>
        {
            new Branch(
                "Filial São Paulo",
                "12345678901234",
                "Av. Paulista, 1000",
                "(11) 99999-9999",
                "sp@ambev.com.br",
                true
            ),
            new Branch(
                "Filial Rio de Janeiro",
                "98765432109876",
                "Av. Rio Branco, 1000",
                "(21) 99999-9999",
                "rj@ambev.com.br",
                true
            )
        };

        _branchRepositoryMock
            .Setup(x => x.GetBySearchTerm(dto.SearchTerm))
            .ReturnsAsync(branches);

        // Act
        var result = await _service.Execute(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalItems);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(1, result.TotalPages);
        Assert.Equal(2, result.Items.Count);
        _branchRepositoryMock.Verify(x => x.GetBySearchTerm(dto.SearchTerm), Times.Once);
    }

    [Fact]
    public async Task Execute_WithNoSearchTerm_ShouldReturnAllBranches()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = null,
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        var branches = new List<Branch>
        {
            new Branch(
                "Filial São Paulo",
                "12345678901234",
                "Av. Paulista, 1000",
                "(11) 99999-9999",
                "sp@ambev.com.br",
                true
            ),
            new Branch(
                "Filial Rio de Janeiro",
                "98765432109876",
                "Av. Rio Branco, 1000",
                "(21) 99999-9999",
                "rj@ambev.com.br",
                true
            )
        };

        _branchRepositoryMock
            .Setup(x => x.GetAll())
            .ReturnsAsync(branches);

        // Act
        var result = await _service.Execute(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalItems);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(1, result.TotalPages);
        Assert.Equal(2, result.Items.Count);
        _branchRepositoryMock.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact]
    public async Task Execute_WithOnlyActive_ShouldFilterActiveBranches()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = null,
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        var branches = new List<Branch>
        {
            new Branch(
                "Filial São Paulo",
                "12345678901234",
                "Av. Paulista, 1000",
                "(11) 99999-9999",
                "sp@ambev.com.br",
                true
            ),
            new Branch(
                "Filial Rio de Janeiro",
                "98765432109876",
                "Av. Rio Branco, 1000",
                "(21) 99999-9999",
                "rj@ambev.com.br",
                false
            )
        };

        _branchRepositoryMock
            .Setup(x => x.GetAll())
            .ReturnsAsync(branches);

        // Act
        var result = await _service.Execute(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalItems);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(1, result.TotalPages);
        Assert.Single(result.Items);
        Assert.True(result.Items[0].IsActive);
        _branchRepositoryMock.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact]
    public async Task Execute_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 1,
            PageSize = 10,
            SearchTerm = "São Paulo",
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        _branchRepositoryMock
            .Setup(x => x.GetBySearchTerm(dto.SearchTerm))
            .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.Execute(dto));
        _branchRepositoryMock.Verify(x => x.GetBySearchTerm(dto.SearchTerm), Times.Once);
    }
} 