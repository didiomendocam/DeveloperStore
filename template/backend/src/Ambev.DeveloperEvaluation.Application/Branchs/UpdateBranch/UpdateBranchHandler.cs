using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public UpdateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<UpdateBranchResult> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);
        if (branch == null)
            throw new Exception("Branch not found");
        _mapper.Map(command, branch);
        // await _branchRepository.UpdateAsync(branch, cancellationToken);
        return _mapper.Map<UpdateBranchResult>(branch);
    }
}
