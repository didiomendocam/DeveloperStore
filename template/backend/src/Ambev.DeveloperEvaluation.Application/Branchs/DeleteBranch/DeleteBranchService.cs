using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

public class DeleteBranchService
{
    private readonly IBranchRepository _branchRepository;

    public DeleteBranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task Execute(Guid id)
    {
        var branch = await _branchRepository.GetById(id);
        if (branch == null)
        {
            throw new Exception($"Branch with id {id} not found");
        }

        await _branchRepository.Delete(branch);
        await _branchRepository.SaveChanges();
    }
} 