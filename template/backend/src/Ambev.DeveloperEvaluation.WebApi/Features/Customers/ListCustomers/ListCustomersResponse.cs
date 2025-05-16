namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.ListCustomers;

public class ListCustomersResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public bool IsActive { get; set; }
} 