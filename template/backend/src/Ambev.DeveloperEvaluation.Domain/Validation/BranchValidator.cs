using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class BranchValidator : AbstractValidator<Branch>
{
    public BranchValidator()
    {
        RuleFor(branch => branch.Name)
            .NotEmpty().WithMessage("Branch name cannot be empty.")
            .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

        RuleFor(branch => branch.Address)
            .NotEmpty().WithMessage("Branch address cannot be empty.")
            .MaximumLength(200).WithMessage("Branch address cannot exceed 200 characters.");

        RuleFor(branch => branch.BranchCode)
            .NotEmpty().WithMessage("Branch code cannot be empty.")
            .Matches("^[A-Z0-9]{3,10}$").WithMessage("Branch code must be 3-10 characters long and contain only uppercase letters and numbers.");
    }
}
