using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().MaximumLength(150);
        RuleFor(customer => customer.Document)
            .NotEmpty().Matches(@"^(\d{11}|\d{14})$");
        RuleFor(customer => customer.Contact)
            .NotEmpty().MaximumLength(100);
    }
}

public static class CreateCustomerValidatorExtensions
{
    public static async Task<FluentValidation.Results.ValidationResult> ValidateAsync(this CreateCustomerValidator validator, CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        return await validator.ValidateAsync(command, cancellationToken);
    }
}
