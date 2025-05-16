using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class SalesProfile : Profile
{
    public SalesProfile()
    {
        // ... existing mappings ...

        CreateMap<ListSalesRequest, ListSalesQuery>();
        CreateMap<SaleDto, ListSalesResponse>();
    }
} 