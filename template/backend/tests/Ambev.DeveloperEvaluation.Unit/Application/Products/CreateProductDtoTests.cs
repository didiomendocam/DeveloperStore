using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Products;

public class CreateProductDtoTests
{
    [Fact]
    public void CreateProductDto_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "Test Product",
            Description = "Test Description",
            UnitPrice = 10.99m,
            StockQuantity = 100,
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
    public void CreateProductDto_WithInvalidName_ShouldFailValidation(string invalidName)
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = invalidName,
            UnitPrice = 10.99m,
            StockQuantity = 100
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
    public void CreateProductDto_WithInvalidUnitPrice_ShouldFailValidation(decimal invalidPrice)
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "Test Product",
            UnitPrice = invalidPrice,
            StockQuantity = 100
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
    public void CreateProductDto_WithInvalidStockQuantity_ShouldFailValidation(int invalidQuantity)
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "Test Product",
            UnitPrice = 10.99m,
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
    public void CreateProductDto_WithLongDescription_ShouldFailValidation()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "Test Product",
            Description = new string('a', 501), // Exceeds 500 characters
            UnitPrice = 10.99m,
            StockQuantity = 100
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Description"));
    }
} 