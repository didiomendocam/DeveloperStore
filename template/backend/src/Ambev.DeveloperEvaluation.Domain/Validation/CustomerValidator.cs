using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().WithMessage("Customer name cannot be empty.")
            .MaximumLength(150).WithMessage("Customer name cannot exceed 150 characters.");

        RuleFor(customer => customer.Document)
            .NotEmpty().WithMessage("Customer document cannot be empty.")
            .Matches("^(\d{11}|\d{14})$").WithMessage("Document must be a valid CPF (11 digits) or CNPJ (14 digits).");

        RuleFor(customer => customer.Contact)
            .NotEmpty().WithMessage("Customer contact cannot be empty.")
            .MaximumLength(100).WithMessage("Customer contact cannot exceed 100 characters.");
    }
}
