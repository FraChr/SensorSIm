using System.Windows;
using System.Windows.Threading;
using SensorSimDependancies;
using SensorSimDependancies.ModelInterfaces;
using SensorSimLogic;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _displayTimer = new();
    
    public MainWindow(IClock clock)
    {
        InitializeComponent();

        var sim = new SimTime();
        _displayTimer.Interval = TimeSpan.FromMilliseconds(10);
        _displayTimer.Tick += (sender, eventArgs) =>
        {
            Timer.Text = sim.GetTime().ToString(@"hh\:mm\:ss");
        };
        _displayTimer.Start();
    }
}