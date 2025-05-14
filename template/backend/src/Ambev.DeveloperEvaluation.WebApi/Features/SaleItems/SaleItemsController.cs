using Ambev.DeveloperEvaluation.Application.Commands;
using Ambev.DeveloperEvaluation.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

[ApiController]
[Route("api/sales/{saleId}/items")]
public class SaleItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaleItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetItemsBySaleId(Guid saleId)
    {
        var query = new GetItemsBySaleIdQuery(saleId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddItemToSale(Guid saleId, [FromBody] AddItemToSaleCommand command)
    {
        if (saleId != command.SaleId)
        {
            return BadRequest("Sale ID in the URL does not match Sale ID in the body.");
        }

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetItemsBySaleId), new { saleId = command.SaleId }, result);
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateItemInSale(Guid saleId, Guid itemId, [FromBody] UpdateItemInSaleCommand command)
    {
        if (saleId != command.SaleId || itemId != command.ItemId)
        {
            return BadRequest("Sale ID or Item ID in the URL does not match IDs in the body.");
        }

        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> CancelItemInSale(Guid saleId, Guid itemId)
    {
        var command = new CancelItemInSaleCommand(saleId, itemId);
        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }
}
