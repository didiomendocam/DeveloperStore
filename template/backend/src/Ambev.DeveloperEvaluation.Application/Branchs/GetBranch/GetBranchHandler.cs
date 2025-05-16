using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchHandler : IRequestHandler<GetBranchQuery, GetBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public GetBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<GetBranchResult> Handle(GetBranchQuery query, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(query.Id, cancellationToken);
        if (branch == null)
            throw new Exception("Branch not found");
        return _mapper.Map<GetBranchResult>(branch);
    }
}
