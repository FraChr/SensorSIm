using SensorSimModel.Interfaces;

namespace SensorSimUtility;

public class FactoryRegistration
{
    public required Func<ISensor> FactoryFunc { get; init; }
    public required List<Type> MetaData {get; init;}
    public string DefaultImagePath { get; init; }
}

public class FactoryRegistrationDto
{
    public required List<Type> MetaData {get; init;}
    public string DefaultImagePath { get; init; }
}