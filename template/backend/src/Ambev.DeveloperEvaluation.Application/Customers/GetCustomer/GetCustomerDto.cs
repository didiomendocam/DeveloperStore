namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// DTO for retrieving customer details.
/// </summary>
public class GetCustomerDto
{
    /// <summary>
    /// Unique identifier of the customer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the customer.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Document number (CPF/CNPJ) of the customer.
    /// </summary>
    public string Document { get; set; } = string.Empty;

    /// <summary>
    /// Contact information (phone or email) of the customer.
    /// </summary>
    public string Contact { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the customer is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Date and time when the customer was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the customer was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
} 