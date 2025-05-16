namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchResult
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? BranchCode { get; set; }
    public int Status { get; set; }
}
