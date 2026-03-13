using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SensorSimModel;
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


        /*var image = _mainVm.EnvironmentVm.GetEnvironmentImage();
        img.Source = image;*/


    }

    private void SensorDrag(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed)
            return;
        
        if (sender is FrameworkElement element && element.DataContext is ISensorDisplayModel sensor)
        {
            DragDrop.DoDragDrop(element, sensor.Type, DragDropEffects.Copy);
        }
    }

    private void Environment_Drop(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(SensorTypes))) return;
        
        var sensorTypes = (SensorTypes)e.Data.GetData(typeof(SensorTypes));

        Point dropPos = e.GetPosition(dropCanvas);
        _mainVm.SensorVm.SetSensor(sensorTypes, dropPos.X, dropPos.Y);
    }
}