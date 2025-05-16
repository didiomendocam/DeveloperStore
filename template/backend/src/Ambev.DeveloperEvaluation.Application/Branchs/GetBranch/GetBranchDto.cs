namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// DTO for retrieving branch details.
/// </summary>
public class GetBranchDto
{
    /// <summary>
    /// Unique identifier of the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// CNPJ (tax ID) of the branch.
    /// </summary>
    public string Cnpj { get; set; } = string.Empty;

    /// <summary>
    /// Address of the branch.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Phone number of the branch.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Email address of the branch.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the branch is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Date and time when the branch was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the branch was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
} 