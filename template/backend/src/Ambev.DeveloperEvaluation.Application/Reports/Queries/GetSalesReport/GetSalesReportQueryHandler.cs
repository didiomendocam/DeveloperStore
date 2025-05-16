using Ambev.DeveloperEvaluation.Application.Common.Interfaces; // Adicione este using
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;

/// <summary>
/// Handler for generating sales reports
/// </summary>
public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQuery, GetSalesReportResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesReportQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSalesReportResult> Handle(GetSalesReportQuery request, CancellationToken cancellationToken)
    {
        var salesQuery = _unitOfWork.SalesRepository.GetQueryable()
            .Include(s => s.Customer)
            .Include(s => s.Branch)
            .Include(s => s.Items)
                .ThenInclude(i => i.Product)
            .Where(s => s.CreatedAt >= request.StartDate && s.CreatedAt <= request.EndDate);

        if (request.CustomerId.HasValue)
            salesQuery = salesQuery.Where(s => s.CustomerId == request.CustomerId.Value);

        if (request.BranchId.HasValue)
            salesQuery = salesQuery.Where(s => s.BranchId == request.BranchId.Value);

        if (request.ProductId.HasValue)
            salesQuery = salesQuery.Where(s => s.Items.Any(i => i.ProductId == request.ProductId.Value));

        if (request.Status.HasValue)
            salesQuery = salesQuery.Where(s => s.Status == request.Status.Value);

        if (!request.IncludeCancelled ?? false)
            salesQuery = salesQuery.Where(s => s.Status != 3); // 3 = Cancelled

        var sales = await salesQuery.ToListAsync(cancellationToken);

        var result = new GetSalesReportResult
        {
            TotalSales = sales.Count,
            TotalRevenue = sales.Sum(s => s.TotalAmount),
            TotalItemsSold = sales.Sum(s => s.Items.Sum(i => i.Quantity))
        };

        result.AverageSaleValue = result.TotalSales > 0 ? result.TotalRevenue / result.TotalSales : 0;

        // Group sales data
        if (!string.IsNullOrEmpty(request.GroupBy))
        {
            result.Groups = request.GroupBy.ToLower() switch
            {
                "customer" => sales.GroupBy(s => new { s.CustomerId, s.Customer.Name })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items.Sum(i => i.Quantity))
                    }).ToList(),

                "branch" => sales.GroupBy(s => new { s.BranchId, s.Branch.Name })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items.Sum(i => i.Quantity))
                    }).ToList(),

                "product" => sales.SelectMany(s => s.Items)
                    .GroupBy(i => new { i.ProductId, i.Product.Name })
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.Name,
                        SalesCount = g.Count(),
                        Revenue = g.Sum(i => i.TotalAmount),
                        ItemsSold = g.Sum(i => i.Quantity)
                    }).ToList(),

                "date" => sales.GroupBy(s => s.CreatedAt.Date)
                    .Select(g => new SalesGroupResult
                    {
                        Key = g.Key.ToShortDateString(),
                        SalesCount = g.Count(),
                        Revenue = g.Sum(s => s.TotalAmount),
                        ItemsSold = g.Sum(s => s.Items.Sum(i => i.Quantity))
                    }).ToList(),

                _ => new List<SalesGroupResult>()
            };
        }

        // Get top products
        result.TopProducts = sales.SelectMany(s => s.Items)
            .GroupBy(i => new { i.ProductId, i.Product.Name })
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
        result.TopCustomers = sales.GroupBy(s => new { s.CustomerId, s.Customer.Name })
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