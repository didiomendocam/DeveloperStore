using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().MaximumLength(100);
        RuleFor(product => product.ProductCode)
            .NotEmpty().Matches("^[A-Z0-9]{3,10}$");
        RuleFor(product => product.UnitPrice)
            .GreaterThanOrEqualTo(0);
        RuleFor(product => product.Status)
            .IsInEnum();
    }
}
