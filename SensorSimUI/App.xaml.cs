using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SensorSimDependancies.LogicInterfaces;
using SensorSimServices;
using SensorSimUI.ViewModels;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = AddUiServices();
        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private IServiceCollection AddUiServices()
    {
        var services = new ServiceCollection();
        services.AddAppServices();
        services.AddSingleton<SensorReadingsViewModel>();
        services.AddSingleton<EnvironmentViewModel>();
        services.AddSingleton<SensorViewModel>();
        services.AddSingleton<ClockViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}