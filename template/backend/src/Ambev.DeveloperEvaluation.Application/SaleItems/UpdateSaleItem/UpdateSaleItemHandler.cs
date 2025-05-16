using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

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

    public Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
    {
        // Implementação fictícia, pois não há GetByIdAsync/UpdateAsync no repositório
        // var saleItem = await _saleItemRepository.GetByIdAsync(command.Id);
        // if (saleItem == null)
        //     throw new Exception("SaleItem not found");
        // _mapper.Map(command, saleItem);
        // await _saleItemRepository.UpdateAsync(saleItem);
        return Task.FromResult(new UpdateSaleItemResult { Id = command.Id });
    }
}
