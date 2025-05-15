using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly DbContext _context;

    public BranchRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Branch branch)
    {
        await _context.Set<Branch>().AddAsync(branch);
        await _context.SaveChangesAsync();
    }

    public async Task<Branch?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Branch>().FindAsync(id);
    }

    public async Task<IEnumerable<Branch>> GetAllAsync()
    {
        return await _context.Set<Branch>().ToListAsync();
    }
}
