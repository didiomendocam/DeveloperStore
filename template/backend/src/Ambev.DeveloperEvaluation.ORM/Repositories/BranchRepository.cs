using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly DbContext _context;

    public BranchRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        await _context.Set<Branch>().AddAsync(branch, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Branch>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Branch>().ToListAsync(cancellationToken);
    }
}
