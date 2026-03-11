using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimUI.ViewModels;

public sealed class SensorViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private readonly ISensorHandler _sensorHandler;
    private readonly EnvironmentViewModel _environmentVm;

    public IEnumerable<ISensorDisplayModel> AvailableSensorTypes
    {
        get;
        private set => SetField(ref field, value);
    }

    private ObservableCollection<ISensorDisplayModel> _activeSensors = [];
    
    // NOTE: Used by XAML binding. Do Not make private!
    public ObservableCollection<ISensorDisplayModel> ActiveSensors
    {
        get => _activeSensors;
        private set => SetField(ref _activeSensors, value);
    }
    public SensorViewModel(ISensorHandler sensorHandler, EnvironmentViewModel environmentVm)
    {
        _sensorHandler = sensorHandler;
        _environmentVm = environmentVm;

        _environmentVm.PropertyChanged += OnEnvironmentChanged;
        
        var sensorTick = HelpersUi.SetupTick(TimeSpan.FromMilliseconds(10), OnSensorTick);
        sensorTick.Start();

        AvailableSensorTypes = _sensorHandler.GetAvailableSensors();
    }

    private void OnEnvironmentChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(EnvironmentViewModel.ActiveEnvironment)) return;
        
        RefreshAvailableSensors();

        var validTypes = AvailableSensorTypes.Select(sensor => sensor.Type);
        _sensorHandler.RemoveInvalidSensors(validTypes);

        RefreshSensors();
    }

    private void RefreshAvailableSensors()
    {
        var sensors = _sensorHandler.GetAvailableSensors();
        AvailableSensorTypes = new  ObservableCollection<ISensorDisplayModel>(sensors);
    }
    
    public void SetSensor(SensorTypes sensorTypeString, double xPosition = 0, double yPosition = 0)
    {
        var sensor = _sensorHandler.CreateSensor(sensorTypeString);

        var displayModel = sensor.ToDisplayModel();
        displayModel.XPosition = xPosition;
        displayModel.YPosition = yPosition;
        
        _activeSensors.Add(displayModel);
    }
    
    private void OnSensorTick(object? sender, EventArgs eventArgs)
    {
        if (sender is null) return;
        RefreshSensors();
    }
    
    private void RefreshSensors()
    {
        var positions = ActiveSensors
            .ToDictionary(sensor => sensor.Id, sensor => (sensor.XPosition, sensor.YPosition));

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