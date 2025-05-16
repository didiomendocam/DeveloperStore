namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

public class GetCustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Contact { get; set; }
}
