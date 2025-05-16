using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class ListBranchsDtoTests
{
    [Fact]
    public void ListBranchsDto_WithDefaultValues_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var dto = new ListBranchsDto();

        // Assert
        Assert.Equal(1, dto.Page);
        Assert.Equal(10, dto.PageSize);
        Assert.Null(dto.SearchTerm);
        Assert.Null(dto.OnlyActive);
        Assert.Null(dto.SortBy);
        Assert.Null(dto.SortDirection);
    }

    [Fact]
    public void ListBranchsDto_WithCustomValues_ShouldSetValuesCorrectly()
    {
        // Arrange
        var dto = new ListBranchsDto
        {
            Page = 2,
            PageSize = 20,
            SearchTerm = "São Paulo",
            OnlyActive = true,
            SortBy = "name",
            SortDirection = "asc"
        };

        // Assert
        Assert.Equal(2, dto.Page);
        Assert.Equal(20, dto.PageSize);
        Assert.Equal("São Paulo", dto.SearchTerm);
        Assert.True(dto.OnlyActive);
        Assert.Equal("name", dto.SortBy);
        Assert.Equal("asc", dto.SortDirection);
    }

    [Fact]
    public void BranchListItemDto_WithValidData_ShouldSetValuesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new BranchListItemDto
        {
            Id = id,
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Assert
        Assert.Equal(id, dto.Id);
        Assert.Equal("Filial São Paulo", dto.Name);
        Assert.Equal("12345678901234", dto.Cnpj);
        Assert.Equal("Av. Paulista, 1000", dto.Address);
        Assert.Equal("(11) 99999-9999", dto.Phone);
        Assert.Equal("sp@ambev.com.br", dto.Email);
        Assert.True(dto.IsActive);
    }

    [Fact]
    public void PaginatedBranchListDto_WithValidData_ShouldSetValuesCorrectly()
    {
        // Arrange
        var items = new List<BranchListItemDto>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Filial São Paulo",
                Cnpj = "12345678901234",
                Address = "Av. Paulista, 1000",
                Phone = "(11) 99999-9999",
                Email = "sp@ambev.com.br",
                IsActive = true
            }
        };

        var dto = new PaginatedBranchListDto
        {
            Items = items,
            TotalItems = 1,
            Page = 1,
            PageSize = 10,
            TotalPages = 1
        };

        // Assert
        Assert.Single(dto.Items);
        Assert.Equal(1, dto.TotalItems);
        Assert.Equal(1, dto.Page);
        Assert.Equal(10, dto.PageSize);
        Assert.Equal(1, dto.TotalPages);
    }

    [Fact]
    public void PaginatedBranchListDto_WithMultiplePages_ShouldCalculateTotalPagesCorrectly()
    {
        // Arrange
        var items = new List<BranchListItemDto>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Filial São Paulo",
                Cnpj = "12345678901234",
                Address = "Av. Paulista, 1000",
                Phone = "(11) 99999-9999",
                Email = "sp@ambev.com.br",
                IsActive = true
            }
        };

        var dto = new PaginatedBranchListDto
        {
            Items = items,
            TotalItems = 25,
            Page = 2,
            PageSize = 10,
            TotalPages = 3
        };

        // Assert
        Assert.Single(dto.Items);
        Assert.Equal(25, dto.TotalItems);
        Assert.Equal(2, dto.Page);
        Assert.Equal(10, dto.PageSize);
        Assert.Equal(3, dto.TotalPages);
    }
} 