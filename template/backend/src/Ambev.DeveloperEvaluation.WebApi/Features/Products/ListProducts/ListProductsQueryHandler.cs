using Ambev.DeveloperEvaluation.Application.Products.Queries.ListProducts;
using Ambev.DeveloperEvaluation.Application.Common.Models;
using Ambev.DeveloperEvaluation.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, PaginatedList<ListProductsResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ListProductsResponse>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(searchTerm) ||
                p.ProductCode.ToLower().Contains(searchTerm)); // Fixed: Replaced "Description" with "ProductCode"
        }

        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            query = request.SortBy.ToLower() switch
            {
                "name" => request.SortDescending
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name),
                "productcode" => request.SortDescending
                    ? query.OrderByDescending(p => p.ProductCode) // Fixed: Added sorting by "ProductCode"
                    : query.OrderBy(p => p.ProductCode),
                "price" => request.SortDescending
                    ? query.OrderByDescending(p => p.UnitPrice) // Fixed: Corrected "Price" to "UnitPrice"
                    : query.OrderBy(p => p.UnitPrice),
                _ => query.OrderBy(p => p.Name)
            };
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var products = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = _mapper.Map<List<ListProductsResponse>>(products);

        return new PaginatedList<ListProductsResponse>(
            items,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}
