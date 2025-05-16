using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

public class DeleteSaleItemProfile : Profile
{
    public DeleteSaleItemProfile()
    {
        CreateMap<SaleItem, DeleteSaleItemResult>();
    }
}
