using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API;

public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=database.db", 
            options =>
            {
                options.MigrationsAssembly(typeof(ApplicationDbContextDesignFactory).Assembly.FullName);
            });

        return new ApplicationDbContext(optionsBuilder.Options, ActiveModuleList.Modules);
    }
}