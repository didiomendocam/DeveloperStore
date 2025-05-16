using System;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Theory]
        [InlineData(1, 100.00, 0.00)] // Sem desconto para menos de 4 itens
        [InlineData(3, 100.00, 0.00)] // Sem desconto para menos de 4 itens
        [InlineData(4, 100.00, 40.00)] // 10% de desconto para 4 itens
        [InlineData(5, 100.00, 50.00)] // 10% de desconto para 5 itens
        [InlineData(9, 100.00, 90.00)] // 10% de desconto para 9 itens
        [InlineData(10, 100.00, 200.00)] // 20% de desconto para 10 itens
        [InlineData(15, 100.00, 300.00)] // 20% de desconto para 15 itens
        [InlineData(20, 100.00, 400.00)] // 20% de desconto para 20 itens
        public void CalculateDiscount_ShouldApplyCorrectDiscount(int quantity, decimal unitPrice, decimal expectedDiscount)
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            // Act
            saleItem.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, saleItem.Discount);
            Assert.Equal((quantity * unitPrice) - expectedDiscount, saleItem.TotalAmount);
        }

        [Fact]
        public void CalculateDiscount_ShouldThrowException_WhenQuantityExceeds20()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = 21,
                UnitPrice = 100.00m
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => saleItem.CalculateDiscount());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CalculateDiscount_ShouldThrowException_WhenQuantityIsInvalid(int quantity)
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = quantity,
                UnitPrice = 100.00m
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => saleItem.CalculateDiscount());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CalculateDiscount_ShouldThrowException_WhenUnitPriceIsInvalid(decimal unitPrice)
        {
            // Arrange
            var saleItem = new SaleItem
            {
                Quantity = 1,
                UnitPrice = unitPrice
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => saleItem.CalculateDiscount());
        }
    }
} 