using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class UpdateSaleDtoTests
{
    [Fact]
    public void UpdateSaleDto_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var dto = new UpdateSaleDto
        {
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<UpdateSaleItemDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 2,
                    UnitPrice = 10.99m
                }
            },
            PaymentMethod = "CREDIT"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Fact]
    public void UpdateSaleDto_WithEmptyItems_ShouldFailValidation()
    {
        // Arrange
        var dto = new UpdateSaleDto
        {
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<UpdateSaleItemDto>(),
            PaymentMethod = "CREDIT"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Items"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("INVALID")]
    public void UpdateSaleDto_WithInvalidPaymentMethod_ShouldFailValidation(string invalidPaymentMethod)
    {
        // Arrange
        var dto = new UpdateSaleDto
        {
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<UpdateSaleItemDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 2,
                    UnitPrice = 10.99m
                }
            },
            PaymentMethod = invalidPaymentMethod
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("PaymentMethod"));
    }

    [Theory]
    [InlineData("CREDIT")]
    [InlineData("DEBIT")]
    [InlineData("CASH")]
    [InlineData("PIX")]
    public void UpdateSaleDto_WithValidPaymentMethod_ShouldPassValidation(string validPaymentMethod)
    {
        // Arrange
        var dto = new UpdateSaleDto
        {
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<UpdateSaleItemDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 2,
                    UnitPrice = 10.99m
                }
            },
            PaymentMethod = validPaymentMethod
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Fact]
    public void UpdateSaleDto_WithLongNotes_ShouldFailValidation()
    {
        // Arrange
        var dto = new UpdateSaleDto
        {
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<UpdateSaleItemDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    Quantity = 2,
                    UnitPrice = 10.99m
                }
            },
            PaymentMethod = "CREDIT",
            Notes = new string('a', 501) // 501 characters
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Notes"));
    }

    [Fact]
    public void UpdateSaleItemDto_WithInvalidQuantity_ShouldFailValidation()
    {
        // Arrange
        var dto = new UpdateSaleItemDto
        {
            Id = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 0,
            UnitPrice = 10.99m
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Quantity"));
    }

    [Fact]
    public void UpdateSaleItemDto_WithInvalidUnitPrice_ShouldFailValidation()
    {
        // Arrange
        var dto = new UpdateSaleItemDto
        {
            Id = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 2,
            UnitPrice = 0m
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("UnitPrice"));
    }
} 