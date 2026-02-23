using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class SensorViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private readonly ITemperature _temperature;
    public string? TempName { get; set; }

    public SensorViewModel(ITemperature temperature)
    {
        _temperature = temperature;
        TempName = _temperature.Name;
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