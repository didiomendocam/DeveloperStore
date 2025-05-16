using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Reports.SalesReport;
using Ambev.DeveloperEvaluation.Application.Reports.Queries.GetSalesReport;
using Microsoft.AspNetCore.Authorization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Reports;

/// <summary>
/// Controller for generating reports
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ReportsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ReportsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Generates a sales report based on the provided filters
    /// </summary>
    /// <param name="request">The report request with filters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sales report data</returns>
    [HttpGet("sales")]
    [ProducesResponseType(typeof(ApiResponseWithData<SalesReportResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSalesReport([FromQuery] SalesReportRequest request, CancellationToken cancellationToken)
    {
        var validator = new SalesReportRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetSalesReportQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);

        return Ok(new ApiResponseWithData<SalesReportResponse>
        {
            Success = true,
            Message = "Sales report generated successfully",
            Data = _mapper.Map<SalesReportResponse>(response)
        });
    }
} 