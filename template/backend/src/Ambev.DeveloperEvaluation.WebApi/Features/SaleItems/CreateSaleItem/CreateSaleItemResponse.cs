namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemResponse
{
    public Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
}
