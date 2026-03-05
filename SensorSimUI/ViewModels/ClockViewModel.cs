using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimUI.ViewModels;

public sealed class ClockViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly DispatcherTimer _displayTimer;
    private readonly IClock _clock;
    public string TimeView
    {
        get;
        set => SetField(ref field, value);
    }
    
    public ClockViewModel(IClock clock)
    {
        _clock = clock;
        _displayTimer = HelpersUi.SetupTick(TimeSpan.FromMilliseconds(10), OnDisplayTick);
        StartDisplayTimer();
    }

    private void StartDisplayTimer()
    {
        _clock.StartStopwatch();
        _displayTimer.Start();
    }
    
    private void OnDisplayTick(object? sender, EventArgs e)
    {
        TimeView = _clock.GetElapsedTime().ToString(@"hh\:mm\:ss");
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