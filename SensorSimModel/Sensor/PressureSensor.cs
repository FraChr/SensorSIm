using SensorSimModel.Interfaces;
using SensorSimModel.UI.Sensor;

namespace SensorSimModel.Sensor;

public class PressureSensor : SensorBase, ISensor
{
    public ImageModel SensorImage { get; set; }
    private string Id { get; } = Guid.NewGuid().ToString();
    private double? Pressure { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IWater waterEnvironment)
            Pressure = waterEnvironment.Pressure;
        else
            Pressure = null;
    }

    public void UpdateValue(ISensorDisplayModel display)
    {
        display.Value = Pressure.HasValue
            ? $"{Pressure.Value:F2} Bar"
            : "N/A";
    }


    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Type = SensorTypes.Pressure,
            Name = nameof(SensorTypes.Pressure),
            Value = Pressure.HasValue
            ? $"{Pressure.Value:F2} Bar"
            : "N/A"
        };
    }
}