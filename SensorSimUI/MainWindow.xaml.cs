using System.Windows;
using System.Windows.Threading;
using SensorSimDependancies.ModelInterfaces;
using SensorSimUI.ViewModels;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _displayTimer = new();

    private readonly ClockViewModel _clockVm;
    private readonly IClock _clock;
    
    public MainWindow(MainViewModel mainVm, IClock clock)
    {
        InitializeComponent();
        DataContext = mainVm;
        
        _clockVm = mainVm.ClockVm;
        _clock = clock;
        
        SetupDisplayTimer();
        StartTimer();
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
    }
}