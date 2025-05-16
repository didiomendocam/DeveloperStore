using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

public class GetSaleItemHandler : IRequestHandler<GetSaleItemQuery, GetSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public GetSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public Task<GetSaleItemResult> Handle(GetSaleItemQuery query, CancellationToken cancellationToken)
    {
        // Implementação fictícia, pois não há GetByIdAsync no repositório
        // var saleItem = await _saleItemRepository.GetByIdAsync(query.Id);
        // if (saleItem == null)
        //     throw new Exception("SaleItem not found");
        return Task.FromResult(new GetSaleItemResult { Id = query.Id });
    }
}
