using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Reports.SalesReport;

/// <summary>
/// Validator for SalesReportRequest
/// </summary>
public class SalesReportRequestValidator : AbstractValidator<SalesReportRequest>
{
    /// <summary>
    /// Initializes validation rules for SalesReportRequest
    /// </summary>
    public SalesReportRequestValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required")
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage("End date must be greater than or equal to start date");

        RuleFor(x => x.GroupBy)
            .Must(BeAValidGroupBy)
            .When(x => !string.IsNullOrEmpty(x.GroupBy))
            .WithMessage("Invalid group by value. Valid values are: customer, branch, product, date");
    }

    private bool BeAValidGroupBy(string? groupBy)
    {
        if (string.IsNullOrEmpty(groupBy))
            return true;

        var validGroups = new[] { "customer", "branch", "product", "date" };
        return validGroups.Contains(groupBy.ToLower());
    }
} 