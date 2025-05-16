using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Controllers;

public class SalesControllerIntegrationTests
{
    private readonly HttpClient _client;

    public SalesControllerIntegrationTests()
    {
        // Assume _client is initialized with a test server
    }

    [Fact(DisplayName = "Given a valid request When getting all sales Then should return 200 OK")]
    public async Task GetAllSales_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/api/sales");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
