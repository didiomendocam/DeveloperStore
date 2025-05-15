using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DbContext _context;

    public SaleRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sale sale)
    {
        await _context.Set<Sale>().AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Sale>().FindAsync(id);
    }

    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
        return await _context.Set<Sale>().ToListAsync();
    }
}
