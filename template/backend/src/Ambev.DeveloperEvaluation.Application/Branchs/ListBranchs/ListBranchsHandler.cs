using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranchs;

public class ListBranchsHandler : IRequestHandler<ListBranchsQuery, ListBranchsResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public ListBranchsHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<ListBranchsResult> Handle(ListBranchsQuery query, CancellationToken cancellationToken)
    {
        var branchs = await _branchRepository.GetAllAsync(cancellationToken);
        return new ListBranchsResult
        {
            Branchs = _mapper.Map<List<BranchDto>>(branchs)
        };
    }
}
