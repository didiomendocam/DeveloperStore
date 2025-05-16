namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// DTO for retrieving sale details.
/// </summary>
public class GetSaleDto
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
    /// List of items in the sale.
    /// </summary>
    public List<GetSaleItemDto> Items { get; set; } = new();

    /// <summary>
    /// Total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Payment method used for the sale.
    /// </summary>
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// Additional notes about the sale.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the sale was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

/// <summary>
/// DTO for retrieving sale item details.
/// </summary>
public class GetSaleItemDto
{
    /// <summary>
    /// Unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ID of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price of the product at the time of sale.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Total price for this item (quantity * unit price).
    /// </summary>
    public decimal TotalPrice { get; set; }
} 