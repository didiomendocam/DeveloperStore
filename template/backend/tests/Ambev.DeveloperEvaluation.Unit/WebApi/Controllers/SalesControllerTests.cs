using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Moq;
using MediatR;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Unit.WebApi.Controllers;

public class SalesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock; // Add a mock for IMapper
    private readonly SalesController _controller;

    public SalesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapperMock = new Mock<IMapper>(); // Initialize the IMapper mock
        _controller = new SalesController(_mediatorMock.Object, _mapperMock.Object); // Pass the IMapper mock to the constructor
    }

    // Existing test methods remain unchanged
}
