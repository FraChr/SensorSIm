using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class SensorViewModel : INotifyPropertyChanged
{
    private readonly DispatcherTimer _sensorTick = new();
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private readonly ISensorHandler? _sensorHandler;
    public IEnumerable<ISensorDisplayModel> AvailableSensorTypes { get; }

    private ObservableCollection<ISensorDisplayModel> _activeSensors = new();
    public ObservableCollection<ISensorDisplayModel> ActiveSensors
    {
        get => _activeSensors;
        private set => SetField(ref _activeSensors, value);
    }

    public SensorViewModel(ISensorHandler sensorHandler)
    {
        _sensorHandler = sensorHandler;
        
        _sensorTick = HelpersUi.SetupTick(TimeSpan.FromMilliseconds(10), OnSensorTick);
        _sensorTick.Start();

        AvailableSensorTypes = _sensorHandler.GetAvailableSensors();
    }
    private void OnSensorTick(object? sender, EventArgs eventArgs)
    {
        if (sender is null) return;
        RefreshSensors();
    }
    
    private void RefreshSensors()
    {
        if(_sensorHandler == null) return;

        var positions = ActiveSensors
            .ToDictionary(s => s.Id, s => (s.XPosition, s.YPosition));

        var latestSensor = _sensorHandler.RefreshAll();

        foreach (var sensor in latestSensor)
        {
            if (positions.TryGetValue(sensor.Id, out var pos))
            {
                sensor.XPosition = pos.XPosition;
                sensor.YPosition = pos.YPosition;
            }
        }
        ActiveSensors = new ObservableCollection<ISensorDisplayModel>(latestSensor);
    }

    public void SetSensor(string sensorType, double xPosition = 0, double yPosition = 0)
    {
        var sensor = _sensorHandler.CreateSensor(sensorType);

        var displayModel = sensor.ToDisplayModel();
        displayModel.XPosition = xPosition;
        displayModel.YPosition = yPosition;
        
        _activeSensors.Add(displayModel);
    }
    
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    
 
    
}