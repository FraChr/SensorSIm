namespace SensorSimModel.Interfaces;

public interface ISensorDisplayModel
{
    ImageModel SensorImage { get; set; }
    public SensorTypes Type { get; set; }
    public string Id { get; }
    string Name { get; set; }
    string Value { get; set; }

    public double XPosition { get; set; }
    public double YPosition { get; set; }
}