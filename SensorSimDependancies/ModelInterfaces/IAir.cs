namespace SensorSimDependancies.ModelInterfaces;

public interface IAir : IEnvironment
{
    public double WindSpeed { get; set; }
}