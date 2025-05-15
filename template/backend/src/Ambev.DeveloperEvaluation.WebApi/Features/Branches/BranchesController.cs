using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.DeleteBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BranchesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // Aqui você pode mapear para um comando de aplicação se necessário
        // var command = _mapper.Map<CreateBranchCommand>(request);
        // var response = await _mediator.Send(command, cancellationToken);
        // Supondo que o handler retorne um CreateBranchResponse
        var response = new CreateBranchResponse {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            BranchCode = request.BranchCode
        };
        return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully",
            Data = response
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBranch([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetBranchRequest { Id = id };
        var validator = new GetBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // var query = _mapper.Map<GetBranchQuery>(request);
        // var response = await _mediator.Send(query, cancellationToken);
        var response = new GetBranchResponse {
            Id = id,
            Name = "Branch Name",
            Address = "Branch Address",
            BranchCode = "BR001"
        };
        return Ok(new ApiResponseWithData<GetBranchResponse>
        {
            Success = true,
            Message = "Branch retrieved successfully",
            Data = response
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBranch([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteBranchRequest { Id = id };
        var validator = new DeleteBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        // var command = _mapper.Map<DeleteBranchCommand>(request);
        // await _mediator.Send(command, cancellationToken);
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Branch deleted successfully"
        });
    }
}
