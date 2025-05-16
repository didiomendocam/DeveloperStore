using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class ListSalesHandler : IRequestHandler<ListSalesQuery, ListSalesResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public ListSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<ListSalesResult> Handle(ListSalesQuery query, CancellationToken cancellationToken)
    {
        var salesQuery = _saleRepository.Query();

        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var searchTerm = query.SearchTerm.ToLower();
            salesQuery = salesQuery.Where(s =>
                s.SaleNumber.ToLower().Contains(searchTerm) ||
                s.Customer.Name.ToLower().Contains(searchTerm) ||
                s.Branch.Name.ToLower().Contains(searchTerm));
        }

        if (query.Status.HasValue)
        {
            salesQuery = salesQuery.Where(s => s.Status == query.Status.Value);
        }

        if (query.StartDate.HasValue)
        {
            salesQuery = salesQuery.Where(s => s.SaleDate >= query.StartDate.Value);
        }

        if (query.EndDate.HasValue)
        {
            salesQuery = salesQuery.Where(s => s.SaleDate <= query.EndDate.Value);
        }

        var sales = await salesQuery.ToListAsync(cancellationToken);
        return new ListSalesResult
        {
            Sales = _mapper.Map<List<SaleDto>>(sales)
        };
    }
}
