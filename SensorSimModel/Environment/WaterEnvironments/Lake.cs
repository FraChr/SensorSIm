using SensorSimModel.Interfaces;

namespace SensorSimModel.Environment.WaterEnvironments;

public class Lake : Water, IWater
{
    public ImageModel Image { get; set; } = new ImageModel("Assets/Images/Environment/Lake.png");
    
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
            Types = EnvironmentTypes.Lake,
            Name = nameof(EnvironmentTypes.Lake),
            Image = Image
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