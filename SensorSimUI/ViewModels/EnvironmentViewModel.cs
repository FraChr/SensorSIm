using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SensorSimDependancies.LogicInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class EnvironmentViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IEnvironmentHandler _environmentHandler;

    public string EnvironmentColor
    {
        get;
        set => SetField(ref field, value);
    }

    public ObservableCollection<IEnvironmentDisplayModel> AvailableEnvironments { get; }
    public IEnvironmentDisplayModel ActiveEnvironment
    {
        get;
        set
        {
            if (SetField(ref field, value))
            {
                _environmentHandler.SetActiveEnvironment(value.Name);
                EnvironmentColor = _environmentHandler.GetEnvironmentColor();
            }
        }
    }

    public EnvironmentViewModel(IEnvironmentHandler environmentHandler)
    {
        _environmentHandler = environmentHandler;
        
        var environmentTick = HelpersUi.SetupTick(TimeSpan.FromSeconds(2), OnEnvironmentTick);
        environmentTick.Start();
        
        /*AvailableEnvironments = _environmentHandler.GetAvailableEnvironments();*/
        
        AvailableEnvironments = new ObservableCollection<IEnvironmentDisplayModel>(
            _environmentHandler.GetAvailableEnvironments());

        ActiveEnvironment = AvailableEnvironments.First();
        EnvironmentColor = _environmentHandler.GetEnvironmentColor();
        
    }
    private void OnEnvironmentTick(object? sender, EventArgs eventArgs)
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