using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchService
{
    private readonly IBranchRepository _branchRepository;

    public GetBranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<GetBranchDto> Execute(Guid id)
    {
        var branch = await _branchRepository.GetById(id);
        if (branch == null)
        {
            throw new Exception($"Branch with id {id} not found");
        }

        return new GetBranchDto
        {
            Id = branch.Id,
            Name = branch.Name,
            Cnpj = branch.Cnpj,
            Address = branch.Address,
            Phone = branch.Phone,
            Email = branch.Email,
            IsActive = branch.IsActive,
            CreatedAt = branch.CreatedAt,
            UpdatedAt = branch.UpdatedAt
        };
    }
} 