using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

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
        // Implementação fictícia, pois não há DeleteAsync no repositório
        // var saleItem = await _saleItemRepository.GetByIdAsync(command.Id);
        // if (saleItem == null)
        //     throw new Exception("SaleItem not found");
        // await _saleItemRepository.DeleteAsync(saleItem);
        return new DeleteSaleItemResult { Id = command.Id };
    }
}
