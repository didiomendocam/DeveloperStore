using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;

/// <summary>
/// Query for generating sales reports
/// </summary>
public class GetSalesReportQuery : IRequest<GetSalesReportResult>
{
    /// <summary>
    /// Start date for the report period
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date for the report period
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Optional customer ID to filter sales
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Optional branch ID to filter sales
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Optional product ID to filter sales
    /// </summary>
    public Guid? ProductId { get; set; }

    /// <summary>
    /// Optional status to filter sales
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// Optional flag to include cancelled sales
    /// </summary>
    public bool? IncludeCancelled { get; set; }

    /// <summary>
    /// Optional grouping criteria (e.g., "customer", "branch", "product", "date")
    /// </summary>
    public string? GroupBy { get; set; }
} 