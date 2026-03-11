using SensorSimModel.Interfaces;
using SensorSimModel.UI.Sensor;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ISensor
{
    private string Id { get; } = Guid.NewGuid().ToString();
    private double Temperature { get; set; }

    public void UpdateFromEnvironment(IEnvironment environment)
    {
        Temperature = environment.Temperatures;
    }

    public void UpdateValue(ISensorDisplayModel display)
    {
        display.Value = $"{Temperature:F2} C";
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
