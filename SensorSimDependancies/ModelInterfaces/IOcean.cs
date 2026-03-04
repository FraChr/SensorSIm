namespace SensorSimDependancies.ModelInterfaces;

public interface IOcean : IWater
{
    public double Salinity { get; set; }
}