namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorDisplayModel
{
    public  string Id { get; }
    string Name { get; set; }
    string Value { get; set; }

    public double XPosition { get; set; }
    public double YPosition { get; set; }
}