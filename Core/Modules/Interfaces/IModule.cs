using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Modules.Interfaces;

public interface IModule
{
    string Name { get; }

    /// <summary>
    /// Register services specific to this module.
    /// </summary>
    void ConfigureServices(IServiceCollection services);

    /// <summary>
    /// Register module-specific commands for the Discord bot.
    /// </summary>
    void ConfigureCommands(string commands);

    /// <summary>
    /// Apply entity configurations to the EF Core model.
    /// </summary>
    void ConfigureDatabase(ModelBuilder modelBuilder);
}
