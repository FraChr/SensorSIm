using SensorSimModel.Interfaces;

namespace SensorSimModel.Sensor;

public class PressureSensor : SensorBase, ISensor
{
    private string Id { get; } = Guid.NewGuid().ToString();
    private double? Pressure { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IWater waterEnvironment)
            Pressure = waterEnvironment.Pressure;
        else
            Pressure = null;
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