using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task AddAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
    Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);
    Task UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
    Task DeleteAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
    Task ApplyBusinessRulesAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
}
