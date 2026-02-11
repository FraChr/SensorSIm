using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies;
using SensorSimDependancies.ModelInterfaces;
using SensorSimServices;

namespace SensorSimTests;

public class MainWindowTest
{
    
    [Fact]
    public void TestClock()
    {
        var services = new ServiceCollection();
        services.AddAppServices();
        
        var serviceProvider = services.BuildServiceProvider();
        var clock = serviceProvider.GetService<IClock>();
        
        Assert.True(clock != null && clock.StartStopwatch().IsRunning);
    }
}