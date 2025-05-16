using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

public class DeleteCustomerProfile : Profile
{
    public DeleteCustomerProfile()
    {
        CreateMap<DeleteCustomerRequest, DeleteCustomerResponse>();
    }
}
