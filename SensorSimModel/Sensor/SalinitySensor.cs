using SensorSimModel.Interfaces;

namespace SensorSimModel.Sensor;

public class SalinitySensor : SensorBase, ISensor
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    private string Name { get; set; } = "Salinity";
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
            Name = Name,
            Value = Salinity.HasValue
            ? $"{Salinity.Value} Saltiness"
            : "N/A"
        };
    }
}