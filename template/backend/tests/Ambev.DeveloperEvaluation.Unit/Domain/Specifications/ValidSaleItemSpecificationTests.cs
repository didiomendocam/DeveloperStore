using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class ValidSaleItemSpecificationTests
    {
        private readonly ValidSaleItemSpecification _specification;

        public ValidSaleItemSpecificationTests()
        {
            _specification = new ValidSaleItemSpecification();
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenEntityIsNull()
        {
            // Act
            var result = _specification.IsSatisfiedBy(null);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(1, 100.00)] // Válido: quantidade e preço positivos
        [InlineData(4, 100.00)] // Válido: quantidade com desconto de 10%
        [InlineData(10, 100.00)] // Válido: quantidade com desconto de 20%
        [InlineData(20, 100.00)] // Válido: quantidade máxima com desconto de 20%
        public void IsSatisfiedBy_ShouldReturnTrue_WhenEntityIsValid(int quantity, decimal unitPrice)
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            // Act
            var result = _specification.IsSatisfiedBy(saleItem);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 100.00)] // Inválido: quantidade zero
        [InlineData(-1, 100.00)] // Inválido: quantidade negativa
        [InlineData(1, 0.00)] // Inválido: preço zero
        [InlineData(1, -1.00)] // Inválido: preço negativo
        [InlineData(21, 100.00)] // Inválido: quantidade acima do limite
        public void IsSatisfiedBy_ShouldReturnFalse_WhenEntityIsInvalid(int quantity, decimal unitPrice)
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            // Act
            var result = _specification.IsSatisfiedBy(saleItem);

            // Assert
            Assert.False(result);
        }
    }
} 