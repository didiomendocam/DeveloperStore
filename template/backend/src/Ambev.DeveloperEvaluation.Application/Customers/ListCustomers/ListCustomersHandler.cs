using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Customers.ListCustomers;

public class ListCustomersHandler : IRequestHandler<ListCustomersQuery, ListCustomersResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public ListCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ListCustomersResult> Handle(ListCustomersQuery query, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync(cancellationToken);
        return new ListCustomersResult
        {
            Customers = _mapper.Map<List<CustomerDto>>(customers)
        };
    }
}
