namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// DTO for listing sales with pagination.
/// </summary>
public class ListSalesDto
{
    /// <summary>
    /// Page number (1-based).
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// Search term to filter sales by customer name, branch name, or product name.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Filter sales by customer ID.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Filter sales by branch ID.
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Filter sales by payment method.
    /// </summary>
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// Filter sales by start date.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Filter sales by end date.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Sort field (e.g., "createdAt", "totalAmount", "customerName").
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction ("asc" or "desc").
    /// </summary>
    public string? SortDirection { get; set; }
}

/// <summary>
/// DTO for sale list item.
/// </summary>
public class SaleListItemDto
{
    /// <summary>
    /// Unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ID of the customer who made the purchase.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Name of the customer who made the purchase.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// ID of the branch where the sale was made.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Name of the branch where the sale was made.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Payment method used for the sale.
    /// </summary>
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// Date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// DTO for paginated sale list response.
/// </summary>
public class PaginatedSaleListDto
{
    /// <summary>
    /// List of sales in the current page.
    /// </summary>
    public List<SaleListItemDto> Items { get; set; } = new();

    /// <summary>
    /// Total number of items across all pages.
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// Current page number.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    public int TotalPages { get; set; }
} 