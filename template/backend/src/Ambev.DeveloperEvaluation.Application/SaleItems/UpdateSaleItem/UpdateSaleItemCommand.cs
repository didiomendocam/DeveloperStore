using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class UpdateSaleItemCommand : IRequest<UpdateSaleItemResult>
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
