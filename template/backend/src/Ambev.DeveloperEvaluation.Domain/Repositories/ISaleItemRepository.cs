using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task AddAsync(SaleItem saleItem);
    Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId);
    Task ApplyBusinessRulesAsync(SaleItem saleItem);
}
