using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveBranchSpecification : ISpecification<Branch>
{
    public bool IsSatisfiedBy(Branch branch)
    {
        // Supondo que Branch tenha uma propriedade Status semelhante a User
        return branch.Status == BranchStatus.Active;
    }
}
