using Ambev.DeveloperEvaluation.Application.Common.Models;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.ListSaleItems;

public class ListSaleItemsQuery : IRequest<PaginatedList<ListSaleItemsResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 