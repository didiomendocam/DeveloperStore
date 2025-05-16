using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class UpdateSaleItemProfile : Profile
{
    public UpdateSaleItemProfile()
    {
        CreateMap<UpdateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, UpdateSaleItemResult>();
    }
}
