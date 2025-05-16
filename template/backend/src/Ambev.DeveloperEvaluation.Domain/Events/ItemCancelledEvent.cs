using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ItemCancelledEvent
{
    public SaleItem SaleItem { get; }

    public ItemCancelledEvent(SaleItem saleItem)
    {
        SaleItem = saleItem;
    }
}
