using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    [Fact(DisplayName = "Given a valid Sale When validating Then should pass validation")]
    public void ValidSale_ShouldPassValidation()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = "SALE123",
            SaleDate = DateTime.Now,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = 100.0m
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Given a Sale with empty SaleNumber When validating Then should fail validation")]
    public void Sale_WithEmptySaleNumber_ShouldFailValidation()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = "",
            SaleDate = DateTime.Now,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = 100.0m
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.SaleNumber);
    }

    [Fact(DisplayName = "Given a Sale with future SaleDate When validating Then should fail validation")]
    public void Sale_WithFutureSaleDate_ShouldFailValidation()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = "SALE123",
            SaleDate = DateTime.Now.AddDays(1),
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = 100.0m
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.SaleDate);
    }

    [Fact(DisplayName = "Given a Sale with negative TotalAmount When validating Then should fail validation")]
    public void Sale_WithNegativeTotalAmount_ShouldFailValidation()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = "SALE123",
            SaleDate = DateTime.Now,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = -10.0m
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.TotalAmount);
    }
}
