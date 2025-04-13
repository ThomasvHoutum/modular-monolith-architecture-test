using Core.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    private readonly IEnumerable<IModule> _modules;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IEnumerable<IModule> modules)
        : base(options)
    {
        _modules = modules;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var module in _modules)
            module.ConfigureDatabase(modelBuilder);
    }
}