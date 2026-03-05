using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class EnvironmentViewModel :  INotifyPropertyChanged
{

    private readonly DispatcherTimer _environmentTick = new();
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private IEnvironmentHandler _environmentHandler;
    private string _environmentColor;
    public string EnvironmentColor { 
        get => _environmentColor; 
        set => SetField(ref _environmentColor, value);
    }
    public IEnumerable<IEnvironmentDisplayModel> AvailableEnvironments { get; set; }
    private IEnvironmentDisplayModel _activeEnvironment;

    public IEnvironmentDisplayModel ActiveEnvironment
    {
        get => _activeEnvironment;
        set
        {
            if (SetField(ref _activeEnvironment, value))
            {
                _environmentHandler.SetActiveEnvironment(value.Name);
                EnvironmentColor = _environmentHandler.GetEnvironmentColor();
            }
        }
    }
    
    public EnvironmentViewModel(IEnvironmentHandler environmentHandler)
    {
        _environmentHandler = environmentHandler;
        
        _environmentTick = HelpersUi.SetupTick(TimeSpan.FromSeconds(2), OnEnvironmentTick);
        _environmentTick.Start();
        
        AvailableEnvironments = _environmentHandler.GetAvailableEnvironments();

        ActiveEnvironment = AvailableEnvironments.First();
        EnvironmentColor = _environmentHandler.GetEnvironmentColor();
        
    }
    private void OnEnvironmentTick(object? sender, EventArgs eventArgs)
    {
        Refresh();
    }

    private void Refresh()
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