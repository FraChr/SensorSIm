using SensorSimModel.Interfaces;
using SensorSimModel.UI.Sensor;

namespace SensorSimModel.Sensor;

public class DeapthSensor : SensorBase, ISensor
{ 
    public ImageModel SensorImage { get; set; }
    private string Id { get; } = Guid.NewGuid().ToString();   
    private double? Depth { get; set; }
    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IWater waterEnvironment)
            Depth = waterEnvironment.Depth;
        else
            Depth = null;
    }

    public void UpdateValue(ISensorDisplayModel display)
    {
        display.Value = Depth.HasValue
            ? $"{Depth.Value:F2} Meters"
            : "N/A";
    }


    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Type = SensorTypes.Depth,
            Name = nameof(SensorTypes.Depth),
            Value = Depth.HasValue
            ? $"{Depth.Value:F2} Meters"
            : "N/A"
        };
    }

}