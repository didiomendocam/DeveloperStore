namespace Ambev.DeveloperEvaluation.Application.Customers.ListCustomers;

/// <summary>
/// DTO for listing customers with pagination.
/// </summary>
public class ListCustomersDto
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
    /// Search term to filter customers by name, document or contact.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Filter to show only active customers.
    /// </summary>
    public bool? OnlyActive { get; set; }

    /// <summary>
    /// Sort field (e.g., "name", "document", "createdAt").
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction ("asc" or "desc").
    /// </summary>
    public string? SortDirection { get; set; }
}

/// <summary>
/// DTO for customer list item.
/// </summary>
public class CustomerListItemDto
{
    /// <summary>
    /// Unique identifier of the customer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the customer.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Document number (CPF/CNPJ) of the customer.
    /// </summary>
    public string Document { get; set; } = string.Empty;

    /// <summary>
    /// Contact information (phone or email) of the customer.
    /// </summary>
    public string Contact { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the customer is active.
    /// </summary>
    public bool IsActive { get; set; }
}

/// <summary>
/// DTO for paginated customer list response.
/// </summary>
public class PaginatedCustomerListDto
{
    /// <summary>
    /// List of customers in the current page.
    /// </summary>
    public List<CustomerListItemDto> Items { get; set; } = new();

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