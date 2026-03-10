using System.Windows;
using System.Windows.Input;
using SensorSimModel.Interfaces;

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
            DragDrop.DoDragDrop(element, sensor.Name, DragDropEffects.Copy);
        }
    }

    private void Environment_Drop(object sender, DragEventArgs e)
    {
        
        if(!e.Data.GetDataPresent(typeof(string))) return;
        
        var sensorType = e.Data.GetData(typeof(string)) as string;
        if(sensorType == null) return;
        
        Point dropPos = e.GetPosition(dropCanvas);
        
        _mainVm.SensorVm.SetSensor(sensorType, dropPos.X, dropPos.Y);
        
        
    }
}