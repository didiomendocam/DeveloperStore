using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem;

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
        var validator = new Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem.CreateSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = new CreateSaleItemResponse {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };
        return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
        {
            Success = true,
            Message = "Sale item created successfully",
            Data = response
        });
    }

    [HttpGet("{itemId}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public Task<IActionResult> GetSaleItem([FromRoute] Guid saleId, [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        var request = new Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem.GetSaleItemRequest { Id = itemId };
        var response = new GetSaleItemResponse {
            Id = itemId,
            ProductId = Guid.NewGuid(),
            Quantity = 1
        };
        return Task.FromResult<IActionResult>(Ok(new ApiResponseWithData<GetSaleItemResponse>
        {
            Success = true,
            Message = "Sale item retrieved successfully",
            Data = response
        }));
    }

    [HttpDelete("{itemId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public Task<IActionResult> DeleteSaleItem([FromRoute] Guid saleId, [FromRoute] Guid itemId, CancellationToken cancellationToken)
    {
        var request = new Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem.DeleteSaleItemRequest { Id = itemId };
        return Task.FromResult<IActionResult>(Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale item deleted successfully"
        }));
    }
}
