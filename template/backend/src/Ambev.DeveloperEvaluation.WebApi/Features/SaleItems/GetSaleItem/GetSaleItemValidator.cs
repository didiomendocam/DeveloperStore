using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

public class GetSaleItemRequestValidator : AbstractValidator<GetSaleItemRequest>
{
    public GetSaleItemRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
