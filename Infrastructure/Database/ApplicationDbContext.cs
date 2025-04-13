using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : DatabaseContext
{
    private readonly IEnumerable<IModelConfigurator> _modelConfigurators;

    public ApplicationDbContext(DbContextOptions<DatabaseContext> options, IEnumerable<IModelConfigurator> modelConfigurators) : base(options)
    {
        _modelConfigurators = modelConfigurators;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply configurations from model configurators
        foreach (var configurator in _modelConfigurators)
            configurator.Configure(modelBuilder);
    }
}