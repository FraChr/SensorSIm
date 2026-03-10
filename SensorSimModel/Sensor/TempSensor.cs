using SensorSimModel.Interfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ISensor
{
    private string Id { get; } = Guid.NewGuid().ToString();
    private double Temperature { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        Temperature = environment.Temperatures;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Type = SensorTypes.Temperature,
            Name = nameof(SensorTypes.Temperature),
            Value = $"{Temperature:F2} C"
        };
    }
    
    
}
