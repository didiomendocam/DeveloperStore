namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public required string SaleNumber { get; set; }
    public required DateTime SaleDate { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid BranchId { get; set; }
    public required List<CreateSaleItemRequest> Items { get; set; }
}
