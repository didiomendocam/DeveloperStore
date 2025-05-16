using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ValidSaleItemSpecification : ISpecification<SaleItem>
{
    public bool IsSatisfiedBy(SaleItem entity)
    {
        if (entity == null)
            return false;

        try
        {
            entity.CalculateDiscount();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
