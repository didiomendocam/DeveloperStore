using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemResponse>();
    }
}
