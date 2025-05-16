using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;

public class DeleteCustomerProfile : Profile
{
    public DeleteCustomerProfile()
    {
        CreateMap<Customer, DeleteCustomerResult>();
    }
}
