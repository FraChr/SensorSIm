using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment.DesertEnvironments;

public class SandDesert : Desert, IWater
{
    private readonly Random random = new();
    public double Depth { get; set; }
    public double Pressure { get; set; }

    public SandDesert()
    {
        Temperatures = 40.5;
        Pressure = 0.5;
    }
    
    public IEnvironmentDisplayModel ToDisplayModel()
    {
        return new EnvironmentDisplayModel()
        {
            Name = "SandDesert",
        };
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
}