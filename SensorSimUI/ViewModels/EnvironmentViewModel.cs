using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using SensorSimLogic.Interfaces;
using SensorSimModel.Interfaces;

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
    
    
    // NOTE: Used by XAML binding. Do Not make private!
    public ObservableCollection<IEnvironmentDisplayModel> AvailableEnvironments { get; }
    public IEnvironmentDisplayModel ActiveEnvironment
    {
        get;
        set
        {
            if (SetField(ref field, value))
            {
                _environmentHandler.SetActiveEnvironment(value.Types);
                EnvironmentColor = _environmentHandler.GetEnvironmentColor();
                OnPropertyChanged();
                OnPropertyChanged(nameof(EnvImage));
                
            }
        }
    }
    public BitmapImage EnvImage
    {
        get
        {
            var image = new BitmapImage(new Uri(ActiveEnvironment.Image.ImagePath, UriKind.Relative));
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.Freeze();
            return image;
        }
    }
    public BitmapImage GetEnvironmentImage()
    {
        var image = new BitmapImage(new Uri(ActiveEnvironment.Image.ImagePath, UriKind.Relative));
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.Freeze();
        return image;
    }

    public EnvironmentViewModel(IEnvironmentHandler environmentHandler)
    {
        _environmentHandler = environmentHandler;
        
        var environmentTick = HelpersUi.SetupTick(TimeSpan.FromSeconds(2), OnEnvironmentTick);
        environmentTick.Start();
        
        AvailableEnvironments = new ObservableCollection<IEnvironmentDisplayModel>(
            _environmentHandler.GetAvailableEnvironments());

        ActiveEnvironment = AvailableEnvironments.First();
        EnvironmentColor = _environmentHandler.GetEnvironmentColor();
        
    }
    private void OnEnvironmentTick(object? sender, EventArgs eventArgs)
    {
        _environmentHandler.EnvUpdate();
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