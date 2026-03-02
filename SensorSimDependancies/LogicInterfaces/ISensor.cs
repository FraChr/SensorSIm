namespace SensorSimDependancies.LogicInterfaces;

public interface ISensor
{
    public string Name { get; set; }
    public DateTime TimeStamp { get; set; }
}