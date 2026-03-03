using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    public Func<IEnvironment, double> GetEnvironmentValue { get; } = Environment => Environment.Temperatures;
    public string Name { get; set; } = "Temperature";
    public double Temperature { get; set; }
    
    public void Update(double value)
    {
        Temperature = value;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = $"{Temperature} C"
        };
   }
}
