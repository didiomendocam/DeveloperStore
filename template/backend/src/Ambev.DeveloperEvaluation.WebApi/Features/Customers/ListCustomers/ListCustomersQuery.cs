using Ambev.DeveloperEvaluation.Application.Customers.Queries.ListCustomers;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.ListCustomers;

public class ListCustomersQuery : IRequest<PaginatedList<ListCustomersResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 