using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // var command = _mapper.Map<CreateCustomerCommand>(request);
        // var response = await _mediator.Send(command, cancellationToken);
        var response = new CreateCustomerResponse {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Document = request.Document,
            Contact = request.Contact
        };
        return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
        {
            Success = true,
            Message = "Customer created successfully",
            Data = response
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCustomerRequest { Id = id };
        var validator = new GetCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // var query = _mapper.Map<GetCustomerQuery>(request);
        // var response = await _mediator.Send(query, cancellationToken);
        var response = new GetCustomerResponse {
            Id = id,
            Name = "Customer Name",
            Document = "12345678900",
            Contact = "customer@email.com"
        };
        return Ok(new ApiResponseWithData<GetCustomerResponse>
        {
            Success = true,
            Message = "Customer retrieved successfully",
            Data = response
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCustomerRequest { Id = id };
        var validator = new DeleteCustomerRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // var command = _mapper.Map<DeleteCustomerCommand>(request);
        // await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Customer deleted successfully"
        });
    }
}
