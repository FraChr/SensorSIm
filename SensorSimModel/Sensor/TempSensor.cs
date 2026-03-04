using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    private string Name { get; set; } = "Temperature";
    private double Temperature { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        Temperature = environment.Temperatures;
    }
    
    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Name = Name,
            Value = $"{Temperature:F2} C"
        };
   }
}
