namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ProductCode { get; set; }
    public decimal UnitPrice { get; set; }
}
