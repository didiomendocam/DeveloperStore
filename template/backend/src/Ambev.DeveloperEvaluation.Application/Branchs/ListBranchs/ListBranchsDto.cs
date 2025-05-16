namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;

/// <summary>
/// DTO for listing branches with pagination.
/// </summary>
public class ListBranchsDto
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
    /// Search term to filter branches by name, CNPJ, or address.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    /// Filter to show only active branches.
    /// </summary>
    public bool? OnlyActive { get; set; }

    /// <summary>
    /// Sort field (e.g., "name", "cnpj", "createdAt").
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction ("asc" or "desc").
    /// </summary>
    public string? SortDirection { get; set; }
}

/// <summary>
/// DTO for branch list item.
/// </summary>
public class BranchListItemDto
{
    /// <summary>
    /// Unique identifier of the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// CNPJ (tax ID) of the branch.
    /// </summary>
    public string Cnpj { get; set; } = string.Empty;

    /// <summary>
    /// Address of the branch.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Phone number of the branch.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Email address of the branch.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the branch is active.
    /// </summary>
    public bool IsActive { get; set; }
}

/// <summary>
/// DTO for paginated branch list response.
/// </summary>
public class PaginatedBranchListDto
{
    /// <summary>
    /// List of branches in the current page.
    /// </summary>
    public List<BranchListItemDto> Items { get; set; } = new();

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