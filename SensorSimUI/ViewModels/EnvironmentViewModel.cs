using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class EnvironmentViewModel :  INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private IEnvironmentHandler _environmentHandler;
    public string EnvironmentColor { get; set; }
    private readonly IEnvironmentFactory _environmentFactory;

    public IEnumerable<IEnvironmentDisplayModel> AvailableEnvironments { get; set; }
    
    
    public EnvironmentViewModel(IEnvironmentHandler environmentHandler, IEnvironmentFactory environmentFactory)
    {
        _environmentHandler = environmentHandler;
        _environmentFactory = environmentFactory;
        EnvironmentColor = _environmentHandler.GetEnvironmentColor();
        
        AvailableEnvironments = _environmentFactory.GetAvailableEnvironments();
    }

    public void Run()
    {
        _environmentHandler.Update();
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