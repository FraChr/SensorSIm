using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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


    private void Sensor1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;

        if (sender is FrameworkElement element && element.DataContext is SensorViewModel sensor)
        {
            DragDrop.DoDragDrop(element, sensor, DragDropEffects.Copy);
        }
    }

    private void Environment_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(SensorViewModel)))
        {
            var sensor = e.Data.GetData(typeof(SensorViewModel)) as SensorViewModel;

            TextBlock tb = new TextBlock();
            tb.Text = sensor.TempName;

            Point dropPos = e.GetPosition(dropCanvas);

            Canvas.SetLeft(tb, dropPos.X);
            Canvas.SetTop(tb, dropPos.Y);
            
            dropCanvas.Children.Add(tb);
        }
    }
}