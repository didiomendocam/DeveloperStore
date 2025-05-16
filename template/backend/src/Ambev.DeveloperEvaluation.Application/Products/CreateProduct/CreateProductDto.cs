using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// DTO for creating a new product.
/// </summary>
public class CreateProductDto
{
    /// <summary>
    /// Name of the product.
    /// </summary>
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name must be between 1 and 100 characters")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
    public string? Description { get; set; }

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    [Required(ErrorMessage = "Unit price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Stock quantity of the product.
    /// </summary>
    [Required(ErrorMessage = "Stock quantity is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be greater than or equal to zero")]
    public int StockQuantity { get; set; }

    /// <summary>
    /// Indicates if the product is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
} 