using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment;

public class Ocean : Water, IOcean
{
    public double SaltLevel { get; set; }
    
    /*EnvironmentColor = "Blue";*/
    public Ocean()
    {
        Temperatures = 0;
        SaltLevel = 0;
        Depth = 0;
    }
}