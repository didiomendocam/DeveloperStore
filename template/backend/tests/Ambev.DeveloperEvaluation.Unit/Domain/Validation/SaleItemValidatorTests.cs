using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleItemValidatorTests
{
    private readonly SaleItemValidator _validator;

    public SaleItemValidatorTests()
    {
        _validator = new SaleItemValidator();
    }

    [Fact(DisplayName = "Given a valid SaleItem When validating Then should pass validation")]
    public void ValidSaleItem_ShouldPassValidation()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 5,
            UnitPrice = 10.0m,
            Discount = 1.0m,
            TotalAmount = 45.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Given a SaleItem with Quantity less than 1 When validating Then should fail validation")]
    public void SaleItem_WithInvalidQuantity_ShouldFailValidation()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 0,
            UnitPrice = 10.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(item => item.Quantity);
    }

    [Fact(DisplayName = "Given a SaleItem with UnitPrice less than 0 When validating Then should fail validation")]
    public void SaleItem_WithInvalidUnitPrice_ShouldFailValidation()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 5,
            UnitPrice = -1.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(item => item.UnitPrice);
    }

    [Fact(DisplayName = "Given a SaleItem with Discount less than 0 When validating Then should fail validation")]
    public void SaleItem_WithInvalidDiscount_ShouldFailValidation()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 5,
            UnitPrice = 10.0m,
            Discount = -1.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(item => item.Discount);
    }
}
