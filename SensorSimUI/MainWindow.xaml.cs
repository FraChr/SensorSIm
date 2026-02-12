using System.Windows;
using System.Windows.Threading;
using SensorSimDependancies.LogicInterfaces;
using SensorSimModel;
using SensorSimModel.Sensor;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _displayTimer = new();
    
    public MainWindow(MainViewModel mainVm)
    {
        InitializeComponent();
        DataContext = mainVm;

        var clock = new SimClock();
        
        _displayTimer.Interval = TimeSpan.FromMilliseconds(10);
        _displayTimer.Tick += (sender, eventArgs) =>
        {
            Timer.Text = clock.GetElapsedTime().ToString(@"hh\:mm\:ss");
        };
        clock.StartStopwatch();
        _displayTimer.Start();
    }
}