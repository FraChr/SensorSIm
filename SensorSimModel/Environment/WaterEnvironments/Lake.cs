using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment.WaterEnvironments;

public class Lake : Water, IWater
{
    private readonly Random _random = new();
    private const string Name = "Lake";


    public Lake()
    {
        Temperatures = 2.9;
        Pressure = 1.5;
        Depth = 2.2;
    }
    
    public IEnvironmentDisplayModel ToDisplayModel()
    {
        return new EnvironmentDisplayModel()
        {
            Name = Name
        };
    }

    public void Update()
    {
        var rand = _random.Next(0, 2);
        var temp = _random.Next(0, 2);

        if (rand != 1) return;
        
        if(temp == 0) Temperatures++;
        else Temperatures--;
    }
}