using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.ORM.Repositories;

public class SaleItemRepositoryTests
{
    private readonly DbContextOptions<DefaultContext> _dbContextOptions;

    public SaleItemRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DefaultContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact(DisplayName = "Given a SaleItem When adding to repository Then it should be retrievable")]
    public async Task AddAsync_ShouldAddSaleItem()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var repository = new SaleItemRepository(context);
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
        await repository.AddAsync(saleItem);
        var retrievedItems = await repository.GetBySaleIdAsync(saleItem.SaleId);

        // Assert
        Assert.Single(retrievedItems);
        Assert.Equal(saleItem.ProductId, retrievedItems.First().ProductId);
    }

    [Fact(DisplayName = "Given a SaleItem When applying business rules Then it should calculate correctly")]
    public async Task ApplyBusinessRulesAsync_ShouldApplyRulesCorrectly()
    {
        // Arrange
        using var context = new DefaultContext(_dbContextOptions);
        var repository = new SaleItemRepository(context);
        var saleItem = new SaleItem
        {
            SaleId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 10,
            UnitPrice = 20.0m
        };

        // Act
        await repository.ApplyBusinessRulesAsync(saleItem);

        // Assert
        Assert.Equal(4.0m, saleItem.Discount); // 20% discount
        Assert.Equal(160.0m, saleItem.TotalAmount); // (20 - 4) * 10
    }
}
