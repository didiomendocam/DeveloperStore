using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.ListSaleItems;

public class ListSaleItemsQuery : IRequest<ListSaleItemsResult>, IBaseRequest
{
    public Guid SaleId { get; set; }
}
