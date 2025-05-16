using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
{
    public CreateSaleItemValidator()
    {
        RuleFor(item => item.SaleId).NotEmpty();
        RuleFor(item => item.ProductId).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
        RuleFor(item => item.Discount).GreaterThanOrEqualTo(0);
    }
}
