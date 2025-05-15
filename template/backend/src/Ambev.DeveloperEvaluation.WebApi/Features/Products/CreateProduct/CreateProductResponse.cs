namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ProductCode { get; set; }
    public required decimal UnitPrice { get; set; }
}
