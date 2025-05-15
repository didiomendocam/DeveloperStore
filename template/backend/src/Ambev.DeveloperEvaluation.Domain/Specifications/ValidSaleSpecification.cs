using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ValidSaleSpecification : ISpecification<Sale>
{
    public bool IsSatisfiedBy(Sale sale)
    {
        // Exemplo: venda válida tem pelo menos um item e está confirmada
        return sale.Status == SaleStatus.Confirmed && sale.SaleItems != null && sale.SaleItems.Count > 0;
    }
}
