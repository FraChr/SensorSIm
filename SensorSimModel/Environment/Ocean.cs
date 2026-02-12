using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment;

public class Ocean : Water, IOcean
{
    public double SaltLevel { get; set; }
    
    public Ocean()
    {
        EnvrionmentColor = "Blue";
        Temperatures = 0;
        SaltLevel = 0;
        Deapth = 0;
    }
}