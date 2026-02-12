using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies.LogicInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;

public class MainLogic : IMainLogic
{
    public void Init()
    {
        var services = new ServiceCollection();
        
        var serviceProvider = services.BuildServiceProvider();
        
    }
}