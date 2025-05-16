using Ambev.DeveloperEvaluation.Application.Customers.Queries.ListCustomers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.ListCustomers;

public class ListCustomersMappingProfile : Profile
{
    public ListCustomersMappingProfile()
    {
        CreateMap<Domain.Entities.Customer, ListCustomersResponse>();
    }
} 