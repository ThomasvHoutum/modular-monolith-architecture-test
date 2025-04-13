using Core.Models;
using Core.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WarningModule.Database;
using WarningModule.Services;
using WarningModule.Services.Interfaces;

namespace WarningModule;

public class ModuleActivator : IModule
{
    public string Name => "WarningModule";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IWarningService, WarningService>();
    }

    public void ConfigureCommands(string commands)
    {
        // TODO: Register discord command here
        throw new NotImplementedException();
    }

    public void ConfigureDatabase(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new WarningModelConfiguration());
}