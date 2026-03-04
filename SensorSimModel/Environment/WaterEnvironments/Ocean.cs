using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment.WaterEnvironments;

public class Ocean : Water, IOcean
{
    public double Salinity { get; set; }
    
    private readonly Random random = new();

    /*EnvironmentColor = "Blue";*/
    public Ocean()
    {
        Temperatures = 16.2;
        Pressure = 1.2;
        Salinity = 4;
        Depth = 1000;
    }

    public void Update()
    {
        var rand = random.Next(0, 2);
        var temp = random.Next(0, 2);
        var pressure = random.Next(0, 2);
        if (rand != 1) return;

        if (temp == 0)
        {
            Temperatures++;
        }
        else
        {
            Temperatures--;
        }
    }

    public IEnvironmentDisplayModel ToDisplayModel()
    {
        return new EnvironmentDisplayModel()
        {
            Name = "Ocean",
        };
    }
}