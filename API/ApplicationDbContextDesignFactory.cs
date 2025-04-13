using Core.Modules;
using Core.Modules.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API
{
    public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var modules = new List<IModule>();

            // TODO: Do this dynamically
            if (ActiveModuleList.GetActiveModules().Contains("WarningModule"))
                modules.Add(new WarningModule.ModuleActivator());
            
            Console.WriteLine($"Found {modules.Count} modules.");
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Data Source=database.db", 
                options =>
            {
                options.MigrationsAssembly(typeof(ApplicationDbContextDesignFactory).Assembly.FullName);
            });

            return new ApplicationDbContext(optionsBuilder.Options, modules);
        }
    }
}