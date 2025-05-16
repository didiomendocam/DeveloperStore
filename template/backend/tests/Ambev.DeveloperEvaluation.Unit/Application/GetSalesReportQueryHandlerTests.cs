using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Moq;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class GetSalesReportQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsCorrectReportData()
    {
        // Arrange
        var sale1 = new Sale
        {
            SaleDate = new DateTime(2024, 1, 1),
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = 100,
            Status = SaleStatus.Confirmed,
            Items = new List<SaleItem>(),
            Customer = new Customer { Name = "Customer 1", Document = "12345678901", Contact = "customer1@email.com" },
            Branch = new Branch { Name = "Branch 1" }
        };
        var sale2 = new Sale
        {
            SaleDate = new DateTime(2024, 1, 2),
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            TotalAmount = 200,
            Status = SaleStatus.Confirmed,
            Items = new List<SaleItem>(),
            Customer = new Customer { Name = "Customer 2", Document = "98765432100", Contact = "customer2@email.com" },
            Branch = new Branch { Name = "Branch 2" }
        };
        var item1 = new SaleItem { ProductId = Guid.NewGuid(), Quantity = 2, UnitPrice = 50, Discount = 0, Product = new Product { Name = "Product A" }, Sale = sale1 };
        var item2 = new SaleItem { ProductId = Guid.NewGuid(), Quantity = 4, UnitPrice = 50, Discount = 0, Product = new Product { Name = "Product B" }, Sale = sale2 };
        sale1.Items.Add(item1);
        sale2.Items.Add(item2);
        var sales = new List<Sale> { sale1, sale2 };

        var repoMock = new Mock<ISaleRepository>();
        repoMock.Setup(r => r.Query()).Returns(sales.AsQueryable());
        var handler = new GetSalesReportQueryHandler(repoMock.Object);
        var query = new GetSalesReportQuery
        {
            StartDate = new DateTime(2024, 1, 1),
            EndDate = new DateTime(2024, 1, 31)
        };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.TotalSales);
        Assert.Equal(300, result.TotalRevenue);
        Assert.Equal(6, result.TotalItemsSold);
        Assert.Equal(150, result.AverageSaleValue);
        Assert.NotNull(result.TopProducts);
        Assert.NotNull(result.TopCustomers);
    }
}
