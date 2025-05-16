using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly DbContext _context;

    public SaleItemRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        await _context.Set<SaleItem>().AddAsync(saleItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<SaleItem>()
            .Include(item => item.Sale)
            .Include(item => item.Product)
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<SaleItem>()
            .Include(item => item.Product)
            .Where(item => item.SaleId == saleId)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        _context.Set<SaleItem>().Update(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        _context.Set<SaleItem>().Remove(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ApplyBusinessRulesAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        if (saleItem.Quantity < 4)
        {
            saleItem.Discount = 0;
        }
        else if (saleItem.Quantity >= 4 && saleItem.Quantity < 10)
        {
            saleItem.Discount = saleItem.UnitPrice * 0.10m;
        }
        else if (saleItem.Quantity >= 10 && saleItem.Quantity <= 20)
        {
            saleItem.Discount = saleItem.UnitPrice * 0.20m;
        }
        else if (saleItem.Quantity > 20)
        {
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        }

        saleItem.TotalAmount = (saleItem.UnitPrice - saleItem.Discount) * saleItem.Quantity;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
