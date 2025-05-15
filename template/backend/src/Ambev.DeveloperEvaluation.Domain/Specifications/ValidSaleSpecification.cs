using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ValidSaleSpecification : ISpecification<Sale>
{
    public bool IsSatisfiedBy(Sale sale)
    {
        // Exemplo: venda válida tem pelo menos um item e está confirmada
        return sale.Items != null && sale.Items.Count > 0 && sale.IsConfirmed;
    }
}
