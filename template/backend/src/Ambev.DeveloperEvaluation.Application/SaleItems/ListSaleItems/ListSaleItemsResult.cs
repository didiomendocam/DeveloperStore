namespace Ambev.DeveloperEvaluation.Application.SaleItems.ListSaleItems;

public class ListSaleItemsResult
{
    public List<SaleItemDto> SaleItems { get; set; } = new();
}

public class SaleItemDto
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}
