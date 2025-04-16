using Microsoft.Extensions.DependencyInjection;
using WarningModule.Services;
using WarningModule.Services.Interfaces;

namespace WarningModule.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWarningModule(this IServiceCollection services)
    {
        return services.AddScoped<IWarningService, WarningService>();
    }
}