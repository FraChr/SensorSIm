using Microsoft.Extensions.DependencyInjection;
using SensorSimLogic;
using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Environment;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;
using SensorSimModel.UI.Sensor;


namespace SensorSimServices;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        /*services.AddSingleton<IOcean, Ocean>();*/
        services.AddSingleton<IClock, SimClock>();
        
        //Sensors
        services.AddSingleton<ISensorDisplayModel, SensorDisplayModel>();
        
        //Environments
        services.AddSingleton<IEnvironmentDisplayModel, EnvironmentDisplayModel>();
        
        //Handler
        services.AddSingleton<ISensorHandler, SensorHandler>();
        services.AddSingleton<IEnvironmentHandler, EnvironmentHandler>();

        services.AddSingleton<ISensorFactory, SensorFactory>();
        services.AddSingleton<IEnvironmentFactory, EnvironmentFactory>();
        
        return services;
    }
}