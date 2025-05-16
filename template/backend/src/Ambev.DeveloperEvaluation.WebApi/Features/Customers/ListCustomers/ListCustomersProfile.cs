using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.ListCustomers;

public class ListCustomersProfile : Profile
{
    public ListCustomersProfile()
    {
        CreateMap<Customer, ListCustomersResponse>();
    }
} 