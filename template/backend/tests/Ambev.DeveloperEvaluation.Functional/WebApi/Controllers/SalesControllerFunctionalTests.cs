using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Functional.WebApi.Controllers;

public class SalesControllerFunctionalTests
{
    private readonly HttpClient _client;

    public SalesControllerFunctionalTests()
    {
        // Assume _client is initialized with a test server
    }

    [Fact(DisplayName = "Given a valid request When creating a sale Then should return 201 Created")]
    public async Task CreateSale_ShouldReturnCreated()
    {
        // Act
        var response = await _client.PostAsync("/api/sales", new StringContent("{}"));

        // Assert
        Assert.Equal(201, (int)response.StatusCode);
    }
}
