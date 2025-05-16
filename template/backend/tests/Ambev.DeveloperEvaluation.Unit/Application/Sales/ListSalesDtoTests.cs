using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class ListSalesDtoTests
{
    [Fact]
    public void ListSalesDto_WithDefaultValues_ShouldHaveCorrectDefaults()
    {
        // Arrange & Act
        var dto = new ListSalesDto();

        // Assert
        Assert.Equal(1, dto.Page);
        Assert.Equal(10, dto.PageSize);
        Assert.Null(dto.SearchTerm);
        Assert.Null(dto.CustomerId);
        Assert.Null(dto.BranchId);
        Assert.Null(dto.PaymentMethod);
        Assert.Null(dto.StartDate);
        Assert.Null(dto.EndDate);
        Assert.Null(dto.SortBy);
        Assert.Null(dto.SortDirection);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ListSalesDto_WithInvalidPage_ShouldUseDefaultPage(int invalidPage)
    {
        // Arrange & Act
        var dto = new ListSalesDto { Page = invalidPage };

        // Assert
        Assert.Equal(1, dto.Page);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(101)]
    public void ListSalesDto_WithInvalidPageSize_ShouldUseDefaultPageSize(int invalidPageSize)
    {
        // Arrange & Act
        var dto = new ListSalesDto { PageSize = invalidPageSize };

        // Assert
        Assert.Equal(10, dto.PageSize);
    }

    [Fact]
    public void PaginatedSaleListDto_WithValidData_ShouldCalculateTotalPagesCorrectly()
    {
        // Arrange
        var dto = new PaginatedSaleListDto
        {
            Items = new List<SaleListItemDto>(),
            TotalItems = 25,
            Page = 2,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(3, dto.TotalPages); // 25 items with 10 per page = 3 pages
    }

    [Fact]
    public void PaginatedSaleListDto_WithEmptyList_ShouldHaveZeroTotalPages()
    {
        // Arrange
        var dto = new PaginatedSaleListDto
        {
            Items = new List<SaleListItemDto>(),
            TotalItems = 0,
            Page = 1,
            PageSize = 10
        };

        // Act & Assert
        Assert.Equal(0, dto.TotalPages);
    }

    [Fact]
    public void SaleListItemDto_WithValidData_ShouldMapCorrectly()
    {
        // Arrange & Act
        var dto = new SaleListItemDto
        {
            Id = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            CustomerName = "John Doe",
            BranchId = Guid.NewGuid(),
            BranchName = "Downtown Branch",
            TotalAmount = 99.99m,
            PaymentMethod = "CREDIT",
            CreatedAt = DateTime.UtcNow
        };

        // Assert
        Assert.NotEqual(Guid.Empty, dto.Id);
        Assert.NotEqual(Guid.Empty, dto.CustomerId);
        Assert.Equal("John Doe", dto.CustomerName);
        Assert.NotEqual(Guid.Empty, dto.BranchId);
        Assert.Equal("Downtown Branch", dto.BranchName);
        Assert.Equal(99.99m, dto.TotalAmount);
        Assert.Equal("CREDIT", dto.PaymentMethod);
        Assert.NotEqual(default, dto.CreatedAt);
    }

    [Fact]
    public void ListSalesDto_WithSearchTerm_ShouldPreserveSearchTerm()
    {
        // Arrange & Act
        var searchTerm = "John";
        var dto = new ListSalesDto { SearchTerm = searchTerm };

        // Assert
        Assert.Equal(searchTerm, dto.SearchTerm);
    }

    [Fact]
    public void ListSalesDto_WithCustomerId_ShouldPreserveCustomerId()
    {
        // Arrange & Act
        var customerId = Guid.NewGuid();
        var dto = new ListSalesDto { CustomerId = customerId };

        // Assert
        Assert.Equal(customerId, dto.CustomerId);
    }

    [Fact]
    public void ListSalesDto_WithBranchId_ShouldPreserveBranchId()
    {
        // Arrange & Act
        var branchId = Guid.NewGuid();
        var dto = new ListSalesDto { BranchId = branchId };

        // Assert
        Assert.Equal(branchId, dto.BranchId);
    }

    [Theory]
    [InlineData("CREDIT")]
    [InlineData("DEBIT")]
    [InlineData("CASH")]
    [InlineData("PIX")]
    public void ListSalesDto_WithValidPaymentMethod_ShouldPreservePaymentMethod(string paymentMethod)
    {
        // Arrange & Act
        var dto = new ListSalesDto { PaymentMethod = paymentMethod };

        // Assert
        Assert.Equal(paymentMethod, dto.PaymentMethod);
    }

    [Fact]
    public void ListSalesDto_WithDateRange_ShouldPreserveDateRange()
    {
        // Arrange & Act
        var startDate = DateTime.UtcNow.AddDays(-7);
        var endDate = DateTime.UtcNow;
        var dto = new ListSalesDto
        {
            StartDate = startDate,
            EndDate = endDate
        };

        // Assert
        Assert.Equal(startDate, dto.StartDate);
        Assert.Equal(endDate, dto.EndDate);
    }

    [Theory]
    [InlineData("createdAt")]
    [InlineData("totalAmount")]
    [InlineData("customerName")]
    public void ListSalesDto_WithValidSortBy_ShouldPreserveSortBy(string sortBy)
    {
        // Arrange & Act
        var dto = new ListSalesDto { SortBy = sortBy };

        // Assert
        Assert.Equal(sortBy, dto.SortBy);
    }

    [Theory]
    [InlineData("asc")]
    [InlineData("desc")]
    public void ListSalesDto_WithValidSortDirection_ShouldPreserveSortDirection(string sortDirection)
    {
        // Arrange & Act
        var dto = new ListSalesDto { SortDirection = sortDirection };

        // Assert
        Assert.Equal(sortDirection, dto.SortDirection);
    }
} 