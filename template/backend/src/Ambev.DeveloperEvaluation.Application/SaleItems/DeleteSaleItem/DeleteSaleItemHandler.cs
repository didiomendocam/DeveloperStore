using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Exceptions;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, DeleteSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public DeleteSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSaleItemResult> Handle(DeleteSaleItemCommand command, CancellationToken cancellationToken)
    {
        var saleItem = await _saleItemRepository.GetByIdAsync(command.Id, cancellationToken);
        if (saleItem == null)
            throw new EntityNotFoundException("SaleItem", command.Id);
            
        await _saleItemRepository.DeleteAsync(saleItem, cancellationToken);
        return new DeleteSaleItemResult { Id = saleItem.Id };
    }
}
