using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// DTO for creating a new branch.
/// </summary>
public class CreateBranchDto
{
    /// <summary>
    /// Name of the branch.
    /// </summary>
    [Required(ErrorMessage = "The name is required.")]
    [StringLength(100, ErrorMessage = "The name must be between 1 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// CNPJ (tax ID) of the branch.
    /// </summary>
    [Required(ErrorMessage = "The CNPJ is required.")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "The CNPJ must contain exactly 14 digits.")]
    public string Cnpj { get; set; } = string.Empty;

    /// <summary>
    /// Address of the branch.
    /// </summary>
    [Required(ErrorMessage = "The address is required.")]
    [StringLength(200, ErrorMessage = "The address must not exceed 200 characters.")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Phone number of the branch.
    /// </summary>
    [Required(ErrorMessage = "The phone number is required.")]
    [RegularExpression(@"^\(\d{2}\)\s\d{5}-\d{4}$|^\d{10,11}$", ErrorMessage = "The phone number must be in the format (XX) XXXXX-XXXX or XXXXXXXXXX.")]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Email address of the branch.
    /// </summary>
    [Required(ErrorMessage = "The email is required.")]
    [EmailAddress(ErrorMessage = "The email must be in a valid format.")]
    [StringLength(100, ErrorMessage = "The email must not exceed 100 characters.")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the branch is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
} 