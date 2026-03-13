namespace SensorSimModel.Interfaces;

public interface IEnvironmentDisplayModel
{
    public EnvironmentTypes Types { get; set; }
    public string Name { get; set; }
    public ImageModel Image { get; set; }
}