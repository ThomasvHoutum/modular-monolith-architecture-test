using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WarningModule.Database;
using WarningModule.Services;
using WarningModule.Services.Interfaces;

namespace WarningModule.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWarningModule(this IServiceCollection services)
    {
        return services
            .AddSingleton<IEntityConfiguration, WarningEntityConfiguration>()
            .AddScoped<IWarningService, WarningService>();
    }
}