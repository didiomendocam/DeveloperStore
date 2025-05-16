using Ambev.DeveloperEvaluation.Application.Products.Queries.ListProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

public class ListProductsMappingProfile : Profile
{
    public ListProductsMappingProfile()
    {
        CreateMap<Domain.Entities.Product, ListProductsResponse>();
    }
} 