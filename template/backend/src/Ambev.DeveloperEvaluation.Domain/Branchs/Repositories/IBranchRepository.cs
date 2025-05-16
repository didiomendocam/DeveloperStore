using Ambev.DeveloperEvaluation.Domain.Branchs;

namespace Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;

public interface IBranchRepository
{
    Task<Branch?> GetById(Guid id);
    Task<IEnumerable<Branch>> GetAll();
    Task<IEnumerable<Branch>> GetActive();
    Task<IEnumerable<Branch>> GetBySearchTerm(string searchTerm);
    Task Add(Branch branch);
    Task Update(Branch branch);
    Task Delete(Branch branch);
    Task SaveChanges();
} 