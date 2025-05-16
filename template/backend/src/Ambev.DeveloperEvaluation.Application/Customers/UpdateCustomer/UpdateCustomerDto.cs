using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

/// <summary>
/// DTO for updating an existing customer.
/// </summary>
public class UpdateCustomerDto
{
    /// <summary>
    /// Name of the customer.
    /// </summary>
    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100, ErrorMessage = "Customer name must be between 1 and 100 characters")]
    public required string Name { get; set; }

    /// <summary>
    /// Document number (CPF/CNPJ) of the customer.
    /// </summary>
    [Required(ErrorMessage = "Document is required")]
    [StringLength(14, ErrorMessage = "Document must be between 11 and 14 characters")]
    [RegularExpression(@"^\d{11}|\d{14}$", ErrorMessage = "Document must be a valid CPF (11 digits) or CNPJ (14 digits)")]
    public required string Document { get; set; }

    /// <summary>
    /// Contact information (phone or email) of the customer.
    /// </summary>
    [Required(ErrorMessage = "Contact information is required")]
    [StringLength(100, ErrorMessage = "Contact information must not exceed 100 characters")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$|^\d{10,11}$", 
        ErrorMessage = "Contact must be a valid email or phone number (10-11 digits)")]
    public required string Contact { get; set; }

    /// <summary>
    /// Indicates if the customer is active.
    /// </summary>
    public bool IsActive { get; set; }
} 