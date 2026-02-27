using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimModel.Sensor;

public class SensorDisplayModel : ISensorDisplayModel, INotifyPropertyChanged
{
    public string Id { get; }
    public string Name { get; set; }
    
    private string _value;

    public string Value
    {
        get => _value;
        set => SetField(ref _value, value);
    }
    
    public double XPosition { get; set; }
    public double YPosition { get; set; }


    public SensorDisplayModel(string id)
    {
        Id = id;
    }
    
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}