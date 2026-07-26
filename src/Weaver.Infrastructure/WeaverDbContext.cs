using Microsoft.EntityFrameworkCore;
using Weaver.Domain.Entities;

namespace Weaver.Infrastructure;

public class WeaverDbContext : DbContext
{
    public DbSet<ComposeProject> Projects { get; init; }
    public DbSet<Tag> Tags { get; init; }
    
    public WeaverDbContext(DbContextOptions<WeaverDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeaverDbContext).Assembly);
    }
}