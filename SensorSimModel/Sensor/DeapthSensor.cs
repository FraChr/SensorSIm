using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class DeapthSensor : SensorBase, ISensorLogic
{
    private string Id { get; set; } = Guid.NewGuid().ToString();   
    public double Deapth { get; set; }
    public string Name { get; set; } = "Deapth";
    public Func<IOcean, double> GetEnvironmentValue { get; } = ocean => ocean.Depth;
    public void Update(double value)
    {
        Deapth = value;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = $"{Deapth} Meters"
        };
    }

}