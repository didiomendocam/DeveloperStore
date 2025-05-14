using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class CustomerValidatorTests
{
    private readonly CustomerValidator _validator;

    public CustomerValidatorTests()
    {
        _validator = new CustomerValidator();
    }

    [Fact(DisplayName = "Given a valid Customer When validating Then should pass validation")]
    public void ValidCustomer_ShouldPassValidation()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "John Doe",
            Document = "12345678901",
            Contact = "john.doe@example.com"
        };

        // Act
        var result = _validator.TestValidate(customer);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Given a Customer with empty Name When validating Then should fail validation")]
    public void Customer_WithEmptyName_ShouldFailValidation()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "",
            Document = "12345678901",
            Contact = "john.doe@example.com"
        };

        // Act
        var result = _validator.TestValidate(customer);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact(DisplayName = "Given a Customer with invalid Document When validating Then should fail validation")]
    public void Customer_WithInvalidDocument_ShouldFailValidation()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "John Doe",
            Document = "INVALID",
            Contact = "john.doe@example.com"
        };

        // Act
        var result = _validator.TestValidate(customer);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Document);
    }

    [Fact(DisplayName = "Given a Customer with empty Contact When validating Then should fail validation")]
    public void Customer_WithEmptyContact_ShouldFailValidation()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "John Doe",
            Document = "12345678901",
            Contact = ""
        };

        // Act
        var result = _validator.TestValidate(customer);

        // Assert
        result.ShouldHaveValidationErrorFor(c => c.Contact);
    }
}
