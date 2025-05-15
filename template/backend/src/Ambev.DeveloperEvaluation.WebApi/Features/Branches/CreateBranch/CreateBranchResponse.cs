namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

public class CreateBranchResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string BranchCode { get; set; }
}
