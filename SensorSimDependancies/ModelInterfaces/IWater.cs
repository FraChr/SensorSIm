namespace SensorSimDependancies.ModelInterfaces;

public interface IWater : IEnvironment
{
    public double Depth { get; set; }
    public double Pressure { get; set; }
    
}