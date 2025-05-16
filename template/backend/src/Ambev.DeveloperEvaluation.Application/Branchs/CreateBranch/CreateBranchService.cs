using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchService
{
    private readonly IBranchRepository _branchRepository;

    public CreateBranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Guid> Execute(CreateBranchDto dto)
    {
        var branch = new Branch(
            dto.Name,
            dto.Cnpj,
            dto.Address,
            dto.Phone,
            dto.Email,
            dto.IsActive
        );

        await _branchRepository.Add(branch);
        await _branchRepository.SaveChanges();

        return branch.Id;
    }
} 