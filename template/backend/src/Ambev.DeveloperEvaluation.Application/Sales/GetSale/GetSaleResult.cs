namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; }
    public string? SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public int Status { get; set; }
}
