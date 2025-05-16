using Microsoft.AspNetCore.Mvc;
using Xunit;
using MediatR;

namespace Ambev.DeveloperEvaluation.Unit.WebApi.Controllers;

public class SaleItemsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly SaleItemsController _controller;

    public SaleItemsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new SaleItemsController(_mediatorMock.Object);
    }

    [Fact(DisplayName = "Given a valid sale ID When getting items Then should return Ok result")]
    public async Task GetItemsBySaleId_ShouldReturnOk()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(new object());

        // Act
        var result = await _controller.GetItemsBySaleId(saleId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact(DisplayName = "Given a valid item When adding item to sale Then should return Created result")]
    public async Task AddItemToSale_ShouldReturnCreated()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(new { Id = Guid.NewGuid() });

        // Act
        var result = await _controller.AddItemToSale(saleId, new object());

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}
