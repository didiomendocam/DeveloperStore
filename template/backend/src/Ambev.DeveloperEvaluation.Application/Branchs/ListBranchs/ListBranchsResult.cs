namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;

public class ListBranchsResult
{
    public List<BranchDto> Branchs { get; set; } = new();
}

public class BranchDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? BranchCode { get; set; }
    public int Status { get; set; }
}
