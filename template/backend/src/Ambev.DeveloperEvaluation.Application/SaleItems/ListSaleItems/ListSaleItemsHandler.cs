using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.ListSaleItems;

public class ListSaleItemsHandler : IRequestHandler<ListSaleItemsQuery, ListSaleItemsResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public ListSaleItemsHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public Task<ListSaleItemsResult> Handle(ListSaleItemsQuery query, CancellationToken cancellationToken)
    {
        // Implementação fictícia, pois não há GetAllAsync no repositório
        // var saleItems = await _saleItemRepository.GetAllAsync(cancellationToken);
        // return new ListSaleItemsResult
        // {
        //     SaleItems = _mapper.Map<List<SaleItemDto>>(saleItems)
        // };
        return Task.FromResult(new ListSaleItemsResult());
    }
}
