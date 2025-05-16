using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

// Profile para mapeamento de criação de item de venda
namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}
