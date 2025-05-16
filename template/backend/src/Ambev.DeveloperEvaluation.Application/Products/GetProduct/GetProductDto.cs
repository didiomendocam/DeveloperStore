namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// DTO for retrieving product details.
/// </summary>
public class GetProductDto
{
    /// <summary>
    /// Unique identifier of the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Stock quantity of the product.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Indicates if the product is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the product was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
} 