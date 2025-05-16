using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

public class DeleteSaleItemCommand : IRequest<DeleteSaleItemResult>
{
    public Guid Id { get; set; }
}
