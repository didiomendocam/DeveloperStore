using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// DTO for creating a new sale.
/// </summary>
public class CreateSaleDto
{
    /// <summary>
    /// ID of the customer making the purchase.
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public required Guid CustomerId { get; set; }

    /// <summary>
    /// ID of the branch where the sale is being made.
    /// </summary>
    [Required(ErrorMessage = "Branch ID is required")]
    public required Guid BranchId { get; set; }

    /// <summary>
    /// List of items in the sale.
    /// </summary>
    [Required(ErrorMessage = "Sale items are required")]
    [MinLength(1, ErrorMessage = "Sale must have at least one item")]
    public required List<CreateSaleItemDto> Items { get; set; }

    /// <summary>
    /// Payment method used for the sale.
    /// </summary>
    [Required(ErrorMessage = "Payment method is required")]
    [RegularExpression("^(CREDIT|DEBIT|CASH|PIX)$", ErrorMessage = "Payment method must be CREDIT, DEBIT, CASH, or PIX")]
    public required string PaymentMethod { get; set; }

    /// <summary>
    /// Additional notes about the sale.
    /// </summary>
    [StringLength(500, ErrorMessage = "Notes must not exceed 500 characters")]
    public string? Notes { get; set; }
}

/// <summary>
/// DTO for creating a sale item.
/// </summary>
public class CreateSaleItemDto
{
    /// <summary>
    /// ID of the product being sold.
    /// </summary>
    [Required(ErrorMessage = "Product ID is required")]
    public required Guid ProductId { get; set; }

    /// <summary>
    /// Quantity of the product being sold.
    /// </summary>
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public required int Quantity { get; set; }

    /// <summary>
    /// Unit price of the product at the time of sale.
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
    public required decimal UnitPrice { get; set; }
} 