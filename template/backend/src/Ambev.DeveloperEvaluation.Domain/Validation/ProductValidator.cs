using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("Product name cannot be empty.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

        RuleFor(product => product.ProductCode)
            .NotEmpty().WithMessage("Product code cannot be empty.")
            .Matches("^[A-Z0-9]{3,10}$").WithMessage("Product code must be 3-10 characters long and contain only uppercase letters and numbers.");

        RuleFor(product => product.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");
    }
}
