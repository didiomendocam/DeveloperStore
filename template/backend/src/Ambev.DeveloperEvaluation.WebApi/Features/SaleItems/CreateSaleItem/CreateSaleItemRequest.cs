namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemRequest
{
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
}
