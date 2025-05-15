namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public required string SaleNumber { get; set; }
    public required DateTime SaleDate { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid BranchId { get; set; }
    public required List<CreateSaleItemResponse> Items { get; set; }
}
