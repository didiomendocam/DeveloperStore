using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Branchs;

public class CreateBranchDtoTests
{
    [Fact]
    public void CreateBranchDto_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
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
    public void CreateBranchDto_WithInvalidName_ShouldFailValidation(string invalidName)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = invalidName,
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Name"));
    }

    [Theory]
    [InlineData("1234567890123")] // 13 digits
    [InlineData("123456789012345")] // 15 digits
    [InlineData("1234567890123a")] // Contains non-digit
    public void CreateBranchDto_WithInvalidCnpj_ShouldFailValidation(string invalidCnpj)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = invalidCnpj,
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Cnpj"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void CreateBranchDto_WithInvalidAddress_ShouldFailValidation(string invalidAddress)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = invalidAddress,
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Address"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("123456789")] // Too short
    [InlineData("123456789012345678901")] // Too long
    public void CreateBranchDto_WithInvalidPhone_ShouldFailValidation(string invalidPhone)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = invalidPhone,
            Email = "sp@ambev.com.br",
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Phone"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("invalid-email")]
    [InlineData("invalid@email")]
    [InlineData("@invalid.com")]
    public void CreateBranchDto_WithInvalidEmail_ShouldFailValidation(string invalidEmail)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = invalidEmail,
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Email"));
    }

    [Theory]
    [InlineData("12345678901234")] // Valid CNPJ
    public void CreateBranchDto_WithValidCnpj_ShouldPassValidation(string validCnpj)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = validCnpj,
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = "sp@ambev.com.br",
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
    [InlineData("(11) 99999-9999")] // Valid phone
    [InlineData("11999999999")] // Valid phone without formatting
    public void CreateBranchDto_WithValidPhone_ShouldPassValidation(string validPhone)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = validPhone,
            Email = "sp@ambev.com.br",
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
    [InlineData("sp@ambev.com.br")] // Valid email
    [InlineData("sp.filial@ambev.com.br")] // Valid email with subdomain
    public void CreateBranchDto_WithValidEmail_ShouldPassValidation(string validEmail)
    {
        // Arrange
        var dto = new CreateBranchDto
        {
            Name = "Filial São Paulo",
            Cnpj = "12345678901234",
            Address = "Av. Paulista, 1000",
            Phone = "(11) 99999-9999",
            Email = validEmail,
            IsActive = true
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }
} 