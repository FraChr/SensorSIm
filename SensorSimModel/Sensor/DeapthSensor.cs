using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class DeapthSensor : SensorBase, ISensor
{
    private Func<IEnvironment, double> _getEnvironmentValue;
    private string Id { get; set; } = Guid.NewGuid().ToString();   
    private string Name { get; set; } = "Depth";
    private double? Depth { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IWater waterEnvironment)
            Depth = waterEnvironment.Depth;
        else
            Depth = null;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = Depth.HasValue
            ? $"{Depth.Value:F2} Meters"
            : "N/A"
        };
    }

}