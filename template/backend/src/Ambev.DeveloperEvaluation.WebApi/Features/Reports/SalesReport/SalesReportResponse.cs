namespace Ambev.DeveloperEvaluation.WebApi.Features.Reports.SalesReport;

/// <summary>
/// Response model for sales reports
/// </summary>
public class SalesReportResponse
{
    /// <summary>
    /// Total number of sales in the period
    /// </summary>
    public int TotalSales { get; set; }

    /// <summary>
    /// Total revenue in the period
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// Average sale value
    /// </summary>
    public decimal AverageSaleValue { get; set; }

    /// <summary>
    /// Total number of items sold
    /// </summary>
    public int TotalItemsSold { get; set; }

    /// <summary>
    /// List of sales grouped by the specified criteria
    /// </summary>
    public List<SalesGroup> Groups { get; set; } = new();

    /// <summary>
    /// List of top selling products
    /// </summary>
    public List<TopProduct> TopProducts { get; set; } = new();

    /// <summary>
    /// List of top customers by revenue
    /// </summary>
    public List<TopCustomer> TopCustomers { get; set; } = new();
}

/// <summary>
/// Represents a group of sales data
/// </summary>
public class SalesGroup
{
    /// <summary>
    /// Group identifier (e.g., customer name, branch name, product name, date)
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Number of sales in this group
    /// </summary>
    public int SalesCount { get; set; }

    /// <summary>
    /// Total revenue for this group
    /// </summary>
    public decimal Revenue { get; set; }

    /// <summary>
    /// Number of items sold in this group
    /// </summary>
    public int ItemsSold { get; set; }
}

/// <summary>
/// Represents a top selling product
/// </summary>
public class TopProduct
{
    /// <summary>
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Number of units sold
    /// </summary>
    public int UnitsSold { get; set; }

    /// <summary>
    /// Total revenue from this product
    /// </summary>
    public decimal Revenue { get; set; }
}

/// <summary>
/// Represents a top customer by revenue
/// </summary>
public class TopCustomer
{
    /// <summary>
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Number of purchases
    /// </summary>
    public int PurchaseCount { get; set; }

    /// <summary>
    /// Total revenue from this customer
    /// </summary>
    public decimal Revenue { get; set; }
} 