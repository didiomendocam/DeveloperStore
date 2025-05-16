using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Exceptions;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public UpdateSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var saleItem = await _saleItemRepository.GetByIdAsync(command.Id, cancellationToken);
        if (saleItem == null)
            throw new EntityNotFoundException("SaleItem", command.Id);
            
        _mapper.Map(command, saleItem);
        await _saleItemRepository.ApplyBusinessRulesAsync(saleItem, cancellationToken);
        await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);
        return _mapper.Map<UpdateSaleItemResult>(saleItem);
    }
}
