namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

public class GetCustomerResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
