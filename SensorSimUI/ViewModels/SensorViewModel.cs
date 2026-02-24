using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.LogicInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimUI.ViewModels;

public sealed class SensorViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private ISensorHandler ? _sensorHandler;
    
    private readonly ITemperature _temperature;
    public string? TempName { get; set; }
    
    private List<ISensorDisplayModel> _sensors;
    public List<ISensorDisplayModel> Sensors
    {
        get => _sensors;
        private set => SetField(ref _sensors, value);
    }
    
    public SensorViewModel(ITemperature temperature, ISensorHandler sensorHandler)
    {
        _sensorHandler = sensorHandler;
        /*RefreshSensors();*/
        _temperature = temperature;
        TempName = _temperature.Name;
    }

    public void RefreshSensors()
    {
        if (_sensorHandler != null) Sensors = _sensorHandler.RefreshAll();
    }

    public void SetSensor()
    {
        // sensor handler in logic to make a new sensor, log it, keep track!!
        _sensorHandler.CreateSensor();
        RefreshSensors();
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