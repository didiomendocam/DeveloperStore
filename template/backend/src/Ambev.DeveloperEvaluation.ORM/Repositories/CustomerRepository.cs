using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbContext _context;

    public CustomerRepository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Set<Customer>().AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Customer>().FindAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Set<Customer>().ToListAsync();
    }
}
