using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

public class GetSaleItemQuery : IRequest<GetSaleItemResult>
{
    public Guid Id { get; set; }
}
