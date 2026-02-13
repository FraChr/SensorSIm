using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class EnvironmentViewModel :  INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private IOcean _ocean;
    public string EnvironmentColor { get; set; }

    public EnvironmentViewModel(IOcean ocean)
    {
        _ocean = ocean;
        EnvironmentColor = _ocean.EnvironmentColor;
        
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