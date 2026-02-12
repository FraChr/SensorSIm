using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SensorSimServices;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = AddViewServices();
        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private IServiceCollection AddViewServices()
    {
        var services = new ServiceCollection();
        services.AddAppServices();
        services.AddSingleton<SensorViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}