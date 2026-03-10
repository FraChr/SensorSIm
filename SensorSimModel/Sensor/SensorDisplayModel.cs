using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimModel.Interfaces;

namespace SensorSimModel.Sensor;

public sealed class SensorDisplayModel : ISensorDisplayModel, INotifyPropertyChanged
{
    public SensorTypes Type { get; set; }
    public string Id { get; }
    public string Name { get; set; }

    public string Value
    {
        get;
        set => SetField(ref field, value);
    }

    public double XPosition { get; set; }
    public double YPosition { get; set; }


    public SensorDisplayModel(string id)
    {
        Id = id;
    }
    
    
    public event PropertyChangedEventHandler? PropertyChanged;

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