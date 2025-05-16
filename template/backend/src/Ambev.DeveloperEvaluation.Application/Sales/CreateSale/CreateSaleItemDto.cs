using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// DTO for creating a sale item.
/// </summary>
public class CreateSaleItemDto
{
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

    /// <summary>
    /// Discount applied to the item.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "Discount must be greater than or equal to 0")]
    public decimal Discount { get; set; }
} 