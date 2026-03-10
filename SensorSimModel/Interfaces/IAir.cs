namespace SensorSimModel.Interfaces;

public interface IAir : IEnvironment
{
    public double WindSpeed { get; set; }
}