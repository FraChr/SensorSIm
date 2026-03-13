namespace SensorSimModel.Interfaces;

public interface ISensor
{
    ISensorDisplayModel ToDisplayModel();
    void UpdateFromEnvironment(IEnvironment environment);
    public void UpdateValue(ISensorDisplayModel display);
    public ImageModel SensorImage { get; set; }
    
}