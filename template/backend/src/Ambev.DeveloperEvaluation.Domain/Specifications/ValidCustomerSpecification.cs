using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ValidCustomerSpecification : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer customer)
    {
        // Exemplo: cliente válido tem CPF/CNPJ preenchido e ativo
        return !string.IsNullOrWhiteSpace(customer.Document) && customer.IsActive;
    }
}
