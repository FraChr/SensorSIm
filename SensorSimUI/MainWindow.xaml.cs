using System.Windows;
using System.Windows.Threading;
using SensorSimDependancies;
using SensorSimLogic;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DispatcherTimer _displayTimer = new();
    private readonly IClock _clock;
    
    public MainWindow(IClock clock)
    {
        InitializeComponent();
        /*_clock = clock;*/

        var sim = new SimTime();
        _displayTimer.Interval = TimeSpan.FromMilliseconds(10);
        _displayTimer.Tick += (s, e) =>
        {
            Timer.Text = sim.hh().ToString(@"hh\:mm\:ss");
        };
        _displayTimer.Start();
        
    }
}