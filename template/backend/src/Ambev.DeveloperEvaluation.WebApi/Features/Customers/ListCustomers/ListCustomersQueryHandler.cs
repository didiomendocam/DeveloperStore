using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.ListCustomers;

public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, PaginatedList<ListCustomersResponse>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ListCustomersResponse>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Customers.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(c =>
                c.Name.ToLower().Contains(searchTerm) ||
                c.Email.ToLower().Contains(searchTerm) ||
                c.Document.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            query = request.SortBy.ToLower() switch
            {
                "name" => request.SortDescending
                    ? query.OrderByDescending(c => c.Name)
                    : query.OrderBy(c => c.Name),
                "email" => request.SortDescending
                    ? query.OrderByDescending(c => c.Email)
                    : query.OrderBy(c => c.Email),
                "document" => request.SortDescending
                    ? query.OrderByDescending(c => c.Document)
                    : query.OrderBy(c => c.Document),
                _ => query.OrderBy(c => c.Name)
            };
        }
        else
        {
            query = query.OrderBy(c => c.Name);
        }

        var customers = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = _mapper.Map<List<ListCustomersResponse>>(customers);

        return new PaginatedList<ListCustomersResponse>(
            items,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
} 