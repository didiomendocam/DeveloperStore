using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Functional.WebApi.Controllers;

public class SaleItemsControllerFunctionalTests
{
    private readonly HttpClient _client;

    public SaleItemsControllerFunctionalTests()
    {
        // Assume _client is initialized with a test server
    }

    [Fact(DisplayName = "Given a valid sale ID When adding an item Then should return 201 Created")]
    public async Task AddItemToSale_ShouldReturnCreated()
    {
        // Act
        var response = await _client.PostAsync("/api/sales/{saleId}/items", new StringContent("{}"));

        // Assert
        Assert.Equal(201, (int)response.StatusCode);
    }
}
