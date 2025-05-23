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
    public List<CreateSaleItemDto> Items { get; set; } = new();

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
    public string? Notes { get; set; } = string.Empty;
}