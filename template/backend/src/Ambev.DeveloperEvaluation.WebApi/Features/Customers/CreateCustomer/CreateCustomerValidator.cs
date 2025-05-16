using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    // Constructor renamed to avoid conflict with the existing constructor
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Document).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Contact).NotEmpty().MaximumLength(100);
    }
}
