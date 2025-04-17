using Infrastructure.Database;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WarningModule.Database;

namespace API;

public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Get environment
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        // Get configuration
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite(
            config.GetConnectionString("DefaultConnection"),
            options =>
            {
                options.MigrationsAssembly(typeof(ApplicationDbContextDesignFactory).Assembly.FullName);
            });

        // TODO: I don't like having to declare the modules here as well as in the startup
        var modules = new List<IEntityConfiguration>
        {
            new WarningEntityConfiguration()
        };
        
        return new ApplicationDbContext(optionsBuilder.Options, modules);
    }
}