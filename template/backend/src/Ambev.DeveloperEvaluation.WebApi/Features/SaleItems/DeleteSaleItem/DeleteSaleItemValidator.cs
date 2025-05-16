using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;

public class DeleteSaleItemRequestValidator : AbstractValidator<DeleteSaleItemRequest>
{
    public DeleteSaleItemRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
