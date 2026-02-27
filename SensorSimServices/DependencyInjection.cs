using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimLogic;
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
        
        //Sensors
        services.AddSingleton<ITemperature, TempSensor>();
        services.AddSingleton<ISensorLogic, TempSensor>();
        services.AddSingleton<ISensorDisplayModel, SensorDisplayModel>();
        
        //Handler
        services.AddSingleton<ISensorHandler, SensorHandler>();

        services.AddSingleton<ISensorFactory, SensorFactory>();
        
        services.AddSingleton<IMainLogic, MainLogic>();
        return services;
    }
}