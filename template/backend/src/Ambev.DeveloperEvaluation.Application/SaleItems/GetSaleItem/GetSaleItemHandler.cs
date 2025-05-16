using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Exceptions;

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

    public async Task<GetSaleItemResult> Handle(GetSaleItemQuery query, CancellationToken cancellationToken)
    {
        var saleItem = await _saleItemRepository.GetByIdAsync(query.Id, cancellationToken);
        if (saleItem == null)
            throw new EntityNotFoundException("SaleItem", query.Id);
        return _mapper.Map<GetSaleItemResult>(saleItem);
    }
}
