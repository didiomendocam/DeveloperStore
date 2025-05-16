using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class ListSalesHandler : IRequestHandler<ListSalesQuery, ListSalesResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public ListSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<ListSalesResult> Handle(ListSalesQuery query, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync(cancellationToken);
        return new ListSalesResult
        {
            Sales = _mapper.Map<List<SaleDto>>(sales)
        };
    }
}
