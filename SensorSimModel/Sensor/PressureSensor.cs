using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class PressureSensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    public Func<IEnvironment, double> GetEnvironmentValue { get; } = env => env.Pressure;
        /*= ocean => ocean.Pressure;*/
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