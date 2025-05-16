using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.ListSaleItems;

public class ListSaleItemsProfile : Profile
{
    public ListSaleItemsProfile()
    {
        CreateMap<SaleItem, SaleItemDto>();
    }
}
