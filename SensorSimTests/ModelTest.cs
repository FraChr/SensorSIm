using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies.ModelInterfaces;
using SensorSimServices;

namespace SensorSimTests;

public class ModelTest
{
    [Fact]
    public void EnvironmentTest()
    {
        var services = new ServiceCollection();
        services.AddAppServices();
        
        var serviceProvider = services.BuildServiceProvider();
        var ocean = serviceProvider.GetService<IOcean>();
        
        Assert.NotNull(ocean.EnvironmentColor);
        Assert.NotNull(ocean.Depth);
        Assert.NotNull(ocean.SaltLevel);
        Assert.NotNull(ocean.Temperatures);
    }
}