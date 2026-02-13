using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel;
using SensorSimModel.Environment;
using SensorSimModel.Sensor;


namespace SensorSimServices;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IOcean, Ocean>();
        services.AddSingleton<IClock, SimClock>();
        /*services.AddSingleton<IOcean, Ocean>();*/
        services.AddSingleton<ITemperature, TempSensor>();
        return services;
    }
}