using Ambev.DeveloperEvaluation.Application.Products.Queries.ListProducts;
using Ambev.DeveloperEvaluation.Application.Common.Models;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductsQuery : IRequest<PaginatedList<ListProductsResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 