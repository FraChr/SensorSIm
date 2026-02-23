namespace SensorSimDependancies.LogicInterfaces;

public interface ITemperature : ISensor
{
    public double Temperature { get; set; }
    public string Name { get; set; }
}