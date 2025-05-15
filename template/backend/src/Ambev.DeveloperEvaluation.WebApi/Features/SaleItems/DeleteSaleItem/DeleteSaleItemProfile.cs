using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;

public class DeleteSaleItemProfile : Profile
{
    public DeleteSaleItemProfile()
    {
        CreateMap<DeleteSaleItemRequest, DeleteSaleItemResponse>();
    }
}
