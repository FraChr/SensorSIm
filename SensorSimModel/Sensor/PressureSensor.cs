using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class PressureSensor : SensorBase, ISensorLogic
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    public Func<IOcean, double> GetEnvironmentValue { get; } = ocean => ocean.Pressure;
    private string Name { get; set; } = "Pressure";
    private double Pressure { get; set; }
    public void Update(double value)
    {
        Pressure = value;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = $"{Pressure} Bar",
        };
    }
}