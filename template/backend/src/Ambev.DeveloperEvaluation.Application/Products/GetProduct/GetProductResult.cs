namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductResult
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ProductCode { get; set; }
    public decimal UnitPrice { get; set; }
    public int Status { get; set; }
}
