using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.WebApi.Controllers;

public class SalesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly SalesController _controller;

    public SalesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new SalesController(_mediatorMock.Object);
    }

    [Fact(DisplayName = "Given a valid request When getting all sales Then should return Ok result")]
    public async Task GetAllSales_ShouldReturnOk()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(new object());

        // Act
        var result = await _controller.GetAllSales();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact(DisplayName = "Given a valid sale ID When getting sale by ID Then should return Ok result")]
    public async Task GetSaleById_ShouldReturnOk()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(new object());

        // Act
        var result = await _controller.GetSaleById(saleId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact(DisplayName = "Given a valid sale When creating sale Then should return Created result")]
    public async Task CreateSale_ShouldReturnCreated()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(new { Id = Guid.NewGuid() });

        // Act
        var result = await _controller.CreateSale(new object());

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}
