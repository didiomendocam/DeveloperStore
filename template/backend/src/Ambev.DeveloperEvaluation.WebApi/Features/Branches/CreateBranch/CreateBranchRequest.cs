namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;

public class CreateBranchRequest
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string BranchCode { get; set; }
}
