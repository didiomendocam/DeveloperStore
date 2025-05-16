using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// DTO for updating an existing sale.
/// </summary>
public class UpdateSaleDto
{
    /// <summary>
    /// ID of the customer making the purchase.
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required")]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// ID of the branch where the sale is being made.
    /// </summary>
    [Required(ErrorMessage = "Branch ID is required")]
    public Guid BranchId { get; set; }

    /// <summary>
    /// List of items in the sale.
    /// </summary>
    [Required(ErrorMessage = "Sale items are required")]
    [MinLength(1, ErrorMessage = "Sale must have at least one item")]
    public List<UpdateSaleItemDto> Items { get; set; } = new();

    /// <summary>
    /// Payment method used for the sale.
    /// </summary>
    [Required(ErrorMessage = "Payment method is required")]
    [RegularExpression("^(CREDIT|DEBIT|CASH|PIX)$", ErrorMessage = "Payment method must be CREDIT, DEBIT, CASH, or PIX")]
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// Additional notes about the sale.
    /// </summary>
    [StringLength(500, ErrorMessage = "Notes must not exceed 500 characters")]
    public string? Notes { get; set; }
}

/// <summary>
/// DTO for updating a sale item.
/// </summary>
public class UpdateSaleItemDto
{
    /// <summary>
    /// ID of the sale item.
    /// </summary>
    [Required(ErrorMessage = "Sale item ID is required")]
    public Guid Id { get; set; }

    /// <summary>
    /// ID of the product being sold.
    /// </summary>
    [Required(ErrorMessage = "Product ID is required")]
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantity of the product being sold.
    /// </summary>
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price of the product at the time of sale.
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
    public decimal UnitPrice { get; set; }
}