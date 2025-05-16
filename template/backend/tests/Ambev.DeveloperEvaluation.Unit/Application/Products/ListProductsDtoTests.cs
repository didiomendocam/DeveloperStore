using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class ListProductsDtoTests
{
    [Fact]
    public void ListProductsDto_WithDefaultValues_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var dto = new ListProductsDto();

        // Assert
        Assert.Equal(1, dto.Page);
        Assert.Equal(10, dto.PageSize);
        Assert.Null(dto.SearchTerm);
        Assert.Null(dto.OnlyActive);
        Assert.Null(dto.SortBy);
        Assert.Null(dto.SortDirection);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ListProductsDto_WithInvalidPage_ShouldUseDefaultPage(int invalidPage)
    {
        // Arrange & Act
        var dto = new ListProductsDto { Page = invalidPage };

        // Assert
        Assert.Equal(1, dto.Page);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(101)]
    public void ListProductsDto_WithInvalidPageSize_ShouldUseDefaultPageSize(int invalidPageSize)
    {
        // Arrange & Act
        var dto = new ListProductsDto { PageSize = invalidPageSize };

        // Assert
        Assert.Equal(10, dto.PageSize);
    }

    [Fact]
    public void PaginatedProductListDto_WithValidData_ShouldCalculateTotalPagesCorrectly()
    {
        // Arrange
        var dto = new PaginatedProductListDto
        {
            Items = new List<ProductListItemDto>(),
            TotalItems = 25,
            Page = 2,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(3, dto.TotalPages); // 25 items with 10 per page = 3 pages
    }

    [Fact]
    public void PaginatedProductListDto_WithEmptyList_ShouldHaveZeroTotalPages()
    {
        // Arrange
        var dto = new PaginatedProductListDto
        {
            Items = new List<ProductListItemDto>(),
            TotalItems = 0,
            Page = 1,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(0, dto.TotalPages);
    }

    [Fact]
    public void ProductListItemDto_WithValidData_ShouldMapCorrectly()
    {
        // Arrange & Act
        var dto = new ProductListItemDto
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            UnitPrice = 10.99m,
            StockQuantity = 100,
            IsActive = true
        };

        // Assert
        Assert.NotEqual(Guid.Empty, dto.Id);
        Assert.Equal("Test Product", dto.Name);
        Assert.Equal(10.99m, dto.UnitPrice);
        Assert.Equal(100, dto.StockQuantity);
        Assert.True(dto.IsActive);
    }
} 