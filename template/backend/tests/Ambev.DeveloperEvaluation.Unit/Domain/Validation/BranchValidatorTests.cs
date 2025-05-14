using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class BranchValidatorTests
{
    private readonly BranchValidator _validator;

    public BranchValidatorTests()
    {
        _validator = new BranchValidator();
    }

    [Fact(DisplayName = "Given a valid Branch When validating Then should pass validation")]
    public void ValidBranch_ShouldPassValidation()
    {
        // Arrange
        var branch = new Branch
        {
            Name = "Main Branch",
            Address = "123 Main Street",
            BranchCode = "BR001"
        };

        // Act
        var result = _validator.TestValidate(branch);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Given a Branch with empty Name When validating Then should fail validation")]
    public void Branch_WithEmptyName_ShouldFailValidation()
    {
        // Arrange
        var branch = new Branch
        {
            Name = "",
            Address = "123 Main Street",
            BranchCode = "BR001"
        };

        // Act
        var result = _validator.TestValidate(branch);

        // Assert
        result.ShouldHaveValidationErrorFor(b => b.Name);
    }

    [Fact(DisplayName = "Given a Branch with invalid BranchCode When validating Then should fail validation")]
    public void Branch_WithInvalidBranchCode_ShouldFailValidation()
    {
        // Arrange
        var branch = new Branch
        {
            Name = "Main Branch",
            Address = "123 Main Street",
            BranchCode = "INVALID_CODE"
        };

        // Act
        var result = _validator.TestValidate(branch);

        // Assert
        result.ShouldHaveValidationErrorFor(b => b.BranchCode);
    }
}
