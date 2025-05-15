using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

public class GetCustomerProfile : Profile
{
    public GetCustomerProfile()
    {
        CreateMap<GetCustomerRequest, GetCustomerResponse>();
    }
}
