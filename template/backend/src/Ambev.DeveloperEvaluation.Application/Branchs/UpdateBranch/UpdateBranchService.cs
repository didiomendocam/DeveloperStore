using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchService
{
    private readonly IBranchRepository _branchRepository;

    public UpdateBranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task Execute(Guid id, UpdateBranchDto dto)
    {
        var branch = await _branchRepository.GetById(id);
        if (branch == null)
        {
            throw new Exception($"Branch with id {id} not found");
        }

        branch.Update(
            dto.Name,
            dto.Cnpj,
            dto.Address,
            dto.Phone,
            dto.Email,
            dto.IsActive
        );

        await _branchRepository.Update(branch);
        await _branchRepository.SaveChanges();
    }
} 