using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ITemperature, ISensorLogic
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    public string SensorType => "Temperature";

    public Func<IOcean, double> GetEnvironmentValue { get; } = ocean => ocean.Temperatures;
    public string Name { get; set; } = "TempSensor";
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
