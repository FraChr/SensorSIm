using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class DeapthSensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();   
    public double Depth { get; set; }
    public string Name { get; set; } = "Depth";
    public Func<IEnvironment, double> GetEnvironmentValue { get; } = env => env.Depth;
        /*= ocean => ocean.Depth;*/
    public void Update(double value)
    {
        Depth = value;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = $"{Depth} Meters"
        };
    }

}