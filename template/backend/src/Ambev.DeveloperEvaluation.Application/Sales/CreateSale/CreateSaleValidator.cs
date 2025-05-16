using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().MaximumLength(50);
        RuleFor(sale => sale.SaleDate)
            .LessThanOrEqualTo(DateTime.Now);
        RuleFor(sale => sale.CustomerId)
            .NotEmpty();
        RuleFor(sale => sale.BranchId)
            .NotEmpty();
        RuleFor(sale => sale.TotalAmount)
            .GreaterThanOrEqualTo(0);
        RuleFor(sale => sale.Status)
            .IsInEnum();
        RuleForEach(sale => sale.Items)
            .SetValidator(new CreateSaleItemDtoValidator());
    }
}

public class CreateSaleItemDtoValidator : AbstractValidator<CreateSaleItemDto>
{
    public CreateSaleItemDtoValidator()
    {
        RuleFor(item => item.ProductId).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Discount).GreaterThanOrEqualTo(0);
    }
}
