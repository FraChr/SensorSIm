using Resources;
using SensorSimModel.Helpers;
using SensorSimModel.Interfaces;

namespace SensorSimModel.Environment.WaterEnvironments;

public class Ocean : Water, IOcean
{
    public ImageModel Image { get; set; } = new(EnvironmentImagePaths.OceanBackground);
    public double Salinity { get; set; }
    public Ocean()
    {
        Temperatures = 16.2;
        Pressure = 1.2;
        Salinity = 4;
        Depth = 1000;
    }

    public void Update()
    {
        Temperatures = UpdateHelper.TempCalc(Temperatures);
    }


    public IEnvironmentDisplayModel ToDisplayModel()
    {
        return new EnvironmentDisplayModel()
        {
            Types = EnvironmentTypes.Ocean,
            Name = nameof(EnvironmentTypes.Ocean),
            Image = Image
        };
    }
}