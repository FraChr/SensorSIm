using SensorSimModel.Interfaces;

namespace SensorSimModel.Sensor;

public class SalinitySensor : SensorBase, ISensor
{
    private string Id { get; } = Guid.NewGuid().ToString();
    private double? Salinity { get; set; }

    public void UpdateFromEnvironment(IEnvironment environment)
    {
        if (environment is IOcean oceanEnvironment)
            Salinity = oceanEnvironment.Salinity;
        else 
            Salinity = null;
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