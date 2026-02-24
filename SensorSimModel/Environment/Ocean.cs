using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment;

public class Ocean : Water, IOcean
{
    public double SaltLevel { get; set; }
    
    private readonly Random random = new();

    /*EnvironmentColor = "Blue";*/
    public Ocean()
    {
        Temperatures = 16.2;
        SaltLevel = 4;
        Depth = 1000;
    }

    public void Update()
    {
        var ran = random.Next(0, 2);
        var temp = random.Next(0, 2);
        if (ran != 1) return;

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