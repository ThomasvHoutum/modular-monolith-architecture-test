using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    private readonly IEnumerable<IEntityConfiguration> _configurations;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IEnumerable<IEntityConfiguration> configurations)
        : base(options)
    {
        _configurations = configurations;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var configuration in _configurations)
            configuration.Configure(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }
}