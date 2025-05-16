using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Customers;

public class CreateCustomerDtoTests
{
    [Fact]
    public void CreateCustomerDto_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            Document = "12345678901", // CPF
            Contact = "john.doe@email.com",
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
    public void CreateCustomerDto_WithInvalidName_ShouldFailValidation(string invalidName)
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = invalidName,
            Document = "12345678901",
            Contact = "john.doe@email.com"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Name"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("123456789")] // CPF inválido (menos de 11 dígitos)
    [InlineData("123456789012")] // CPF inválido (mais de 11 dígitos)
    [InlineData("1234567890123")] // CNPJ inválido (menos de 14 dígitos)
    [InlineData("123456789012345")] // CNPJ inválido (mais de 14 dígitos)
    [InlineData("1234567890a")] // Caracteres não numéricos
    public void CreateCustomerDto_WithInvalidDocument_ShouldFailValidation(string invalidDocument)
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            Document = invalidDocument,
            Contact = "john.doe@email.com"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Document"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("invalid-email")] // Email inválido
    [InlineData("123456789")] // Telefone inválido (menos de 10 dígitos)
    [InlineData("123456789012")] // Telefone inválido (mais de 11 dígitos)
    [InlineData("1234567890a")] // Telefone com caracteres não numéricos
    public void CreateCustomerDto_WithInvalidContact_ShouldFailValidation(string invalidContact)
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            Document = "12345678901",
            Contact = invalidContact
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Contact"));
    }

    [Theory]
    [InlineData("12345678901")] // CPF válido
    [InlineData("12345678901234")] // CNPJ válido
    public void CreateCustomerDto_WithValidDocument_ShouldPassValidation(string validDocument)
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            Document = validDocument,
            Contact = "john.doe@email.com"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Theory]
    [InlineData("john.doe@email.com")] // Email válido
    [InlineData("11999999999")] // Telefone válido (11 dígitos)
    [InlineData("1199999999")] // Telefone válido (10 dígitos)
    public void CreateCustomerDto_WithValidContact_ShouldPassValidation(string validContact)
    {
        // Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            Document = "12345678901",
            Contact = validContact
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
} 