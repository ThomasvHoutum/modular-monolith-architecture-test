using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using UserFeature.Database;

namespace Infrastructure.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=database.db";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            var services = new ServiceCollection();
            // Register the Warning feature configurator (and others if needed).
            services.AddTransient<IModelConfigurator, UserModelConfigurator>();

            // Build a temporary provider and get all the IModelConfigurator implementations.
            using var serviceProvider = services.BuildServiceProvider();
            var configurators = serviceProvider.GetServices<IModelConfigurator>();

            return new ApplicationDbContext(optionsBuilder.Options, configurators);
        }
    }
}