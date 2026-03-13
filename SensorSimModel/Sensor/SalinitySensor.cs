using SensorSimModel.Interfaces;
using SensorSimModel.UI.Sensor;

namespace SensorSimModel.Sensor;

public class SalinitySensor : SensorBase, ISensor
{
    public ImageModel SensorImage { get; set; }
    private string Id { get; } = Guid.NewGuid().ToString();
    private double? Salinity { get; set; }

    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IOcean oceanEnvironment)
            Salinity = oceanEnvironment.Salinity;
        else 
            Salinity = null;
    }

    public void UpdateValue(ISensorDisplayModel display)
    {
        display.Value = Salinity.HasValue
            ? $"{Salinity.Value} Saltiness"
            : "N/A";
    }


    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel(Id)
        {
            Type = SensorTypes.Salinity,
            Name = nameof(SensorTypes.Salinity),
            Value = Salinity.HasValue
            ? $"{Salinity.Value} Saltiness"
            : "N/A"
        };
    }
}