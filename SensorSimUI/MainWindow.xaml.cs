using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimUI.ViewModels;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _displayTimer = new();
    private readonly DispatcherTimer _sensorTick = new();
    private readonly DispatcherTimer _environmentTick = new();

    private readonly ClockViewModel _clockVm;
    private readonly IClock _clock;
    private readonly MainViewModel _mainVm;
    
    public MainWindow(MainViewModel mainVm, IClock clock)
    {
        InitializeComponent();
        DataContext = mainVm;
        
        _mainVm = mainVm;
        
        _clockVm = mainVm.ClockVm;
        _clock = clock;
        
        SetupDisplayTimer();
        StartTimer();
        
        
        SetupSensorTick();
        _sensorTick.Start();
        
        SetupEnvironmentTick();
        _environmentTick.Start();
    }

    private void SetupEnvironmentTick()
    {
        _environmentTick.Interval = TimeSpan.FromSeconds(2);
        _environmentTick.Tick += OnEnvironmentTick;
    }

    private void OnEnvironmentTick(object? sender, EventArgs eventArgs)
    {
        _mainVm.EnvironmentVm.Run();
    }
    private void SetupSensorTick()
    {
        _sensorTick.Interval = TimeSpan.FromSeconds(1);
        _sensorTick.Tick += OnSensorTick;
    }
    private void OnSensorTick(object? sender, EventArgs eventArgs)
    {
        if (sender is null) return;
        _mainVm.SensorVm.RefreshSensors();
    }
    
    private void SetupDisplayTimer()
    {
        _displayTimer.Interval = TimeSpan.FromMilliseconds(10);
        _displayTimer.Tick += OnDisplayTick;
    }

    private void StartTimer()
    {
        _clock.StartStopwatch();
        _displayTimer.Start();
    }
    
    private void OnDisplayTick(object? sender, EventArgs e)
    {
        _clockVm.TimeView = _clock.GetElapsedTime().ToString(@"hh\:mm\:ss");
        /*_mainVm.SensorVm.RefreshSensors();*/
    }


    private void SensorDrag(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;
        
        if (sender is FrameworkElement element && element.DataContext is ISensorDisplayModel sensor)
        {
            DragDrop.DoDragDrop(element, sensor.Id, DragDropEffects.Copy);
        }
    }

    private void Environment_Drop(object sender, DragEventArgs e)
    {
        
        if(!e.Data.GetDataPresent(typeof(string))) return;
        
        var sensorId = e.Data.GetData(typeof(string)) as string;
        if (sensorId is null) return;

        Point dropPos = e.GetPosition(dropCanvas);
        
        _mainVm.SensorVm.SetSensor(sensorId, dropPos.X, dropPos.Y);
        
    }
}