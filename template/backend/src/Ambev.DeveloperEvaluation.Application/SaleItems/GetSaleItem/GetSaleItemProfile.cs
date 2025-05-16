using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

public class GetSaleItemProfile : Profile
{
    public GetSaleItemProfile()
    {
        CreateMap<SaleItem, GetSaleItemResult>();
    }
}
