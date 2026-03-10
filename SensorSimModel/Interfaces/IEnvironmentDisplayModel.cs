namespace SensorSimModel.Interfaces;

public interface IEnvironmentDisplayModel
{
    public EnvironmentType Type { get; set; }
    public string Name { get; set; }
}