using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ValidSaleItemSpecification : ISpecification<SaleItem>
{
    public bool IsSatisfiedBy(SaleItem item)
    {
        // Exemplo: item de venda válido tem quantidade e preço positivos
        return item.Quantity > 0 && item.UnitPrice > 0;
    }
}
