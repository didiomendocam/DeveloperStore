using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class AvailableProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        // Exemplo: produto disponível tem estoque maior que zero e está ativo
        return product.Stock > 0 && product.IsActive;
    }
}
