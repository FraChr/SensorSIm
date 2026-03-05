using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class PressureSensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    private string Name { get; set; } = "Pressure";
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
            Name = Name,
            Value = Pressure.HasValue
            ? $"{Pressure.Value:F2} Bar"
            : "N/A"
        };
    }
}