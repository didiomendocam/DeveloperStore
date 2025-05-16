using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class UpdateProductDtoTests
{
    [Fact]
    public void UpdateProductDto_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Name = "Updated Product",
            Description = "Updated Description",
            UnitPrice = 15.99m,
            StockQuantity = 150,
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void UpdateProductDto_WithInvalidName_ShouldFailValidation(string invalidName)
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Name = invalidName,
            UnitPrice = 15.99m,
            StockQuantity = 150
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Name"));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateProductDto_WithInvalidUnitPrice_ShouldFailValidation(decimal invalidPrice)
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Name = "Updated Product",
            UnitPrice = invalidPrice,
            StockQuantity = 150
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("UnitPrice"));
    }

    [Theory]
    [InlineData(-1)]
    public void UpdateProductDto_WithInvalidStockQuantity_ShouldFailValidation(int invalidQuantity)
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Name = "Updated Product",
            UnitPrice = 15.99m,
            StockQuantity = invalidQuantity
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("StockQuantity"));
    }

    [Fact]
    public void UpdateProductDto_WithLongDescription_ShouldFailValidation()
    {
        // Arrange
        var dto = new UpdateProductDto
        {
            Name = "Updated Product",
            Description = new string('a', 501), // Exceeds 500 characters
            UnitPrice = 15.99m,
            StockQuantity = 150
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Description"));
    }
} 