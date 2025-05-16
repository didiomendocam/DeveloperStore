namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts;

public class ListProductsResult
{
    public List<ProductDto> Products { get; set; } = new();
}

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ProductCode { get; set; }
    public decimal UnitPrice { get; set; }
    public int Status { get; set; }
}
