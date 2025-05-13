using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(saleItem => saleItem.SaleId)
            .NotEmpty().WithMessage("SaleId cannot be empty.");

        RuleFor(saleItem => saleItem.ProductId)
            .NotEmpty().WithMessage("ProductId cannot be empty.");

        RuleFor(saleItem => saleItem.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(saleItem => saleItem.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("UnitPrice must be greater than or equal to 0.");

        RuleFor(saleItem => saleItem.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0.");

        RuleFor(saleItem => saleItem.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("TotalAmount must be greater than or equal to 0.");
    }
}
