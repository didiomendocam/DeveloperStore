using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Enums;

// Validador para criação de filial
namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchValidator()
    {
        RuleFor(branch => branch.Name)
            .NotEmpty().MaximumLength(100);
        RuleFor(branch => branch.Address)
            .NotEmpty().MaximumLength(200);
        RuleFor(branch => branch.BranchCode)
            .NotEmpty().Matches("^[A-Z0-9]{3,10}$");
        RuleFor(branch => branch.Status)
            .IsInEnum();
    }
}
