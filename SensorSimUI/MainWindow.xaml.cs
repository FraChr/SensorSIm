using System.Windows;
using System.Windows.Input;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel _mainVm;
    
    public MainWindow(MainViewModel mainVm)
    {
        InitializeComponent();
        DataContext = mainVm;
        
        _mainVm = mainVm;
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