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
            
            // Register features to create initial database
            services.AddTransient<IModelConfigurator, UserModelConfigurator>();
            
            // Hate having to register the features here, because it creates a reference to the feature's project for every feature that will be used.
            
            using var serviceProvider = services.BuildServiceProvider();
            var configurators = serviceProvider.GetServices<IModelConfigurator>();

            return new ApplicationDbContext(optionsBuilder.Options, configurators);
        }
    }
}