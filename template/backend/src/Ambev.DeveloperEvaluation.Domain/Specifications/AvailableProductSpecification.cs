using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class AvailableProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        // Exemplo: produto disponível está ativo
        return product.Status == ProductStatus.Active;
    }
}
