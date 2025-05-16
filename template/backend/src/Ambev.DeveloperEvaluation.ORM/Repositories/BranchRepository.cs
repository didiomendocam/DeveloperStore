using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.Domain.Branchs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;

    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Branch?> GetById(Guid id)
    {
        return await _context.Branches.FindAsync(id);
    }

    public async Task<IEnumerable<Branch>> GetAll()
    {
        return await _context.Branches.ToListAsync();
    }

    public async Task<IEnumerable<Branch>> GetActive()
    {
        return await _context.Branches.Where(b => b.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<Branch>> GetBySearchTerm(string searchTerm)
    {
        return await _context.Branches
            .Where(b => b.Name.Contains(searchTerm) ||
                       b.Cnpj.Contains(searchTerm) ||
                       b.Address.Contains(searchTerm) ||
                       b.Phone.Contains(searchTerm) ||
                       b.Email.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task Add(Branch branch)
    {
        await _context.Branches.AddAsync(branch);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Branch branch)
    {
        _context.Branches.Update(branch);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Branch branch)
    {
        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
