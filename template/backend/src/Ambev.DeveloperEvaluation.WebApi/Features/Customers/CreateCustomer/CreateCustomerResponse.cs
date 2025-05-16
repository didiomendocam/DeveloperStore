namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Contact { get; set; }
}
