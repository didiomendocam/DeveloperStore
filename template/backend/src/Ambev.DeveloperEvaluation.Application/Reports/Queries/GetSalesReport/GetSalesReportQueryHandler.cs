using MediatR;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;

/// <summary>
/// Handler for generating sales reports
/// </summary>
public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQuery, GetSalesReportResult>
{
    private readonly ISaleRepository _salesRepository;

    public GetSalesReportQueryHandler(ISaleRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }

    public async Task<GetSalesReportResult> Handle(GetSalesReportQuery request, CancellationToken cancellationToken)
    {
        var salesQuery = _salesRepository.Query()
            .Include(s => s.Customer)
            .Include(s => s.Branch)
            .Include(s => s.Items!)
                .ThenInclude(i => i.Product)
            .Where(s => s.SaleDate >= request.StartDate && s.SaleDate <= request.EndDate);

        if (request.CustomerId.HasValue)
            salesQuery = salesQuery.Where(s => s.CustomerId == request.CustomerId.Value);

        if (request.BranchId.HasValue)
            salesQuery = salesQuery.Where(s => s.BranchId == request.BranchId.Value);

        if (request.ProductId.HasValue)
            salesQuery = salesQuery.Where(s => (s.Items != null && s.Items.Any(i => i.ProductId == request.ProductId.Value)));

        if (request.Status.HasValue)
            salesQuery = salesQuery.Where(s => s.Status == (SaleStatus)request.Status.Value);

        if (request.IncludeCancelled == false)
            salesQuery = salesQuery.Where(s => s.Status != SaleStatus.Cancelled);

        var sales = await salesQuery.ToListAsync(cancellationToken);

        var result = new GetSalesReportResult
        {
            TotalSales = sales.Count,
            TotalRevenue = sales.Sum(s => s.TotalAmount),
            TotalItemsSold = sales.Sum(s => s.Items != null ? s.Items.Sum(i => i.Quantity) : 0)
        };

        result.AverageSaleValue = result.TotalSales > 0 ? result.TotalRevenue / result.TotalSales : 0;

        // Group sales data
        if (!string.IsNullOrEmpty(request.GroupBy))
        {
            result.Groups = request.GroupBy.ToLower() switch
            {
                "customer" => sales.GroupBy(s => new { s.CustomerId, Name = s.Customer?.Name ?? string.Empty })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items != null ? s.Items.Sum(i => i.Quantity) : 0)
                    }).ToList(),

                "branch" => sales.GroupBy(s => new { s.BranchId, Name = s.Branch?.Name ?? string.Empty })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items != null ? s.Items.Sum(i => i.Quantity) : 0)
                    }).ToList(),

                "product" => sales.SelectMany(s => s.Items ?? Array.Empty<SaleItem>())
                    .GroupBy(i => new { i.ProductId, Name = i.Product?.Name ?? string.Empty })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(i => i.TotalAmount),
                        ItemsSold = g.Sum(i => i.Quantity)
                    }).ToList(),

                "date" => sales.GroupBy(s => s.SaleDate.Date)
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.ToShortDateString(),
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items != null ? s.Items.Sum(i => i.Quantity) : 0)
                    }).ToList(),

                _ => new List<SalesGroupResult>()
            };
        }

        // Get top products
        result.TopProducts = sales.SelectMany(s => s.Items ?? Array.Empty<SaleItem>())
            .GroupBy(i => new { i.ProductId, Name = i.Product?.Name ?? string.Empty })
            .Select(g => new TopProductResult
            {
                ProductId = g.Key.ProductId,
                ProductName = g.Key.Name,
                UnitsSold = g.Sum(i => i.Quantity),
                Revenue = g.Sum(i => i.TotalAmount)
            })
            .OrderByDescending(p => p.Revenue)
            .Take(10)
            .ToList();

        // Get top customers
        result.TopCustomers = sales.GroupBy(s => new { s.CustomerId, Name = s.Customer?.Name ?? string.Empty })
            .Select(g => new TopCustomerResult
            {
                CustomerId = g.Key.CustomerId,
                CustomerName = g.Key.Name,
                PurchaseCount = g.Count(),
                Revenue = g.Sum(s => s.TotalAmount)
            })
            .OrderByDescending(c => c.Revenue)
            .Take(10)
            .ToList();

        return result;
    }
}