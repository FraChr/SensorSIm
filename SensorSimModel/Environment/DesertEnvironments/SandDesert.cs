using Resources;
using SensorSimModel.Interfaces;

namespace SensorSimModel.Environment.DesertEnvironments;

public class SandDesert : Desert, IAir
{
    public ImageModel Image { get; set; } = new(EnvironmentImagePaths.DesertBackground);
    
    private readonly Random _random = new();
    public double WindSpeed { get; set; }
    
    public SandDesert()
    {
        Temperatures = 40.5;
        WindSpeed = 0.2;
    }
    
    public IEnvironmentDisplayModel ToDisplayModel()
    {
        return new EnvironmentDisplayModel()
        {
            Types = EnvironmentTypes.SandDesert,
            Name = nameof(EnvironmentTypes.SandDesert),
            Image = Image
        };
    }

    public void Update()
    {
        var rand = _random.Next(0, 2);
        var temp = _random.Next(0, 2);
        var pressure = _random.Next(0, 2);
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