using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

public class GetSaleItemProfile : Profile
{
    public GetSaleItemProfile()
    {
        CreateMap<GetSaleItemRequest, GetSaleItemResponse>();
    }
}
