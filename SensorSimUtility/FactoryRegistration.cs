using SensorSimModel.Interfaces;

namespace SensorSimUtility;

public class FactoryRegistration
{
    public required Func<ISensor> EnvironmentFactory { get; set; }
    public required List<Type> MetaData {get; set;}
}