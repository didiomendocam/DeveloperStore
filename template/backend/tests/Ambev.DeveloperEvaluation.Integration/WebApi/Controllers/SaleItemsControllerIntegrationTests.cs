using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Controllers;

public class SaleItemsControllerIntegrationTests
{
    private readonly HttpClient _client;

    public SaleItemsControllerIntegrationTests()
    {
        // Assume _client is initialized with a test server
    }

    [Fact(DisplayName = "Given a valid sale ID When getting items Then should return 200 OK")]
    public async Task GetItemsBySaleId_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/api/sales/{saleId}/items");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
