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

    public async Task<ListSaleItemsResult> Handle(ListSaleItemsQuery query, CancellationToken cancellationToken)
    {
        var saleItems = await _saleItemRepository.GetBySaleIdAsync(query.SaleId, cancellationToken);
        return new ListSaleItemsResult
        {
            SaleItems = _mapper.Map<List<SaleItemDto>>(saleItems)
        };
    }
}
