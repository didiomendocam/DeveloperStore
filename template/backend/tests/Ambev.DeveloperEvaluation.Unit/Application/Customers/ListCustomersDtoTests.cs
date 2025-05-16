using Ambev.DeveloperEvaluation.Application.Customers.ListCustomers;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Customers;

public class ListCustomersDtoTests
{
    [Fact]
    public void ListCustomersDto_WithDefaultValues_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var dto = new ListCustomersDto();

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
    public void ListCustomersDto_WithInvalidPage_ShouldUseDefaultPage(int invalidPage)
    {
        // Arrange & Act
        var dto = new ListCustomersDto { Page = invalidPage };

        // Assert
        Assert.Equal(1, dto.Page);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(101)]
    public void ListCustomersDto_WithInvalidPageSize_ShouldUseDefaultPageSize(int invalidPageSize)
    {
        // Arrange & Act
        var dto = new ListCustomersDto { PageSize = invalidPageSize };

        // Assert
        Assert.Equal(10, dto.PageSize);
    }

    [Fact]
    public void PaginatedCustomerListDto_WithValidData_ShouldCalculateTotalPagesCorrectly()
    {
        // Arrange
        var dto = new PaginatedCustomerListDto
        {
            Items = new List<CustomerListItemDto>(),
            TotalItems = 25,
            Page = 2,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(3, dto.TotalPages); // 25 items with 10 per page = 3 pages
    }

    [Fact]
    public void PaginatedCustomerListDto_WithEmptyList_ShouldHaveZeroTotalPages()
    {
        // Arrange
        var dto = new PaginatedCustomerListDto
        {
            Items = new List<CustomerListItemDto>(),
            TotalItems = 0,
            Page = 1,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(0, dto.TotalPages);
    }

    [Fact]
    public void CustomerListItemDto_WithValidData_ShouldMapCorrectly()
    {
        // Arrange & Act
        var dto = new CustomerListItemDto
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Document = "12345678901",
            Contact = "john.doe@email.com",
            IsActive = true
        };

        // Assert
        Assert.NotEqual(Guid.Empty, dto.Id);
        Assert.Equal("John Doe", dto.Name);
        Assert.Equal("12345678901", dto.Document);
        Assert.Equal("john.doe@email.com", dto.Contact);
        Assert.True(dto.IsActive);
    }

    [Fact]
    public void ListCustomersDto_WithSearchTerm_ShouldPreserveSearchTerm()
    {
        // Arrange & Act
        var searchTerm = "John";
        var dto = new ListCustomersDto { SearchTerm = searchTerm };

        // Assert
        Assert.Equal(searchTerm, dto.SearchTerm);
    }

    [Fact]
    public void ListCustomersDto_WithOnlyActive_ShouldPreserveOnlyActive()
    {
        // Arrange & Act
        var dto = new ListCustomersDto { OnlyActive = true };

        // Assert
        Assert.True(dto.OnlyActive);
    }

    [Theory]
    [InlineData("name")]
    [InlineData("document")]
    [InlineData("createdAt")]
    public void ListCustomersDto_WithValidSortBy_ShouldPreserveSortBy(string sortBy)
    {
        // Arrange & Act
        var dto = new ListCustomersDto { SortBy = sortBy };

        // Assert
        Assert.Equal(sortBy, dto.SortBy);
    }

    [Theory]
    [InlineData("asc")]
    [InlineData("desc")]
    public void ListCustomersDto_WithValidSortDirection_ShouldPreserveSortDirection(string sortDirection)
    {
        // Arrange & Act
        var dto = new ListCustomersDto { SortDirection = sortDirection };

        // Assert
        Assert.Equal(sortDirection, dto.SortDirection);
    }
} 