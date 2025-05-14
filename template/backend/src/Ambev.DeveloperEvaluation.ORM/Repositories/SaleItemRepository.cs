using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly DbContext _context;

    public SaleItemRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(SaleItem saleItem)
    {
        await _context.Set<SaleItem>().AddAsync(saleItem);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId)
    {
        return await _context.Set<SaleItem>()
            .Where(item => item.SaleId == saleId)
            .ToListAsync();
    }

    public async Task ApplyBusinessRulesAsync(SaleItem saleItem)
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
        await _context.SaveChangesAsync();
    }
}
