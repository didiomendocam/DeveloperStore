using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.Commands.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.Queries.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.Commands.DeleteSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

[ApiController]
[Route("api/sales/{saleId}/items")]
public class SaleItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleItem([FromRoute] Guid saleId, [FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleItemCommand>(request);
        command.SaleId = saleId;
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
        {
            Success = true,
            Message = "Sale item created successfully",
            Data = _mapper.Map<CreateSaleItemResponse>(response)
        });
    }

    [HttpGet("{itemId}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleItem([FromRoute] Guid saleId, [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        var request = new GetSaleItemRequest { Id = itemId };
        var validator = new GetSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetSaleItemQuery>(request);
        query.SaleId = saleId;
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(new ApiResponseWithData<GetSaleItemResponse>
        {
            Success = true,
            Message = "Sale item retrieved successfully",
            Data = _mapper.Map<GetSaleItemResponse>(response)
        });
    }

    [HttpDelete("{itemId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSaleItem([FromRoute] Guid saleId, [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleItemRequest { Id = itemId };
        var validator = new DeleteSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleItemCommand>(request);
        command.SaleId = saleId;
        await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale item deleted successfully"
        });
    }
}
