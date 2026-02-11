using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel;

namespace SensorSimServices;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IClock, SimClock>();
        return services;
    }
}