using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.ListSaleItems;

public class ListSaleItemsRequestValidator : AbstractValidator<ListSaleItemsRequest>
{
    public ListSaleItemsRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Page size must be between 1 and 100");

        RuleFor(x => x.SortBy)
            .Must(BeAValidSortField)
            .When(x => !string.IsNullOrEmpty(x.SortBy))
            .WithMessage("Invalid sort field. Valid fields are: Quantity, UnitPrice, Discount");
    }

    private bool BeAValidSortField(string? sortField)
    {
        if (string.IsNullOrEmpty(sortField))
            return true;

        var validFields = new[] { "Quantity", "UnitPrice", "Discount" };
        return validFields.Contains(sortField);
    }
} 