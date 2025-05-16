namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

/// <summary>
/// DTO for listing products with pagination.
/// </summary>
public class ListProductsDto
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
    /// Search term to filter products by name or description.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Filter to show only active products.
    /// </summary>
    public bool? OnlyActive { get; set; }

    /// <summary>
    /// Sort field (e.g., "name", "price", "stock").
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction ("asc" or "desc").
    /// </summary>
    public string? SortDirection { get; set; }
}

/// <summary>
/// DTO for product list item.
/// </summary>
public class ProductListItemDto
{
    /// <summary>
    /// Unique identifier of the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Stock quantity of the product.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Indicates if the product is active.
    /// </summary>
    public bool IsActive { get; set; }
}

/// <summary>
/// DTO for paginated product list response.
/// </summary>
public class PaginatedProductListDto
{
    /// <summary>
    /// List of products in the current page.
    /// </summary>
    public List<ProductListItemDto> Items { get; set; } = new();

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