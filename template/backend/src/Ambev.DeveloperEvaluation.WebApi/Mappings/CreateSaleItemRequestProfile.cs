using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateSaleItemRequestProfile : Profile
{
    public CreateSaleItemRequestProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}
