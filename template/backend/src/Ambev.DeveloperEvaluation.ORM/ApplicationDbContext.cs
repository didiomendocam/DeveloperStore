using Ambev.DeveloperEvaluation.Domain.Branchs;
using Ambev.DeveloperEvaluation.ORM.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM;

public class ApplicationDbContext : DbContext
{
    public DbSet<Branch> Branches { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BranchMapping());
    }
} 